using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeadBob : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private AudioSource audio;
    [SerializeField] CharacterController characterController;
    [SerializeField] private AudioClip[] footStepSounds;
    [SerializeField] private float nextStepTime = 0.5f;
    public float headbobFrequency = 1.5f;
    public float headbobSwayAngle = 5f;
    public float headbobHeight = 3f;
    public float headbobSideMovement = 5f;
    public float jumpLandIntensity = 3f;
    private Vector3 originalLocalPosition;
    private float headbobCycle = 0.0f;
    private float headbobFade = 0.0f;
    private float springPosition = 0.0f;
    private float springVelocity = 0.0f;
    private float springElastic = 1.1f;
    private float springDampen = 0.8f;
    private float springVelocityThreshold = 0.05f;
    private float springPositionThreshold = 0.05f;
    Vector3 previousPosition;
    Vector3 previousVelocity = Vector3.zero;
    Vector3 miscRefVel;
    private void Start()
    {
        originalLocalPosition = head.localPosition;
    }
    private void FixedUpdate()
    {
        float yPos = 0;
        float xPos = 0;
        float zTilt = 0;
        float xTilt = 0;
        float bobSwayFactor = 0;
        float bobFactor = 0;
        float strideLangthen = 0;
        float flatVel = 0;
        Vector3 vel = (characterController.transform.position - previousPosition)/Time.deltaTime;
        Vector3 velChange = vel - previousVelocity;
        previousPosition = characterController.transform.position;
        previousVelocity = vel;
        springVelocity -= velChange.y;
        springVelocity -= springPosition * springElastic;
        springVelocity *= springDampen;
        springPosition += springVelocity * Time.deltaTime;
        springPosition = Mathf.Clamp(springPosition, -0.3f, 0.3f);

        if (Mathf.Abs(springVelocity) < springVelocityThreshold && Mathf.Abs(springPosition) < springPositionThreshold) { springPosition = 0; springVelocity = 0; }
        flatVel = new Vector3(vel.x, 0.0f, vel.z).magnitude;
        strideLangthen = 1 + (flatVel * ((headbobFrequency * 2) / 10));
        headbobCycle += (flatVel / strideLangthen) * (Time.deltaTime / headbobFrequency);
        bobFactor = Mathf.Sin(headbobCycle * Mathf.PI * 2);
        bobSwayFactor = Mathf.Sin(Mathf.PI * (2 * headbobCycle + 0.5f));
        bobFactor = 1 - (bobFactor * 0.5f + 1);
        bobFactor *= bobFactor;

        yPos = 0;
        xPos = 0;
        zTilt = 0;
        if (new Vector3(vel.x, 0.0f, vel.z).magnitude < 0.1f) { headbobFade = Mathf.MoveTowards(headbobFade, 0.0f, 0.5f); } else { headbobFade = Mathf.MoveTowards(headbobFade, 1.0f, Time.deltaTime); }
        float speedHeightFactor = 1 + (flatVel * 0.3f);
        xPos = -(headbobSideMovement / 10) * headbobFade * bobSwayFactor;
        yPos = springPosition * (jumpLandIntensity / 10) + bobFactor * (headbobHeight / 10) * headbobFade * speedHeightFactor;
        zTilt = bobSwayFactor * (headbobSwayAngle / 10) * headbobFade;
        if (vel.magnitude > 0.1f)
        {
            head.localPosition = Vector3.MoveTowards(head.localPosition,originalLocalPosition + new Vector3(xPos, yPos, 0), 0.5f);
        }
        else
        {
            head.localPosition = Vector3.SmoothDamp(head.localPosition,originalLocalPosition + new Vector3(xPos, yPos, 0), ref miscRefVel, 0.15f);
        }
        head.localRotation = Quaternion.Euler(xTilt, 0, zTilt);

        //FootStepsAudio

        if (headbobCycle > nextStepTime)
        {
            nextStepTime = headbobCycle + 0.5f;
            int n = Random.Range(1, footStepSounds.Length);
            audio.clip = footStepSounds[n];
            audio.Play();

            footStepSounds[n] = footStepSounds[0];
            footStepSounds[0] = audio.clip;
        }

    }
}

