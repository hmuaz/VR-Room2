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

    public bool IsSartelDown(GameObject sartel)
    {
        if (sartel.transform.eulerAngles.x > -60f)
        {
            return true;
        }
        else if (sartel.transform.eulerAngles.x < -120f)
        {
            return false;
        }

        return false;
    }

    public void CheckRightCombination()
    {
        bool kirmiziSartel = IsSartelDown(sartelKirmizi);
        bool maviSartel = IsSartelDown(sartelMavi);
        bool sariSartel = IsSartelDown(sartelSari);
        bool siyahSartel = IsSartelDown(sartelSiyah);

        if (kirmiziSartel == true && maviSartel == false && sariSartel == false && siyahSartel == true)
        {
            isCombinationRight = true;
        }
        else
        {
            isCombinationRight = false;

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
