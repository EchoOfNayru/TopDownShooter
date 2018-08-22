using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public bool enemyBullet;
    public bool playerBullet;

    public Vector3 direction;
    public float speed = .2f;
    public int damage;

    void FixedUpdate()
    {
        transform.position += direction * speed;
        transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (enemyBullet)
        {
            PlayerController player = collision.collider.GetComponent<PlayerController>();
            if (player != null)
            {
                player.health -= damage;
            }
            Destroy(gameObject);
        }
        if (playerBullet)
        {
            DamagableEnemy enemy = collision.collider.GetComponent<DamagableEnemy>();
            if (enemy != null)
            {
                enemy.health -= damage;
                enemy.Death();
            }
            Destroy(gameObject);
        }
    }
}
