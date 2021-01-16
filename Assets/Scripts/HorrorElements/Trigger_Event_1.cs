
using UnityEngine;

public class Trigger_Event_1 : MonoBehaviour
{
    public DemoHorrorScene d;
    public Light light;
    public Material fanCeiling;
    public bool done = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            d.triggered();
        }
       
    }
    private void Update()
    {
        if (done)
        {
            light.enabled = false;
            fanCeiling.DisableKeyword("_EMISSION");
            Destroy(gameObject);
        }
    }
}
