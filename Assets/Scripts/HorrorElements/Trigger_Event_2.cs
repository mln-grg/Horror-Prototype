using System.Collections;
using UnityEngine;

public class Trigger_Event_2 : MonoBehaviour
{
    public AudioSource knockOnTheDoor;
    public AudioSource DoorOpenandClose;
    public AudioSource slowHeartBeat;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            knockOnTheDoor.Stop();
            DoorOpenandClose.Play();

            
        }
    }
    IEnumerator heartbeat()
    {
        yield return new WaitForSeconds(6f);
        slowHeartBeat.Play();
        Destroy(gameObject);
    }
}
