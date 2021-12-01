using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public Camera cam;
    public Canvas shopCanvas;
    public Shop shop;
    public EnemyManager enemyManager;

    private bool arenaMode;

    private void Update()
    {
        if (arenaMode)
        {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(cam.transform.position.x, 0, cam.transform.position.z), cameraSpeed *Time.deltaTime);

        }

    }
    public void PanToArena()
    {
        arenaMode = true;
        shopCanvas.enabled = false;
        //cam.transform.position = new Vector3(cam.transform.position.x, 0, cam.transform.position.z) ;
    }
    public void PanToShop()
    {
        arenaMode = false;
        cam.transform.position = new Vector3(cam.transform.position.x, -14, cam.transform.position.z);
        shopCanvas.enabled = true;
        shop.BackToShop();
        enemyManager.SetEnemyTeam();
    }
}
