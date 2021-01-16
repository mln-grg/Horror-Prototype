using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_RoomptB : MonoBehaviour
{
    public GameObject child;
    public AudioSource giggle;

    bool done = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            child.SetActive(true);
            giggle.Play();
            done = true;
            
        }
    }
    private void Update()
    {
        if (done && !giggle.isPlaying)
        {
            Destroy(child);
            Destroy(gameObject);
        }
    }
}
