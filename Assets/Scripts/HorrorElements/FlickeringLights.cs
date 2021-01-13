using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class FlickeringLights : MonoBehaviour
{
    public GameObject Lights;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private float timer;
    [SerializeField] private bool lightsEnabled;
    
    bool start = false;
    
    public PostProcessVolume volume;
    ColorGrading colorGradingLayer = null;
    [SerializeField] private float defaultIntensity;
    [SerializeField] private float lowVoltageIntensity;
    [SerializeField] private float voltageDropTime;


    public Material fanCeiling;
    public Material fluroscentLight;
    public Material lampDesk;
    public Material lampWall;
    private void Awake()
    {
        volume.profile.TryGetSettings(out colorGradingLayer);
    }
    private void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }
    private void Update()
    {
        Flicker();
        if (Input.GetKey(KeyCode.L))
            StartFlickering();
        if (Input.GetKey(KeyCode.Minus))
            StopFlickerwithLightsOff();
        if (Input.GetKey(KeyCode.Equals))
            StopFlickerwithLightsOn();

        if (start)
        {
            colorGradingLayer.postExposure.value = Mathf.Lerp(defaultIntensity, lowVoltageIntensity, voltageDropTime * Time.deltaTime);
            Debug.Log(colorGradingLayer.postExposure.value);
        }
    }
    public void StartFlickering()
    {
        start = true;
        
    }
    private void Flicker()
    {
        if (start)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            if (timer <= 0)
            {
                lightsEnabled = !lightsEnabled;
                if (lightsEnabled)
                {
                    Lights.SetActive(true);
                    
                    fanCeiling.EnableKeyword("_EMISSION");
                    lampDesk.EnableKeyword("_EMISSION");
                    lampWall.EnableKeyword("_EMISSION");
                    fluroscentLight.EnableKeyword("_EMISSION");
                    timer = Random.Range(minTime, maxTime);
                }
                else
                {
                    Lights.SetActive(false);

                    fanCeiling.DisableKeyword("_EMISSION");
                    lampDesk.DisableKeyword("_EMISSION");
                    lampWall.DisableKeyword("_EMISSION");
                    fluroscentLight.DisableKeyword("_EMISSION");
                    timer = Random.Range(minTime, maxTime);
                }
            }
        }
    }
    public void StopFlickerwithLightsOn()
    {
        start = false;
        fanCeiling.EnableKeyword("_EMISSION");
        lampDesk.EnableKeyword("_EMISSION");
        lampWall.EnableKeyword("_EMISSION");
        fluroscentLight.EnableKeyword("_EMISSION");
        Lights.SetActive(true);
        colorGradingLayer.postExposure.value = defaultIntensity;
    }
    public void StopFlickerwithLightsOff()
    {
        start = false;
        fanCeiling.DisableKeyword("_EMISSION");
        lampDesk.DisableKeyword("_EMISSION");
        lampWall.DisableKeyword("_EMISSION");
        fluroscentLight.DisableKeyword("_EMISSION");
        Lights.SetActive(false);
        colorGradingLayer.postExposure.value = lowVoltageIntensity;
    }

}
