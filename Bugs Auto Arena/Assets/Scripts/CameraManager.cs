using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam;

    public void PanToArena()
    {
        cam.transform.position = new Vector3(cam.transform.position.x, 0, cam.transform.position.z) ;
    }
    public void PanToShop()
    {
        cam.transform.position = new Vector3(cam.transform.position.x, -15, cam.transform.position.z);
    }
}
