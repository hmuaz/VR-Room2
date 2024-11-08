using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    //public Text displayText;
    public string requiredNumber = "1964";
    public AudioClip recordedMessage;
    public AudioSource audioSource;
    public string enteredNumber = "";



    


    public void OnButtonPressed(string digit)
    {
        if (enteredNumber.Length < 4)
        {
            enteredNumber += digit;
            Debug.Log(enteredNumber);
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
            Debug.Log("right number");
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
