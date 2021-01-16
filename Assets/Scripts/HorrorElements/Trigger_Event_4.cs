using UnityEngine;

public class Trigger_Event_4 : MonoBehaviour
{
    public GameObject B;
    public GameObject Monster;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            B.SetActive(true);
            Monster.SetActive(true);
            Destroy(gameObject);
        }
    }
}
