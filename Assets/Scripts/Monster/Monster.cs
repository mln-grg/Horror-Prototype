using System.Collections;
using UnityEngine;


public class Monster : MonoBehaviour
{
    public Transform B;
    public Animator animator;
    public float movementSpeed;

    public AudioClip[] steps;
    public AudioSource source;

    private bool isRunning = false;
    bool isCrouching = true;

    public AudioSource HeavyBreathing;
    public AudioSource HorrorBG;

    public float beforeCrouchToStand= 2f;
    public float CrouchToStandTime= 2f;

    public GameObject blackScreen;
    //public float CrouchToStandTime= 2f;

    float beforecrouchtostandtimer;
    float crouchtostandtimer;
    private void Start()
    {
        beforecrouchtostandtimer = beforeCrouchToStand;
        crouchtostandtimer = CrouchToStandTime;
    }
    private void Update()
    {
        beforecrouchtostandtimer -= Time.deltaTime;
        if (beforecrouchtostandtimer <= 0)
        {

            crouchtostandtimer -= Time.deltaTime;
        }
        if(beforecrouchtostandtimer<=0 && crouchtostandtimer > 0)
        {
            HorrorBG.Play();
            isCrouching = false;
        }
        if (crouchtostandtimer <= 0 &&!isRunning)
        {
            isRunning = true;
        }


        animator.SetBool("isCrouching", isCrouching);
        animator.SetBool("isRunning", isRunning);

        if (isRunning && transform.position!=B.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, B.transform.position ,movementSpeed* Time.deltaTime);
        }
        if(transform.position == B.position)
        {
           
            blackScreen.SetActive(true);
            Destroy(gameObject);
        }

    }

    private void Step()
    {
        AudioClip clip = steps[UnityEngine.Random.Range(0, steps.Length)];
        source.PlayOneShot(clip);
    }
    
    
}
