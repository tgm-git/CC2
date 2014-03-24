using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    public float movespeed = 5;
    public float jumpHeight = 3;
    public float hangTime = -12;
    private Vector3 moveDirection;
    private bool canMove = true;
    private bool jumping = false;
    private bool grounded = false;
    //The x-value used in the jump parabola. (y = a*x^2+b*x+c=0) 
    //(tranform.position.y = hangTime * (x*x) + 0 * x + (transform.position.y + jumpHeight))
    //x should be the leftmost leg of the parabola.
    //...which is calculated with this formula: x = (-b - sqrt(b^2-4*a*c))/2*a)
    private float x = 0;

	void Update () 
    {
        //First we read the input of where the player wants to go.
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            x = -0.223f;//(0 - Mathf.Sqrt(-4 * hangTime * (transform.position.y + jumpHeight))) / 2 * hangTime;
        }
        if (jumping)
        {
            x += Time.deltaTime;
            if (x >= (0.223f) * 2)
            {
                jumping = false;
                return;
            }
            //Now in order to find the direction we wish to move vertically, we need to differantiate our parabola:
            //Vector3 upDir = new Vector3(0, hangTime * 2 * x, 0);
            //moveDirection += -upDir.normalized;
            transform.position = new Vector3(transform.position.x, hangTime * (x * x) + 0 * x + (transform.position.y + jumpHeight), transform.position.z);
            
        }

        //Then we apply the position to the player
        transform.Translate(moveDirection * movespeed * Time.deltaTime, Space.Self);
	}
    void OnCollisionEnter()
    {
        grounded = true;
        if (jumping == true)
        {
            jumping = false;
        }
    }
    void OnCollisionStay()
    {
        grounded = true;
    }
}
