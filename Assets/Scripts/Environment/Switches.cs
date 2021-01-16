using UnityEngine;

public class Switches : MonoBehaviour
{
    [SerializeField] private AudioSource click;
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private Light bulb;
    public Material fanCeiling;
    private bool on = true;
    private void Update()
    {
        isPlayer = Physics.CheckSphere(transform.position, radius, Layer);
        if (Input.GetKeyDown(KeyCode.V) && isPlayer)
        {
            click.Play();
            on = !on;
            bulb.enabled = on;
            if(on)
                fanCeiling.EnableKeyword("_EMISSION");
            else
                fanCeiling.DisableKeyword("_EMISSION");
        }
    }



}
