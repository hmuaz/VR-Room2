using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlaySpeaker : MonoBehaviour
{
    public Transform cd;
    public float cdTurnSpeed = 10f;
    public AudioSource audioSource;
    public bool isMusicPlaying = false;

    public void PlayStopMusic()
    {
        isMusicPlaying = !isMusicPlaying;
        GetComponent<Animator>().SetBool("PlayMusic", isMusicPlaying);

        if (isMusicPlaying)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();

        }
    }

    void Update()
    {
        if (!audioSource.isPlaying) return;
        cd.transform.eulerAngles += new Vector3(0, cdTurnSpeed * Time.deltaTime, 0);
    }
}
