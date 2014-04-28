using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
    public Texture2D healthTex;
    public Texture2D shieldTex;
    public Texture2D healthBG;
    private float health = 100;
    private float shield = 0;
    public float maxShield = 200;
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
    [RPC]
    void AddShieldNetwork(float value)
    {
        shield = value;
        shielded = true;
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
        networkView.RPC("AddShieldNetwork", RPCMode.Others, value);
        shielded = true; 
    }
    void Update()
    {
        //Hvis spilleren når under 0 helbreds point, dør spilleren og skal derfor vente på at blive respawnet.
        if(health <= 0 && networkView.isMine)
        {
            //Death conditions
            if(shieldPrefab != null)
            {
                Network.Destroy(shieldPrefab);
            }
            GameManagaer manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagaer>();
            manager.KillPlayer(gameObject, Network.player, name.Contains("Red") == true ? true : false);
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
        if(networkView.isMine == false)
        {
            if (Camera.main != null)
            {
                Vector3 pos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z));
                GUI.DrawTexture(new Rect(pos.x - 52, Screen.height - pos.y - 12, 104, 14), healthBG);
                GUI.DrawTexture(new Rect(pos.x - 50, Screen.height - pos.y - 10, health, 10), healthTex);
                GUI.DrawTexture(new Rect(pos.x - 52, Screen.height - pos.y - 22, 104, 14), healthBG);
                GUI.DrawTexture(new Rect(pos.x - 50, Screen.height - pos.y - 20, (shield / maxShield) * 100, 10), shieldTex);
            }
        }
    }
}
