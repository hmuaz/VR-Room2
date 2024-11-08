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
            code.text = enteredCode;
            Debug.Log(enteredCode);
        }

        if (enteredCode.Length == 4)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        Debug.Log("chechcode");
        if (enteredCode == requiredCode)
        {
        Debug.Log("doğru");

            door.GetComponent<Door>().OpenDoor();
            code.color = Color.green;
            code.text = "Valid Code!";
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
