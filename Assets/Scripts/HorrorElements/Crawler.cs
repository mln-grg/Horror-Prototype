using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    public Transform pointA;
    public float speed = 1;
    public bool trigger;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (trigger == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }
        if (transform.position == pointA.position)
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
