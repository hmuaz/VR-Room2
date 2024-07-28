using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PowerboxController : MonoBehaviour
{
    public GameObject[] roomLights;
    public DirectionalLight directionalLight;
    public float intensityMultiplier = 1.0f;


    public void CloseLights()
    {
        UnityEngine.RenderSettings.ambientIntensity = intensityMultiplier;
        for (int i = 0; i < roomLights.Length; i++)
        {
            roomLights[i].SetActive(false);
        }

        // if (UnityEngine.RenderSettings.skybox != null)
        // {
        //     // Skybox materyalini değiştirmek için
        //     Material skyboxMaterial = UnityEngine.RenderSettings.skybox;
        //     skyboxMaterial.SetFloat("_Exposure", intensityMultiplier);
        // }
    }
}
