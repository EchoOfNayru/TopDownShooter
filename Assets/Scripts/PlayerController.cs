using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 100;

    void Awake()
    {
        if (GameManager.instance.player == null)
        {
            GameManager.instance.player = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        transform.position = new Vector3(transform.position.x, .2f, transform.position.z);
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("happened");
        var thisCollider = GetComponent<Collider>();

        if (!thisCollider)
        {
            return;
        }

        var collider = collision.collider;

        Vector3 otherPosition = collider.gameObject.transform.position;
        Quaternion otherRotation = collider.gameObject.transform.rotation;

        Vector3 direction;
        float distance;

        bool overlapped = Physics.ComputePenetration(thisCollider, transform.position, transform.rotation, collider, otherPosition, otherRotation, out direction, out distance);

        if (overlapped)
        {
        transform.position += (direction * distance);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Gate gate;
        gate = other.GetComponent<Gate>();
        if (gate != null)
        {
            GameManager.instance.MoveRoom(gate.direction);
        }
    }
}
