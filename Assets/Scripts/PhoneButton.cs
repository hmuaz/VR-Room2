using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PhoneButton : MonoBehaviour
{
    public string buttonNumber;
    public Material pressedMaterial;

    private Material originalMaterial;
    private MeshRenderer meshRenderer;
    private Coroutine materialCoroutine;


    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;  // Orijinal materyali sakla
    }

    public IEnumerator ChangeMaterialTemporarily()
    {
        // Eğer başka bir coroutine çalışıyorsa onu durdur.
        if (materialCoroutine != null)
        {
            StopCoroutine(materialCoroutine);
        }

        meshRenderer.material = pressedMaterial;
        yield return new WaitForSeconds(0.5f); 
        meshRenderer.material = originalMaterial;

        // Coroutine'in sona erdiğini belirt
        materialCoroutine = null;
    }

    public void StartChangeMaterialTemporarily()
    {
        // Eski coroutine'i durdur ve yeni başlat
        materialCoroutine = StartCoroutine(ChangeMaterialTemporarily());
    }
}
