using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //0.2086845
    //-3.9
    private Transform t;
    private bool yes = false;
    public Vector3 pos = new Vector3(0, 0.2086845f, 0);
    public float transitionSpeed;
    private void Awake()
    {
        t = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            yes = true;
        }
        if (yes) 
        {
            t.position = Vector3.Lerp(t.position, pos, transitionSpeed);
            Debug.Log(t.position);
        }
    }
}
