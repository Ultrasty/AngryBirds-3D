using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactObject : MonoBehaviour
{
    public float maxSpeed;
    public GameObject boom;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            disappear();
        }
    }
    void disappear()
    {
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
    }
}
