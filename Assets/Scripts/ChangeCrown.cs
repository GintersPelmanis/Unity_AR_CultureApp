using System.Collections.Generic;
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

        List<ARFace> faces = new List<ARFace>();
        foreach (ARFace face in FaceManager.trackables)
        {
            faces.Add(face);
        }


        foreach (ARFace face in faces)
        {
            if (face.transform.childCount > 0)
            {
                Destroy(face.transform.GetChild(0).gameObject);
            }
            GameObject newModel = Instantiate(NewFacePrefab, face.transform);
            newModel.transform.localPosition = Vector3.zero;
            newModel.transform.localRotation = Quaternion.identity;
            newModel.transform.localScale = Vector3.one;
        }


        FaceManager.facePrefab = NewFacePrefab;
    }


}
