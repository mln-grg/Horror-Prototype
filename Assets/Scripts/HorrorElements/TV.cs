using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour
{
    public DemoHorrorScene demo;
    public GameObject tvBlackScreen;
    public VideoPlayer video1;
    public VideoPlayer video2;

    private bool donePlaying = false;
    private bool secondflicker = false;
    private bool thirdflicker = false;
    private void Update()
    {
        if(video1.time>=124 && !donePlaying)
        {
            donePlaying = true;
            video1.Stop();
            video2.Play();
            demo.firstFlicker();

        }
        
        if(video2.isPlaying && video2.time >=28 && !secondflicker)
        {
            secondflicker = true;
            demo.secondFlicker();
        }  
        
        if(video2.isPlaying && video2.time >=43 && !thirdflicker)
        {
            thirdflicker = true;
            demo.thirdFlicker();
        }
        
        if(video2.isPlaying && video2.time >=71)
        {

            demo.goingDark();
        }
    }
    public void switchOn()
    {
        tvBlackScreen.SetActive(false);
    }
    public void switchOff()
    {
        tvBlackScreen.SetActive(true);
    }
}
