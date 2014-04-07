using UnityEngine;
using System.Collections;

public class GravLift : MonoBehaviour 
{
    public float force = 10;
    void OnTriggerEnter(Collider intruder)
    {
        if (intruder.transform.tag == "Player")
        {
            intruder.rigidbody.velocity = Vector3.zero;
            Vector3 dir = transform.forward + (Vector3.up / 2);
            intruder.rigidbody.AddForce(dir.normalized * force, ForceMode.Impulse);
            audio.Play();
        }
    }
}
