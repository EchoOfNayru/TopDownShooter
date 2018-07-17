using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPenetration : MonoBehaviour {

    public float radius = 3f;
    public int maxNeighbors = 16;

    private Collider[] neighbors;

    public void Start()
    {
        neighbors = new Collider[maxNeighbors];
    }

    public void OnDrawGizmos()
    {
        var thisCollider = GetComponent<Collider>();

        if (!thisCollider)
        {
            return;
        }

        int count = Physics.OverlapSphereNonAlloc(transform.position, radius, neighbors);

        for (int i = 0; i < count; ++i)
        {
            var collider = neighbors[i];

            if (collider == thisCollider)
            {
                continue;
            }

            Vector3 otherPosition = collider.gameObject.transform.position;
            Quaternion otherRotation = collider.gameObject.transform.rotation;

            Vector3 direction;
            float distance;

            bool overlapped = Physics.ComputePenetration(thisCollider, transform.position, transform.rotation, collider, otherPosition, otherRotation, out direction, out distance);

            if (overlapped)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(otherPosition, -direction * distance);
            }
        }
    }
}
