using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public GameObject tvBlackScreen;
   public void switchOn()
    {
        tvBlackScreen.SetActive(false);
    }
    public void switchOff()
    {
        tvBlackScreen.SetActive(true);
        Debug.Log("gi");
    }
}
