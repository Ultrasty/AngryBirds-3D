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
        //Debug.Log(transform.position);
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
        GameManager._instance.pigs.Remove(this);
        Destroy(gameObject);
        var tempPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, tempPos, Quaternion.identity);
        Destroy(go, 1.5f);
    }
}
