using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPool : MonoBehaviour {

    public int damage = 10;
    public PlayerController player;

    public int tick;
    public int tickMax = 10;

    void Start()
    {
        tick = tickMax;
    }

    public void Damage()
    {
        player.health -= damage;
    }

    void OnTriggerStay(Collider other)
    {
        player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            if (tick <= 0)
            {
                Damage();
                tick = tickMax;
            }
            else
            {
                tick--;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        tick = tickMax;
    }
}
