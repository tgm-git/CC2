using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

    public Texture2D crosshair;
    public GameObject impactEffect;
    public GameObject weaponAni;
    public LineRenderer line;
    public float fireRate = 0.5f;
    private float fireTimer = 0;
    [System.NonSerialized]
    public bool weaponUp = false;
    private Transform mainCam;
    public float acurracy = 0.02f;
    public float cameraShakeAmount = 0.1f;

	void Start () 
    {
        //Hide and lock the mouse cursor
        Screen.lockCursor = true;
        Screen.showCursor = false;
        mainCam = Camera.main.transform;
	}
	void Update () 
    {
        //We check for the player input
        //Check if the player presses the melee button:
        if(Input.GetKeyDown(KeyCode.F))
        {
            weaponAni.animation.CrossFade("weaponMelee");
        }
        //Then we check for the fire input
	    else if(Input.GetKey(KeyCode.Mouse0))
        {
            if (weaponUp == false && !weaponAni.animation.IsPlaying("weaponMelee"))
            {
                //here we check if the in-game time has surpassed the timeframe where the next bullet is ready
                if (fireTimer <= Time.timeSinceLevelLoad)
                {
                    //Check if the player is in the progress of lowering his weapon. If he is, don't shoot.
                    if (weaponAni.animation.IsPlaying("weaponDown") == false)
                    {
                        //FIRE EVERYTHING!
                        //Here we fire out a ray from the centerpoint of the screen with the direction
                        //of the cameras local z-axis
                        RaycastHit hit;
                        Ray ray = mainCam.camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                        //make the direction of the ray a bit random to get some acurracy
                        ray.direction += new Vector3(Random.Range(-acurracy, acurracy), Random.Range(-acurracy, acurracy), 0);
                        if (Physics.Raycast(ray, out hit))
                        {
                            //Then we do an effect that looks like the bullet's travelling
                            line.SetPosition(0, mainCam.transform.position + (mainCam.transform.forward * (Vector3.Distance(mainCam.transform.position, hit.point) / 1.9f)));
                            line.SetPosition(1, hit.point);
                            line.animation.Play();
                            //Then we instantiate a hit effect
                            GameObject clone = Instantiate(impactEffect, hit.point, Quaternion.identity) as GameObject;
                            clone.transform.LookAt(hit.point + hit.normal);
                            //AND shake the camera.
                            Hashtable wrd1 = new Hashtable();
                            wrd1.Add("amount", new Vector3(0.5f, 0.5f, 0) * cameraShakeAmount);
                            wrd1.Add("isLocal", true);
                            wrd1.Add("time", 0.2f);
                            iTween.ShakePosition(mainCam.gameObject, wrd1);
                        }
                        //Then we animate some recoil on the weaponmesh
                        if (weaponAni.animation.IsPlaying("weaponRecoil") == false)
                        {
                            weaponAni.animation.Play("weaponRecoil");
                        }
                        //And at last we set the timer to be the next timeframe where we need to fire 
                        //our next bullet.
                        fireTimer = Time.timeSinceLevelLoad + fireRate;
                    }
                }
            }
        }
        //Check if the animations weaponIdle and weaponDown is playing. If they arent start playing the idle animation
        else if (weaponAni.animation.IsPlaying("weaponIdle") == false && weaponUp == false && weaponAni.animation.IsPlaying("weaponDown") == false && !weaponAni.animation.IsPlaying("weaponMelee"))
        {
            if (weaponAni.animation.IsPlaying("weaponWalk") == false)
            {
                //Play the Idle animation
                weaponAni.animation.Play("weaponIdle");
            }
        }
        //This is the section where we check if the player is too close to a wall.
        //First we send out a ray from the camera.
        RaycastHit hit2;
        Ray ray2 = mainCam.camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray2, out hit2) && weaponAni.animation.IsPlaying("weaponMelee") == false)
        {
            //Here we check is the player already is close to a wall. If he is, raise the weapon, if he's not lower the weapon
            if (weaponUp == false)
            {
                if (Vector3.Distance(mainCam.transform.position, hit2.point) <= 2)
                {
                    weaponAni.animation.Play("weaponUp");
                    weaponUp = true;
                }
            }
            else
            {
                if (Vector3.Distance(mainCam.transform.position, hit2.point) > 2)
                {
                    weaponAni.animation.CrossFade("weaponDown");
                    weaponUp = false;
                }
            }
        }
	}
    void OnGUI()
    {
        //Draw the crosshair
        GUI.DrawTexture(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 25, 50, 50), crosshair);
    }
}
