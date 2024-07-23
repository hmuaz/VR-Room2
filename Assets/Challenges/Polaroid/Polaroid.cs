using System.Collections;
using UnityEngine;

public class Polaroid : MonoBehaviour
{
    public GameObject photoPrefab = null;
    public MeshRenderer screenRenderer = null;
    public Transform spawnLocation = null;

    public Renderer keyRenderer = null; // Anahtarın renderer bileşeni
    public Material brightMaterial = null; // Parlak malzeme,
    public GameObject pointLight;
    private Material originalMaterial = null; // Orijinal malzeme
    private Camera renderCamera = null;

    private GameObject oldPhoto = null; // Önceki fotoğraf için referans
    private GameObject newPhoto = null; // Yeni fotoğraf için referans

    private void Awake()
    {
        renderCamera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        CreateRenderTexture();
        TurnOff();
    }

    private void CreateRenderTexture()
    {
        RenderTexture newTexture = new RenderTexture(256, 256, 32, RenderTextureFormat.Default, RenderTextureReadWrite.sRGB);
        newTexture.antiAliasing = 4;

        renderCamera.targetTexture = newTexture;
        screenRenderer.material.mainTexture = newTexture;
    }

    public void TakePhoto()
    {
        StartCoroutine(TakePhotoCoroutine());
    }


    private IEnumerator TakePhotoCoroutine()
    {
        originalMaterial = keyRenderer.material;
        keyRenderer.material = brightMaterial;

        // Partikül sistemini etkinleştir
        if (pointLight != null)
        {
            pointLight.SetActive(true);
        }

        // Fotoğrafı çek
        yield return new WaitForEndOfFrame();
        newPhoto = CreatePhoto();
        SetPhotoImage(newPhoto.GetComponent<Photo>());

        // Önceki fotoğrafı düşür
        if (oldPhoto != null)
        {
            DropOldPhoto(oldPhoto);
        }

        // Yeni fotoğrafı oldPhoto'ya at
        oldPhoto = newPhoto;

        // Anahtarı eski haline döndür
        keyRenderer.material = originalMaterial;

        // Partikül sistemini durdur
        if (pointLight != null)
        {
            pointLight.SetActive(false);
        }
    }

     private void DropOldPhoto(GameObject oldPhoto)
    {
        Rigidbody rb = oldPhoto.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = oldPhoto.AddComponent<Rigidbody>();
        }
        rb.useGravity = true;
        rb.isKinematic = false;
        oldPhoto.transform.parent = null; // Parent'ı kaldırarak serbest bırak
    }



    private GameObject CreatePhoto()
    {
        GameObject photoObject = Instantiate(photoPrefab, spawnLocation.position, spawnLocation.rotation, transform);
        return photoObject;
    }

    private void SetPhotoImage(Photo photo)
    {
        Texture2D newTexture = RenderCameraToTexture(renderCamera);
        photo.SetImage(newTexture);
    }

    private Texture2D RenderCameraToTexture(Camera camera)
    {
        camera.Render();
        RenderTexture.active = camera.targetTexture;

        Texture2D photo = new Texture2D(256, 256, TextureFormat.RGB24, false);
        photo.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);
        photo.Apply();
        

        return photo;
    }

    public void TurnOn()
    {
        renderCamera.enabled = true;
        screenRenderer.material.color = Color.white;
    }

    public void TurnOff()
    {
        renderCamera.enabled = false;
        screenRenderer.material.color = Color.black;
    }
}
