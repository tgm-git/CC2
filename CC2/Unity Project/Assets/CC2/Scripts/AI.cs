using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    private GameObject target;
    public float speed = 4;
    public float stopRange = 5;
    public float turnSpeed = 2;

    public float animationSpeedRun = 0.5f;
	// Use this for initialization
	void Start () 
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animation["Walk"].speed = animationSpeedRun;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Vector3.Distance(transform.position, target.transform.position) > stopRange)
        {
	        //Simply move towards the target
            Vector3 direction = target.transform.position;
            direction = transform.position - target.transform.position;

            transform.Translate(-direction.normalized * speed, Space.World);
            float angle = (-transform.right.x * direction.x + 
                            -transform.right.y * direction.y + 
                            -transform.right.z * direction.z) / (transform.forward.magnitude * direction.magnitude);
            transform.Rotate(Vector3.up, angle * turnSpeed);
            
            animation.CrossFade("Walk");
        }
        else
        {
            animation.CrossFade("Idle");
        }
	}
}
