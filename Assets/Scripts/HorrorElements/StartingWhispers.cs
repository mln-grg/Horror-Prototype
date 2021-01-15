using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingWhispers : MonoBehaviour
{
    public AudioSource whispers;

    private void Start()
    {
        StartCoroutine(whisper());
    }
    IEnumerator whisper()
    {
        yield return new WaitForSeconds(2f);
        whispers.Play();
        yield return new WaitForSeconds(15f);
        whispers.Stop();
        Destroy(gameObject);
    }
}
