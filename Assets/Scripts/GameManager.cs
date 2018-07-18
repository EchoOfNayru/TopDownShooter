using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public PlayerController player;
    public CameraScript cam;
    public UIManager uiManager;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveRoom(string dir)
    {
        if (dir == "North")
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z + 12);
            player.transform.position = new Vector3(cam.transform.position.x, player.transform.position.y, cam.transform.position.z - 4);
        }
        if (dir == "South")
        {
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z - 12);
            player.transform.position = new Vector3(cam.transform.position.x, player.transform.position.y, cam.transform.position.z + 4);
        }
        if (dir == "West")
        {
            cam.transform.position = new Vector3(cam.transform.position.x - 22, cam.transform.position.y, cam.transform.position.z);
            player.transform.position = new Vector3(cam.transform.position.x + 9, player.transform.position.y, cam.transform.position.z);
        }
        if (dir == "East")
        {
            cam.transform.position = new Vector3(cam.transform.position.x + 22, cam.transform.position.y, cam.transform.position.z);
            player.transform.position = new Vector3(cam.transform.position.x - 9, player.transform.position.y, cam.transform.position.z);
        }
    }

    public void Update()
    {
        uiManager.UpdateUI();
    }
}
