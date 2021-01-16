using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_LittleGirl : MonoBehaviour
{
    public GameObject littleGirl;
    public PlayerMovement p;
    public AudioSource giggle;
    public bool done = false;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            littleGirl.SetActive(true);
            giggle.Play();
            p.checkForGirl = true;
        }
    }

    private void Update()
    {
        if (done)
        {
            Destroy(littleGirl);
            Destroy(gameObject);
        }
    }
}
