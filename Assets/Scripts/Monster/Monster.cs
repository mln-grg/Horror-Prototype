using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform B;
    public Animator animator;
    public float movementSpeed;

    public AudioClip[] steps;
    public AudioSource source;

    private bool isWalking = false;

    private void OnEnable()
    {
        isWalking = true;
    }
    private void Update()
    {
        animator.SetBool("isWalking", isWalking);
        transform.position = Vector3.MoveTowards(transform.position, B.position, movementSpeed * Time.deltaTime);

        if(transform.position == B.position)
        {
            Destroy(gameObject);
        }
    }

    private void Step()
    {
        AudioClip clip = steps[UnityEngine.Random.Range(0, steps.Length)];
        source.PlayOneShot(clip);
    }

    
}
