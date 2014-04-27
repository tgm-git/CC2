using UnityEngine;
using System.Collections;

public class NetworkRotationInfo : MonoBehaviour {

	void Start () 
    {
	    if(Network.connections.Length > 0)
        {
            if(networkView.isMine)
            {
                networkView.RPC("newRot", RPCMode.Others, transform.rotation);
            }
        }
	}
    [RPC]
    void newRot(Quaternion newRot)
    {
        transform.rotation = newRot;
    }
}
