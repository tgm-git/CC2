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
    public float sprintSpeed = 10;
    private float actualMovespeed = 5;
    private Vector3 moveDirection;
    private bool canMove = true;
    private bool jumping = false;
    private bool grounded = false;
    private bool crouched = false;
    public float jumpForce = 2;
    public CrouchVars crouchvars = new CrouchVars();
    private GameObject mainCam;
    public Animation weaponAni;
    public Animation cameraAni;
    public float walkAniSpeed = 0.8f;
    private ShootScript shootScript;
    [System.NonSerialized]
    public bool sprinting = false;

    void Start()
    {
        shootScript = gameObject.GetComponent<ShootScript>();
        weaponAni["weaponWalk"].speed = walkAniSpeed;
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && grounded == true)
        {
            sprinting = true;
            actualMovespeed = sprintSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && grounded == true)
        {
            sprinting = false;
            actualMovespeed = movespeed;
        }
        //Then we apply the position to the player
        transform.Translate(moveDirection * actualMovespeed * Time.deltaTime, Space.Self);
        #region animation
        //Walk animation
        if(moveDirection.magnitude > 0)
        {
            if (sprinting == false)
            {
                if (!weaponAni.IsPlaying("weaponSprint") && !weaponAni.IsPlaying("weaponRecoil") && !weaponAni.IsPlaying("weaponWalk") && !weaponAni.IsPlaying("weaponDown") && !shootScript.weaponUp && !weaponAni.IsPlaying("weaponMelee"))
                {
                    weaponAni.CrossFade("weaponWalk");
                }
                if (!cameraAni.IsPlaying("CameraWalk"))
                {
                    cameraAni.CrossFade("CameraWalk");
                }
            }
            else if (sprinting == true)
            {
                if (!weaponAni.IsPlaying("weaponMelee"))
                {
                    weaponAni.CrossFade("weaponSprint", 0.3f);
                    cameraAni.CrossFade("CameraSprint", 0.3f);
                }
            }
        }
        else if(moveDirection.magnitude <= 0)
        {
            if (weaponAni.IsPlaying("weaponWalk") && weaponAni.IsPlaying("weaponJumpInAir") == false && !weaponAni.IsPlaying("weaponMelee"))
            {
                weaponAni.CrossFade("weaponIdle");
            }
            if(cameraAni.IsPlaying("CameraWalk") == true)
            {
                cameraAni.CrossFade("CameraIdle");
            }
        }
        //In air stuff
        if(grounded == false)
        {
            sprinting = false;
            actualMovespeed = movespeed;
        }
        #endregion

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
