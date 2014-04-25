using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagaer : MonoBehaviour {

    //Assigned in the inspector
    public GameObject redPlayer;
    public GameObject bluePlayer;
    //En liste over alle spillere i spillet
    private List<GameObject> allPlayers = new List<GameObject>();
    //
    private int[,] playerScore = new int[1, 1];
    //De forskellige spawnpoints
    private Transform[] redSpawnpoints;
    private Transform[] blueSpawnpoints;

	void Start () 
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("RedSpawn");
        for (int i = 0; i < objs.Length; i++)
        {
            redSpawnpoints[i] = objs[i].transform;
        }
        objs = GameObject.FindGameObjectsWithTag("BlueSpawn");
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

    }
}
