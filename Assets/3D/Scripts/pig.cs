using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pig : MonoBehaviour
{
    public float maxSpeed;
    public GameObject boom;
    public GameObject score;

    private void Update()
    {
        Debug.Log(transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
        }
    }
    void Dead()
    {
        Destroy(gameObject);
        var tempPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, tempPos, Quaternion.identity);
    }
}
