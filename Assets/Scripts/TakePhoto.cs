using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using System.IO;
using System.Collections;

[RequireComponent(typeof(ARCameraManager))]
public class TakePhoto : MonoBehaviour
{
    [SerializeField]
    private Button takePhotoButton;
    [SerializeField]
    private GameObject photoPrefab;
    [SerializeField]
    private AudioClip snapSound;

    private ARCameraManager cameraManager;
    private Texture2D photoTexture;

    private void Awake()
    {
        cameraManager = GetComponent<ARCameraManager>();


        takePhotoButton.onClick.AddListener(TakePhotoOnClick);
    }

    private void TakePhotoOnClick()
    {
  
        cameraManager.enabled = false;
        StartCoroutine(CapturePhoto());
        cameraManager.enabled = true;
    }

    private IEnumerator CapturePhoto()
    {
        // Play the snap sound effect
        AudioSource.PlayClipAtPoint(snapSound, Camera.main.transform.position);

        yield return null;

        // Create a RenderTexture to capture the camera view with the added augmentation
        RenderTexture renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        Camera camera = Camera.main;
        camera.targetTexture = renderTexture;
        camera.Render();

        // Read the RenderTexture data into a Texture2D
        RenderTexture.active = renderTexture;
        Texture2D cameraTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
        cameraTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        cameraTexture.Apply();
        RenderTexture.active = null;

        RawImage photoImage = photoPrefab.GetComponent<RawImage>();
        photoTexture = new Texture2D(cameraTexture.width, cameraTexture.height, TextureFormat.RGBA32, false);
        photoTexture.SetPixels(cameraTexture.GetPixels());
        photoTexture.Apply();
        photoImage.texture = photoTexture;

        // Save the photo as a PNG image file
        byte[] bytes = photoTexture.EncodeToPNG();
        string fileName = "Vainags_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        File.WriteAllBytes(Application.persistentDataPath + "/" + fileName, bytes);

    }
}
