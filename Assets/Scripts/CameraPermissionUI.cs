using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class CameraPermissionUI : MonoBehaviour
{
    public GameObject permissionDeniedUI;

    private void Start()
    {
        // Check if camera permission is already granted
        if (Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            // Camera permission is granted, enable UI element
            permissionDeniedUI.SetActive(false);
        }
        else
        {
            // Camera permission is not granted, request permission
            Permission.RequestUserPermission(Permission.Camera);
        }
    }

    private void Update()
    {
        // Check if camera permission has been denied
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            // Camera permission has been denied, enable UI element
            permissionDeniedUI.SetActive(true);
        }
        else
        {
            permissionDeniedUI.SetActive(false);
        }
    }
}
