using System.Collections.Generic;
using UnityEngine;

public class AudioQueuePlayer : MonoBehaviour
{
    public List<AudioClip> audioClipList;
    private Queue<AudioClip> audioQueue; 

    public AudioSource audioSource; 

    void Start()
    {
        audioQueue = new Queue<AudioClip>(audioClipList);
    }

    public void PlayNextClip()
    {
        if (audioQueue.Count > 0)
        {
            AudioClip clipToPlay = audioQueue.Dequeue();
            audioSource.clip = clipToPlay;
            audioSource.Play();

            audioQueue.Enqueue(clipToPlay);
        }
    }
}
