using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AiManager : MonoBehaviour
{
    public AudioClip[] aiClips;
    public AudioSource audioSource;
    public PlayVideo playVideo;
    public VideoPlayer videoPlayer;
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;

        StartCoroutine(StartingAIAudio());
    }

    private IEnumerator StartingAIAudio()
    {
        for (int i = 0; i < aiClips.Length && i <= 2; i++)
        {
            if (i == 0)
            {
                yield return new WaitForSeconds(3f);
            }
            PlayAiClipAtIndex(i);

            yield return new WaitForSeconds(audioSource.clip.length);

            yield return new WaitForSeconds(3f);

            if (i == 2)
            {
                playVideo.PlayAtIndex(0);

            }
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video bitti!");
        playVideo.Stop();
        PlayAiClipAtIndex(4);
        videoPlayer.loopPointReached -= OnVideoEnd;

    }

    public void PlayAiClipAtIndex(int i)
    {
         audioSource.clip = aiClips[i];
            audioSource.Play();
    }




}
