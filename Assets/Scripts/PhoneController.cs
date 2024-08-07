using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    //public Text displayText;
    public string requiredNumber = "1964";
    public AudioClip recordedMessage;
    private AudioSource audioSource;
    public string enteredNumber = "";

    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        
    }

    public void OnButtonPressed(string digit)
    {
        if (enteredNumber.Length < 5)
        {
            Debug.Log(enteredNumber);
            enteredNumber += digit;
            //displayText.text = enteredNumber;
        }

        if (enteredNumber.Length == 4)
        {
            CheckNumber();
        }
    }

    private void CheckNumber()
    {
        if (enteredNumber == requiredNumber)
        {
            PlayRecordedMessage();
        }
        else
        {
            ResetPhone();
        }
    }

    private void PlayRecordedMessage()
    {
        audioSource.clip = recordedMessage;
        audioSource.Play();
        Invoke("ResetPhone", audioSource.clip.length);
    }

    private void ResetPhone()
    {
        enteredNumber = "";
        //displayText.text = "";
    }

    
}
