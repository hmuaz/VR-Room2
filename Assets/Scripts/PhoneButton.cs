using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhoneButton : MonoBehaviour
{
    public string buttonNumber;
    public Material pressedMaterial;

    public MeshRenderer meshRenderer;

    public void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public IEnumerator ChangeMaterialTemporarily(){
        Material originalMaterial = meshRenderer.material;
        meshRenderer.material = pressedMaterial;
        yield return new WaitForSeconds(0.5f); // Burada istediğiniz süreyi belirleyebilirsiniz
        meshRenderer.material = originalMaterial;
    }

    public void StartChangeMaterialTemporarily(){
        StartCoroutine(ChangeMaterialTemporarily());
    }
}
