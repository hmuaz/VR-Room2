using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : MonoBehaviour
{
    public Transform doorHandle;
    public VideoPlayer videoPlayer;
    public void OpenDoor()
    {
        Debug.Log("kapıaçılanzi");
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().SetTrigger("OpenDoor");
        GetComponent<AudioSource>().Play();
    }

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;

    }

    public void OnVideoEnd(VideoPlayer vp)
    {
        doorHandle.GetComponent<XRGrabInteractable>().enabled = true;
        videoPlayer.loopPointReached -= OnVideoEnd;

    }

}
