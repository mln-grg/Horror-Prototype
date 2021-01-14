using UnityEngine;
public class DemoHorrorScene : MonoBehaviour
{
    public FlickeringLights lights;
    public MouseLook mouseLook;

    private bool firstFlicker = false;
    private bool secondFlicker = false;
    private bool thirdFlicker = false;

    private void Awake()
    {
        mouseLook.normalView = 40f;
    }
    private void Update()
    {
        //Child Sits in front of TV Scene

        if (lights.tv.time >= 20f && !firstFlicker)
        {
            lights.minTime = 1f;
            lights.maxTime = 1.5f;
            firstFlicker = true;
            lights.StartFlickering();
            mouseLook.normalView = 50f;
        }
        if (lights.tv.time >= 36f && !secondFlicker)
        {
            lights.minTime = 0.01f;
            lights.maxTime = 0.2f;
            secondFlicker = true;
            mouseLook.normalView = 55f;
        }
        if(lights.tv.time >= 59f && !thirdFlicker)
        {
            lights.minTime = 0.01f;
            lights.maxTime = 0.05f;
            thirdFlicker = true;
            mouseLook.normalView = 60f;
        }
        if(lights.tv.time >= 83f)
        {
            lights.StopFlickerwithLightsOff();
        }
    }
}

