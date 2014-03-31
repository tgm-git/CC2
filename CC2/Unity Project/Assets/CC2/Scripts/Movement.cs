using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    [System.Serializable]
    public class CrouchVars
    {
        public float crouchMovespeed = 2;
    }
    public float movespeed = 5;
    private float actualMovespeed = 5;
    private float jumpHeight = 3;
    private float hangTime = -12;
    private Vector3 moveDirection;
    private bool canMove = true;
    private bool jumping = false;
    private bool grounded = false;
    private bool crouched = false;
    public float jumpForce = 2;
    private float startPos = 0;
    public CrouchVars crouchvars = new CrouchVars();
    private GameObject mainCam;

    void Start()
    {
        mainCam = Camera.main.gameObject;
        actualMovespeed = movespeed;
    }
	void Update () 
    {
        //First we read the input of where the player wants to go.
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Then we check if the player wants to jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            //Add the jumpforce to the players rigidbody
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        //Then we apply the position to the player
        transform.Translate(moveDirection * actualMovespeed * Time.deltaTime, Space.Self);

        #region crouch mechanic
        if (Input.GetKeyDown(KeyCode.C))
        {
            crouched = !crouched;
            if (crouched)
            {
                actualMovespeed = crouchvars.crouchMovespeed;
                mainCam.animation.Play("CameraCrouchDown");
            }
            else
            {
                actualMovespeed = movespeed;
                mainCam.animation.Play("CameraCrouchUp");
            }
            
        }
        #endregion
    }
    void OnCollisionEnter()
    {
        grounded = true;
        if (jumping == true)
        {
            jumping = false;
        }
    }
    void OnCollisionExit()
    {
        grounded = false;
    }
    void OnCollisionStay()
    {
        grounded = true;
    }
}
static class Global
{
    public static int[] cutsomGun = new int[5] { 0, 0, 0, 0, 0 };
}
