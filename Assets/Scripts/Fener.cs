using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fener : MonoBehaviour
{
    [SerializeField] private GameObject fener;
    public void FenerEtkilesim()
    {
        bool isActive = fener.activeInHierarchy;
        fener.SetActive(!isActive);
    }
}
