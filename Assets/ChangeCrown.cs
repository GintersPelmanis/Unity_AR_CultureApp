
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using DanielLochner.Assets.SimpleScrollSnap;


public class ChangeCrown : MonoBehaviour
{
    [SerializeField]
    private GameObject FacePrefab_1;
    [SerializeField]
    private GameObject FacePrefab_2;
    [SerializeField]
    private ARFaceManager FaceManager;
    [SerializeField]
     private SimpleScrollSnap SimpleScrollSnap;

    public void ChangeFace()
    {

        int a = SimpleScrollSnap.SelectedPanel;
        GameObject NewFacePrefab = a switch
        {
            0 => FacePrefab_1,
            1 => FacePrefab_2,
            _ => FacePrefab_1,
        };
        FaceManager.facePrefab = NewFacePrefab;
    }
}
