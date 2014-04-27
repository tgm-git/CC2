using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
    private float health = 100;
    private float shield = 0;
    public float maxHealth = 100;
    public GameObject shieldPrefb;
    public GameObject shieldBurst;
    private GameObject shieldPrefab;
    private bool shielded = false;

    /// <summary>
    /// Redigerer helbredet på spilleren
    /// </summary>
    /// <param name="value">hvor meget du gerne vil redigere med</param>
    public void AdjustHealth(float value)
    {
        if (shield <= 0)
        {
            health += value;
        }
        else
        {
            shield += value;
        }
        networkView.RPC("AdjustHealthNetwork", RPCMode.Others, value);
    }
    [RPC]
    void AdjustHealthNetwork(float value)
    {
        if (shield <= 0)
        {
            health += value;
        }
        else
        {
            shield += value;
        }
    }
    public void AddShield(float value)
    {
        shield = value;
        if(shieldPrefab != null)
        {
            Destroy(shieldPrefab);
        }
        shieldPrefab = Network.Instantiate(shieldPrefb, transform.position, Quaternion.identity, 0) as GameObject;
        shieldPrefab.GetComponent<ShieldPosScript>().myPos = transform;
        shielded = true;
    }
    void Update()
    {
        //Hvis spilleren når under 0 helbreds point, dør spilleren og skal derfor vente på at blive respawnet.
        if(health <= 0)
        {
            //Death conditions
            
        }
        //Hvis spillerens skjold går tabt, spawn en effekt:
        if(shield <= 0 && shielded == true)
        {
            Network.Destroy(shieldPrefab);
            shieldPrefab = null;
            GameObject shieldEffect = Network.Instantiate(shieldBurst, transform.position, Quaternion.identity, 0) as GameObject;
            shieldEffect.GetComponent<ShieldPosScript>().myPos = transform;
            shielded = false;
        }
    }
    void OnGUI()
    {

    }
}
