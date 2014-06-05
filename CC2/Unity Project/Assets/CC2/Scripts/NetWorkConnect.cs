using UnityEngine;
using System.Collections;

public class NetWorkConnect : MonoBehaviour
{

    public string connectIP = "127.0.01";
    public int connectPort = 25001;

    private string status;

    private bool connectedBo = false;

    public GameObject player;
    public GameObject spawnpoint;

    void OnGUI()
    {

        GUI.Label(new Rect(10, 10, 200, 20), "Status: " + status);

        if (Network.peerType == NetworkPeerType.Disconnected)
        {
            status = "Disconnected";
            connectedBo = false;
        }

        if (Network.peerType == NetworkPeerType.Server)
        {
            status = "Server";
            connectedBo = true;
        }

        if (GUI.Button(new Rect(10, 30, 120, 20), "Client Connect"))
        {
            Network.Connect(connectIP, connectPort);
        }

        connectIP = GUI.TextField(new Rect(130, 30, 120, 20), connectIP);
        try {
            connectPort = int.Parse(GUI.TextField(new Rect(130, 55, 120, 20), connectPort.ToString()));
        }catch{
            connectPort = 25001;
        }
        

        if (GUI.Button(new Rect(10, 55, 120, 20), "Initialize Server"))
        {
            Network.InitializeServer(32, connectPort, false);
        }
        else if (Network.peerType == NetworkPeerType.Client)
        {
            status = "Connected as Client";
            connectedBo = true;
        }

        if (connectedBo == true)
        {

            if (GUI.Button(new Rect(10, 80, 120, 20), "Join Game"))
            {
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(10, 105, 120, 20), "Disconnect"))
            {
                Network.Disconnect(200);
            }
        }
    }
}
