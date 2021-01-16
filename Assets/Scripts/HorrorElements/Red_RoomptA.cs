using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_RoomptA : MonoBehaviour
{
    public GameObject nextTrigger;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            nextTrigger.SetActive(true);
            Destroy(gameObject);
        }
    }
}
