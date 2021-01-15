
using UnityEngine;

public class Trigger_Event_1 : MonoBehaviour
{
    public DemoHorrorScene d;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            d.triggered();
            Destroy(gameObject);
        }
    }
}
