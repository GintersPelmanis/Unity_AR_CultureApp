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
    private GameObject photoPreview;
    [SerializeField]
    private AudioClip snapSound;
    [SerializeField]
    private GameObject UI_element;

    private ARCameraManager cameraManager;
    private Texture2D photoTexture;

    private void Awake()
    {
        cameraManager = GetComponent<ARCameraManager>();


        takePhotoButton.onClick.AddListener(TakePhotoOnClick);
    }

    private void TakePhotoOnClick()
    {
        StartCoroutine(CapturePhoto());
    }

    private IEnumerator CapturePhoto()
    {
        // Disable the UI element while the photo is being taken
        UI_element.SetActive(false);

        yield return new WaitForEndOfFrame();
   
        // Play the snap sound effect
        AudioSource.PlayClipAtPoint(snapSound, Camera.main.transform.position);

        photoTexture = ScreenCapture.CaptureScreenshotAsTexture();
        var photoImage = photoPreview.GetComponentInChildren<RawImage>();
        photoImage.texture = photoTexture;

        // Save the photo to device
        string fileName = "Vainags_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss")+".png";
        ScreenCapture.CaptureScreenshot(fileName);

        // Enable the UI element after the photo is taken
        UI_element.SetActive(true);
    }
}
