using System.Collections;
using UnityEngine;
public class DemoHorrorScene : MonoBehaviour
{
    public FlickeringLights lights;
    public AudioSource knockOnTheDoor;

    public AudioSource fastHeartBeat;
    public AudioSource slowHeartBeat;
   public void triggered()
    {
        lights.minTime = 1f;
        lights.maxTime = 2f;
        lights.SingleFlicker();
    }

    public void firstFlicker()
    {
        lights.minTime = 1f;
        lights.maxTime = 1.5f;
        lights.StartFlickering();
    } 
    public void secondFlicker()
    {
        lights.minTime = 0.01f;
        lights.maxTime = 0.2f;
        lights.StartFlickering();
    }
    public void thirdFlicker()
    {
        lights.minTime = 0.01f;
        lights.maxTime = 0.05f;
        lights.StartFlickering();
        fastHeartBeat.Play();
    }
    public void goingDark()
    {
        lights.StopFlickerwithLightsOff();       
        StartCoroutine(heartbeatSlowDown());
    }
    IEnumerator heartbeatSlowDown()
    {
        yield return new WaitForSeconds(10f);
        fastHeartBeat.Stop();       
        yield return new WaitForSeconds(2f);
        knockOnTheDoor.Play();
    }
}

