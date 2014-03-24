using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    public float movespeed = 5;
    private float jumpHeight = 3;
    private float hangTime = -12;
    private Vector3 moveDirection;
    private bool canMove = true;
    private bool jumping = false;
    private bool grounded = false;
    private float startPos = 0;
    //The x-value used in the jump parabola. (y = a*x^2+b*x+c=0) 
    //(tranform.position.y = hangTime * (x*x) + 0 * x + (transform.position.y + jumpHeight))
    //x should be the leftmost leg of the parabola.
    //...which is calculated with this formula: x = (-b - sqrt(b^2-4*a*c))/2*a)
    private float x = 0;
    private float D = 0;

    void Start()
    {
        D = (0 * 0) - (4 * hangTime * jumpHeight);
    }
	void Update () 
    {
        //First we read the input of where the player wants to go.
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            startPos = transform.position.y;
            x = -((-0 - Mathf.Sqrt(D)) / (2 * (hangTime)));
            Debug.Log(x);
        }
        if (jumping || grounded == false)
        {
            x += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, hangTime * (x * x) + 0 * x + (startPos + jumpHeight), transform.position.z);
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
