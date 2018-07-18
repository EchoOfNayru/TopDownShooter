using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public bool North, South, East, West; //which gates are open
    public Gate N, S, E, W;

    void Start()
    {
        if (!North)
        {
            N.gameObject.SetActive(false);
        }
        if (!South)
        {
            S.gameObject.SetActive(false);
        }
        if (!East)
        {
            E.gameObject.SetActive(false);
        }
        if (!West)
        {
            W.gameObject.SetActive(false);
        }
    }

}
