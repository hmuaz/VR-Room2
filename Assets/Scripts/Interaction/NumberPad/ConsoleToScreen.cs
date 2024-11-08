using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsoleToScreen : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    private string logMessages = "";

    void OnEnable()
    {
        // Unity'nin log callback'ine abone ol
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        // Abonelikten çık
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // Logları string'e ekle
        logMessages += logString + "\n";

        // Text bileşenine yaz
        uiText.text = logMessages;

        // Eğer loglar çok birikirse kesebiliriz
        if (logMessages.Length > 1000)
        {
            logMessages = logMessages.Substring(logMessages.Length - 1000);
        }
    }
}
