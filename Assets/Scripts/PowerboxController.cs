using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PowerboxController : MonoBehaviour
{
    public GameObject[] roomLights;
    public DirectionalLight directionalLight;
    public float intensityMultiplierForClose = 0;
    public float intensityMultiplierForOpen = 1.0f;

    public GameObject sartelMavi;
    public GameObject sartelKirmizi;
    public GameObject sartelSiyah;
    public GameObject sartelSari;

    public bool isKirmiziSartel = false;
    public bool isMaviSartel = false;
    public bool isSariSartel = false;
    public bool isSiyahSartel = false;


    public bool isCombinationRight = false;


    public void CloseLights()
    {
        UnityEngine.RenderSettings.ambientIntensity = intensityMultiplierForClose;
        for (int i = 0; i < roomLights.Length; i++)
        {
            roomLights[i].SetActive(false);
        }

    }

    public void OpenLights()
    {
        UnityEngine.RenderSettings.ambientIntensity = intensityMultiplierForOpen;
        for (int i = 0; i < roomLights.Length; i++)
        {
            roomLights[i].SetActive(true);
        }

    }

    

    public void IsSartelDown(GameObject sartel)
    {
        float xAngle = sartel.transform.eulerAngles.x;
        Debug.Log("Current x angle: " + xAngle);
        if (sartel.transform.eulerAngles.x > 339f && sartel.transform.eulerAngles.x < 345f)
        {
            Debug.Log("şartel yukarda");

            //return true;
        }
        else if (sartel.transform.eulerAngles.x > 315f && sartel.transform.eulerAngles.x < 325f)
        {
            Debug.Log("şartel aşşada");

            //return false;
        }

        //return false;
    }

    /* public void CheckRightCombination()
    {
        Debug.Log("CheckRightCombination");
        isKirmiziSartel = IsSartelDown(sartelKirmizi);
        isMaviSartel = IsSartelDown(sartelMavi);
        isSariSartel = IsSartelDown(sartelSari);
        isSiyahSartel = IsSartelDown(sartelSiyah);

        if (isKirmiziSartel == true && isMaviSartel == false && isSariSartel == false && isSiyahSartel == true)
        {
            isCombinationRight = true;
        }
        else
        {
            isCombinationRight = false;

        }
    } */

    public void IsCombinationRight()
    {
        if (isCombinationRight)
        {
            OpenLights();
        }
    }
}
