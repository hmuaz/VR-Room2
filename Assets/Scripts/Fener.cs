using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fener : MonoBehaviour
{
    private bool firstOpen = false;
    [SerializeField] private GameObject fener;
    public void FenerEtkilesim()
    {
        if(firstOpen) return;
        bool isActive = fener.activeInHierarchy;
        fener.SetActive(!isActive);
    }
}
