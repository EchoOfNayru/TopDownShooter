using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableEnemy : MonoBehaviour {

    [Header ("Damagable Enemy")]
    public int health;

    public void Death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
