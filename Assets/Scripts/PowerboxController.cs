using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PowerboxController : MonoBehaviour
{
    public GameObject[] roomLights;
    public DirectionalLight directionalLight;
    public float intensityMultiplierForClose = 0;
    public float intensityMultiplierForOpen = 1.0f;

    public Sartel sartelMavi;
    public Sartel sartelKirmizi;
    public Sartel sartelSiyah;
    public Sartel sartelSari;



    public bool isCombinationRight = false;

    /* void Start(){
        CloseLights();
    } */

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



    /* public void IsSartelDown(Sartel sartel)
    {
        float xAngle = sartel.sartelObject.transform.eulerAngles.x;
        if (sartel.sartelObject.transform.eulerAngles.x > 339f && sartel.sartelObject.transform.eulerAngles.x < 345f)
        {
            sartel.IsSartelUp = true;
            sartel.IsSartelDown = false;
            sartel.IsSartelMiddle = false;
        }
        else if (sartel.sartelObject.transform.eulerAngles.x > 300f && sartel.sartelObject.transform.eulerAngles.x < 335f)
        {
            sartel.IsSartelUp = false;
            sartel.IsSartelDown = true;
            sartel.IsSartelMiddle = false;
        }
        else
        {
            sartel.IsSartelUp = false;
            sartel.IsSartelDown = false;
            sartel.IsSartelMiddle = true;
        }

    } */

    public void CheckRightCombination()
    {
        if (sartelSari.IsSartelUp && sartelKirmizi.IsSartelUp && sartelMavi.IsSartelDown && sartelSiyah.IsSartelDown)
        {
            isCombinationRight = true;
            OpenLights();
        }
    }

    public void IsCombinationRight()
    {
        if (isCombinationRight)
        {
            OpenLights();
        }
    }
}
