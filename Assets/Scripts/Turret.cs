using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawn;

    PlayerController player;

    int shootTimer;
    public int shootTimerMax = 20;

    void Start()
    {
        player = GameManager.instance.player;
        shootTimer = shootTimerMax;
    }

    void Update()
    {
        Vector3 lookPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(lookPos);
    }

    void FixedUpdate()
    {
        if (shootTimer <= 0)
        {
            Shoot();
            shootTimer = shootTimerMax;
        }
        else
        {
            shootTimer--;
        }
    }

    void Shoot()
    {
        GameObject thisBullet =  Instantiate(bullet);
        thisBullet.transform.position = bulletSpawn.transform.position;
        thisBullet.GetComponent<Bullet>().direction = bulletSpawn.transform.position - player.transform.position;
    }
}
