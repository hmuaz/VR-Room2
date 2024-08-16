using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPadKey : MonoBehaviour
{
    public TextMeshProUGUI code;
    public string enteredCode = "";
    private string requiredCode = "4138";
    public Transform door;
    public void EnterCode(string digit)
    {
        if (enteredCode.Length < 4)
        {
            enteredCode += digit;
            Debug.Log(enteredCode);
        }

        if (enteredCode.Length == 4)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        if (enteredCode == requiredCode)
        {
            door.GetComponent<Door>().OpenDoor();
        }
        else
        {
            ResetCode();
        }
    }

    private void ResetCode()
    {
        enteredCode = "";
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
