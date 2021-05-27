using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed;
    public GameObject boom;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > maxSpeed)
        {
            Destroy(transform.gameObject);
            Instantiate(boom, transform.position, Quaternion.identity);
        }
    }
}
