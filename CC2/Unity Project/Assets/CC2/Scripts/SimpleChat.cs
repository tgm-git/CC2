using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleChat : MonoBehaviour {

    public string[] messages = new string[8] { "", "", "", "", "", "", "", "" };
    private string messagesCombined;
    private string message = "";
    private string name = "";

	void Start () 
    {
        messagesCombined = "";
	    for(int i = 0; i < 8; i++)
        {
            messagesCombined += messages[i] + "\n";
        }
	}
    void RedoMessagesCombined()
    {
        messagesCombined = "";
        for (int i = 0; i < 8; i++)
        {
            messagesCombined += messages[i] + "\n";
        }
    }
    void OnGUI()
    {
        if (Event.current.keyCode == KeyCode.Return && message.Length > 0)
        {
            if (Network.connections.Length > 0)
            {
                //Multiplayer
                networkView.RPC("SendMessage", RPCMode.Others, name, message);
                SendMessage(name, message);
                message = "";
            }
            else
            {
                //Local
                SendMessage(name, message);
                message = "";
            }
        }
        name = GUI.TextField(new Rect(50, Screen.height - 70, 300, 20), name, 10);
        message = GUI.TextField(new Rect(50, Screen.height - 50, 300, 20), message, 30 + (10 - name.Length));
        GUI.TextArea(new Rect(50, Screen.height - 205, 300, 135), messagesCombined);
    }
    [RPC]
    public void SendMessage(string playerName, string message)
    {
        string[] oldMessages = messages;
        for(int i = 0; i < messages.Length -1; i++)
        {
            messages[i] = oldMessages[i + 1];
        }
        messages[messages.Length- 1] = playerName + ": " + message;
        RedoMessagesCombined();
    }
}
