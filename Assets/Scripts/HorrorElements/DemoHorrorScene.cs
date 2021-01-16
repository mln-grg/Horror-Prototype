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
    private bool checkGirl = false;
    private bool sawGirl = false;
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
        littleGirl.SetActive(true);
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
        if (checkGirl)
        {
            RaycastHit hit;

            if (Physics.Linecast(player.position, littleGirl.transform.position, out hit))
            {
                if (hit.transform == littleGirl.transform)
                {
                    Debug.Log(".");
                }
                else
                {
                    sawGirl = true;
                    checkGirl = false;
                    Debug.Log("Destroyed"); 
                }

            }
        }
    }
    public bool destroyGirl()
    {
        if (sawGirl)
        {
            sawGirl = false;
            Destroy(littleGirl);
            return true;
        }
        else
            return false;
    }
    IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(littleGirl);
    }
    IEnumerator heartbeatSlowDown()
    {
        yield return new WaitForSeconds(10f);
        //slowHeartBeat.Stop();
        knockOnTheDoor.Play();
        checkGirl = true;
    }
}

