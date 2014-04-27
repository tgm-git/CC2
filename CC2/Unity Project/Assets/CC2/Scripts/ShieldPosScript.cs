using UnityEngine;
using System.Collections;

public class ShieldPosScript : MonoBehaviour 
{
    public Transform myPos;
    private Transform myTrans;
    private Vector3 oldPos = Vector3.zero;

    void Start()
    {
        myTrans = transform;
    }
    void Update()
    {
        myTrans.position = myPos.position;
        if(Vector3.Distance(transform.position, oldPos) >= 0.02f)
        {
            networkView.RPC("UpdatePos", RPCMode.Others, transform.position);
            oldPos = transform.position;
        }
    }
    [RPC]
    void UpdatePos (Vector3 newPos)
    {
        transform.position = newPos;
    }
}
