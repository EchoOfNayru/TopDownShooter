using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    void Awake()
    {
        if (GameManager.instance.cam == null)
        {
            GameManager.instance.cam = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
