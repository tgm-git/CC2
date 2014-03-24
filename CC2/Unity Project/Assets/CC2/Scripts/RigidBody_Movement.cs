using UnityEngine;
using System.Collections;

public class RigidBody_Movement : MonoBehaviour
{
    Vector3 MoveDir, direction, targetVelocity;
    Vector3 Jump = new Vector3(0, 200, 0);
    float speed = 8;
    float checkpoint;
    bool Grounded;

    bool jumping;
    private float jumpheigth = 3;
    private float startPos;
    float x;
    float y;

    Vector3 lastPosition;
    float minimumMovement = 0.05f;

    void Start()
    {
        checkpoint = Time.deltaTime;
    }

    void Update()
    {
        if (networkView.isMine && Grounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (Input.GetButtonDown("Jump"))
            {
                jumping = true;
                startPos = transform.position.y;
                x = -0.5F;
            }

            if (Vector3.Distance(transform.position, lastPosition) > minimumMovement)
            {
                lastPosition = transform.position;
                networkView.RPC("SetPosition", RPCMode.Others, transform.position);
            }
        }
        if (jumping == true)
        {
            x += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, -12 * (x * x) + 0 * x + (startPos + jumpheigth), transform.position.z);
        }
        //else
        //{
        //    transform.Translate((MoveDir * speed * Time.deltaTime));
        //    //transform.position = new Vector3(transform.position.x + (MoveDir.x * speed * Time.deltaTime), transform.position.y, transform.position.z + (MoveDir.z * speed * Time.deltaTime));
        //}
        transform.Translate((MoveDir * speed * Time.deltaTime));
    }

    [RPC]
    void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {

        if (stream.isWriting)
        {
            Vector3 myPosition = transform.position;
            stream.Serialize(ref myPosition);
        }

        else
        {
            Vector3 receivedPosition = Vector3.zero;
            stream.Serialize(ref receivedPosition);
            transform.position = receivedPosition;
        }
    }

    void OnCollisionStay()
    {
        Grounded = true;
        jumping = false;
    }

    void OnCollisionExit()
    {
        Grounded = false;
    }

    void Awake()
    {
        if (!networkView.isMine)
        {
            enabled = false;
        }
    }
}