using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1;
    public bool trigger;
    public AudioSource breathing;
   
    void Update()
    {
        if (trigger == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            breathing.volume = 1f;
            breathing.Play();
        }
        if (transform.position == pointA.position)
        {
            pointA.position = pointB.position;
        }
        if(transform.position == pointB.position)
            this.gameObject.SetActive(false);

    }
}
