using UnityEngine;
using System.Collections;

public class Custom : MonoBehaviour
{

    [System.NonSerialized]
    public GameObject renderBarrel;
    [System.NonSerialized]
    public GameObject renderSight;
    [System.NonSerialized]
    public GameObject renderMag;
    [System.NonSerialized]
    public GameObject renderUnder;

    //variables
    int buttonHeight = 50;
    int buttonWidth = 150;

    float height0 = Screen.height * 0.32F;
    float height1 = Screen.height * 0.4F;
    float height2 = Screen.height * 0.46F;
    float height3 = Screen.height * 0.52F;
    float height4 = Screen.height * 0.58F;

    int widthLeft = Screen.width / 6;
    int widthMid = Screen.width / 4;
    int widthRight = Screen.width / 3;

    //Assign in inspector
    public GameObject Mag1;
    public GameObject Mag2;
    public GameObject Mag3;

    public GameObject Barrel1;
    public GameObject Barrel2;
    public GameObject Barrel3;

    public GameObject Sight1;
    public GameObject Sight2;
    public GameObject Sight3;

    public GameObject Under1;
    public GameObject Under2;
    public GameObject Under3;
    //End of "Assing inspector"

    //Ints designate which part is to be rendered
    int intBarrel = 0;
    int intMag = 0;
    int intSight = 0;
    int intUnder = 0;
    int intGun = 0;
	
	// Update is called once per frame
    void Start() {

        Under1.renderer.enabled = false;
        Under2.renderer.enabled = false;
        Under3.renderer.enabled = false;

        Barrel1.renderer.enabled = false;
        Barrel2.renderer.enabled = false;
        Barrel3.renderer.enabled = false;

        Mag1.renderer.enabled = false;
        Mag2.renderer.enabled = false;
        Mag3.renderer.enabled = false;
            
        Sight1.renderer.enabled = false;
        Sight2.renderer.enabled = false;
        Sight3.renderer.enabled = false;

    }

	void Update () {

        renderBarrel.renderer.enabled = true;
        renderSight.renderer.enabled = true;
        renderMag.renderer.enabled = true;
        renderUnder.renderer.enabled = true;

        switch(intBarrel){
            case 0:
                renderBarrel = Barrel1;
                break;

            case 1:
                renderBarrel = Barrel2;
                break;

            case 2:
                renderBarrel = Barrel3;
                break;

            default:
                renderBarrel = Barrel1;
                break;
        }

        switch (intMag)
        {
            case 0:
                renderMag = Mag1;
                break;

            case 1:
                renderMag = Mag2;
                break;

            case 2:
                renderMag = Mag3;
                break;

            default:
                renderMag = Mag1;
                break;
        }

        switch (intSight)
        {
            case 0:
                renderSight = Sight1;
                break;

            case 1:
                renderSight = Sight2;
                break;

            case 2:
                renderSight = Sight3;
                break;

            default:
                renderSight = Sight1;
                break;
        }

        switch (intUnder)
        {
            case 0:
                renderUnder = Under1;
                break;

            case 1:
                renderUnder = Under2;
                break;

            case 2:
                renderUnder = Under3;
                break;

            default:
                renderUnder = Under1;
                break;
        }
	
	}

    void OnGUI () { 

        //Guns
        if (GUI.Button(new Rect(widthLeft, height0, buttonWidth, buttonHeight), "CR"))
        {
            intGun = 0;
        }

        if (GUI.Button(new Rect(widthMid, height0, buttonWidth, buttonHeight), "AR"))
        {
            intGun = 2;
        }

        //Barrel
        if (GUI.Button(new Rect(widthLeft, height1, buttonWidth, buttonHeight), "Barrel 1"))
        {
            intBarrel = 0;
        }

        if (GUI.Button(new Rect(widthMid, height1, buttonWidth, buttonHeight), "Barrel 2"))
        {
            intBarrel = 1;
        }

        if (GUI.Button(new Rect(widthRight, height1, buttonWidth, buttonHeight), "Barrel 3"))
        {
            intBarrel = 2;
        }

        //Sight
        if (GUI.Button(new Rect(widthLeft, height2, buttonWidth, buttonHeight), "Sight 1"))
        {
            intSight = 0;
        }

        if (GUI.Button(new Rect(widthMid, height2, buttonWidth, buttonHeight), "Sight 2"))
        {
            intSight = 1;
        }

        if (GUI.Button(new Rect(widthRight, height2, buttonWidth, buttonHeight), "Sight 3"))
        {
            intSight = 2;
        }

        //Mag
        if (GUI.Button(new Rect(widthLeft, height3, buttonWidth, buttonHeight), "Mag 1"))
        {
            intMag = 0;
        }

        if (GUI.Button(new Rect(widthMid, height3, buttonWidth, buttonHeight), "Mag 2"))
        {
            intMag = 1;
        }

        if (GUI.Button(new Rect(widthRight, height3, buttonWidth, buttonHeight), "Mag 3"))
        {
            intMag = 2;
        }

        //Under
        if (GUI.Button(new Rect(widthLeft, height4, buttonWidth, buttonHeight), "Under 1"))
        {
            intUnder = 0;
        }

        if (GUI.Button(new Rect(widthMid, height4, buttonWidth, buttonHeight), "Under 2"))
        {
            intUnder = 1;
        }

        if (GUI.Button(new Rect(widthRight, height4, buttonWidth, buttonHeight), "Under 3"))
        {
            intUnder = 2;
        }
    }
}
