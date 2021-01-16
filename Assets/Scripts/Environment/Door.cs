using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AudioSource open;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private bool isPlayer = false;
    public GameObject Flashlight;

    public Light wallLight;
    public Material wallMat;

    public GameObject RedHall;
    private void Update()
    {
        isPlayer = Physics.CheckSphere(transform.position, radius, Layer);
        if (Input.GetKeyDown(KeyCode.E) && isPlayer)
        {
            open.Play();
            wallMat.DisableKeyword("_EMISSION");
            wallLight.enabled = false;
            Flashlight.SetActive(false);
            RedHall.SetActive(true);
        }
    }
}
