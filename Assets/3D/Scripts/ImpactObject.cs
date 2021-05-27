using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactObject : MonoBehaviour
{
    public float maxSpeed;
    public GameObject boom;
    public AudioClip impacted;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            disappear();
        }
    }
    void disappear()
    {
        AudioPlay(impacted);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
    }

    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}
