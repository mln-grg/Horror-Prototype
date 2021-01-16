using System.Collections;
using UnityEngine;
public class DemoHorrorScene : MonoBehaviour
{
    public FlickeringLights lights;
    public AudioSource knockOnTheDoor;

    public AudioSource fastHeartBeat;
    public AudioSource slowHeartBeat;
    public AudioSource HeavyBreathing;

    private bool heartSlowdown = false;
    public float slowdownrate = 1f;

    public GameObject littleGirl;
    public Transform player;
    public GameObject spawnGirl;
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
        HeavyBreathing.Play();
        //slowHeartBeat.Play();
        
    }
    public void goingDark()
    {
        spawnGirl.SetActive(true);
        lights.StopFlickerwithLightsOff();
        //fastHeartBeat.Stop();
        //slowHeartBeat.Play();
        heartSlowdown = true;
        StartCoroutine(heartbeatSlowDown());
    }

    private void Update()
    {
        if (heartSlowdown)
        {
            //slowHeartBeat.volume = Mathf.Lerp(slowHeartBeat.volume, 0,  Time.deltaTime);
            HeavyBreathing.volume = Mathf.Lerp(HeavyBreathing.volume, 0.25f,Time.deltaTime);
        }
        
    }
 
    
    IEnumerator heartbeatSlowDown()
    {
        yield return new WaitForSeconds(10f);
        //slowHeartBeat.Stop();
        knockOnTheDoor.Play();

    }
}

