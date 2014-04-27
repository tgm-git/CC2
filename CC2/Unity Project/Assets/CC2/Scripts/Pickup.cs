using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour 
{
    public float shieldAmount = 200;
    public float respawnTime = 40;

    void OnTriggerEnter(Collider intruder)
    {
        if (intruder.tag == "Player" || intruder.tag == "Red" || intruder.tag == "Blue")
        {
            if (Network.isServer)
            {
                intruder.GetComponent<Health>().AddShield(shieldAmount);
                audio.Play();
                renderer.enabled = false;
                collider.enabled = false;
                light.enabled = false;
                networkView.RPC("Despawn", RPCMode.Others);
                StartCoroutine(Respawn(respawnTime));
            }
        }
    }
    IEnumerator Respawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        renderer.enabled = true;
        collider.enabled = true;
        light.enabled = true;
        networkView.RPC("Spawn", RPCMode.Others);
    }
    [RPC]
    void Spawn()
    {
        renderer.enabled = true;
        collider.enabled = true;
        light.enabled = true;
    }
    [RPC]
    void Despawn()
    {
        audio.Play();
        renderer.enabled = false;
        collider.enabled = false;
        light.enabled = false;
    }
}
