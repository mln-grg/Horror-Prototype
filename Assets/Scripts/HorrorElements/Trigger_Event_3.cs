using UnityEngine;

public class Trigger_Event_3 : MonoBehaviour
{
    public GameObject trigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trigger.SetActive(true);
            Destroy(gameObject);
        }
    }
}
