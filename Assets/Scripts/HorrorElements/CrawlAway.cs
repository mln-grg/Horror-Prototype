using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlAway : MonoBehaviour
{
    public GameObject crawler;
    public Crawler C;
    public AudioSource Jumpscare;
    public GameObject nextTrigger;
    public AudioSource doorBanging;
    public AudioSource Breathing;
    public GameObject Barricade;
    public void OnTriggerEnter()
    {
        doorBanging.Stop();
        crawler.SetActive(true);
        C.trigger = true;
        Jumpscare.Play();
        Breathing.volume = 1f;
        Barricade.SetActive(true);
        nextTrigger.SetActive(true);
        Destroy(gameObject);
    }
}
