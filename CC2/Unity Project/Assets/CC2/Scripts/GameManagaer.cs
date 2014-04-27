using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagaer : MonoBehaviour {

    //Assigned in the inspector
    public Camera turnOffWhenSpawn;
    public GameObject redPlayer;    //Lokal version
    public GameObject bluePlayer;   //Lokal version
    public GameObject redClone;     //Ghost version
    public GameObject blueClone;    //Ghost version
    //En liste over alle spillere i spillet
    private List<GameObject> allPlayers = new List<GameObject>();
    private int[] playerScore = new int[1];
    //De forskellige spawnpoints
    private Transform[] redSpawnpoints;
    private Transform[] blueSpawnpoints;
    private int playingPlayers = 0;
    public class playerID
    {
        int ID = 0;
    }
    private List<playerID> playerIDs = new List<playerID>();

    private bool selectedTeam = false;

	void Start () 
    {
        //
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SpawnRed");
        redSpawnpoints = new Transform[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            redSpawnpoints[i] = objs[i].transform;
        }
        objs = GameObject.FindGameObjectsWithTag("SpawnBlue");
        blueSpawnpoints = new Transform[objs.Length];
        for (int i = 0; i < objs.Length; i++)
        {
            blueSpawnpoints[i] = objs[i].transform;
        }
	}
    void Update() 
    {
	    
	}
    void OnGUI()
    {
        if (selectedTeam == false)
        {
            //Spilleren har 2 muligheder til at starte med:
            // Spil på rødt hold eller blåt hold.
            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height / 2 - 25, 125, 50), "Spawn as RED"))
            {
                //Jeg disabler lige det kamera man ser tingene fra først, så det ikke ser dumt ud
                turnOffWhenSpawn.enabled = false;
                turnOffWhenSpawn.GetComponent<AudioListener>().enabled = false;
                //Spilleren har valgt rødt hold og nu spawner jeg en lokal version på et tilfældig rødt spawnpoint
                int random = Random.Range(0, redSpawnpoints.Length - 1);
                SpawnNewPlayerLocal(true, redSpawnpoints[random].position);
                selectedTeam = true;
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 10, Screen.height / 2 - 25, 125, 50), "Spawn as BLUE"))
            {
                //Jeg disabler lige det kamera man ser tingene fra først, så det ikke ser dumt ud
                turnOffWhenSpawn.enabled = false;
                turnOffWhenSpawn.GetComponent<AudioListener>().enabled = false;
                //Spilleren har valgt blåt hold og nu spawner jeg en lokal version på et tilfældig blåt spawnpoint
                int random = Random.Range(0, blueSpawnpoints.Length - 1);
                SpawnNewPlayerLocal(false, blueSpawnpoints[random].position);
                selectedTeam = true;
            }
        }
    }
    [RPC]
    public void SpawnNewPlayerClone(bool isRed, Vector3 spawnPoint)
    {
        

    }
    void SpawnNewPlayerLocal(bool isRed, Vector3 spawnPoint)
    {
        //Jeg spawner den lokale version.
        //Instantiate(isRed == true ? redPlayer : bluePlayer, spawnPoint, Quaternion.identity);
        //..Og jeg siger til alle andre på netværket end mig at de skal spawne en klon af den nye spiller.
        //Fordi jeg spawner en af de andre spillere, vil jeg gerne have styr på hvem de er. Derfor får der hver især 
        //et tal alt efter hvornår de kom ind i lobbyen.
        GameObject clone = Network.Instantiate(isRed == true ? redPlayer : bluePlayer, spawnPoint, Quaternion.identity, 0) as GameObject;
        allPlayers.Add(clone);
    }
    [RPC]
    public void TellPlayerID(int ID)
    {

    }
}
