using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public int health = 100;
    public int maxHealth = 100;

    public int damage = 2;

    public GameObject bullet;

    [Header("Multiple Guns")]
    public Gun[] guns = new Gun[4];
    public Transform[] bulletSpawns = new Transform[4];

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

    void Update()
    {
        Shoot();
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

        Ray ray = GameManager.instance.cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            hit.point = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(hit.point);
        }
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

    void Shoot()
    {
        Ray ray = GameManager.instance.cam.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            hit.point = new Vector3(hit.point.x, 0.2f, hit.point.z);
            Debug.DrawLine(transform.position, hit.point);

            GameObject thisBullet = Instantiate(bullet);
            thisBullet.transform.position = transform.position;
            thisBullet.GetComponent<Bullet>().direction = Vector3.Normalize(hit.point - transform.position);
            thisBullet.GetComponent<Bullet>().damage = damage;
            thisBullet.transform.LookAt(hit.point);
        }
    }
}
