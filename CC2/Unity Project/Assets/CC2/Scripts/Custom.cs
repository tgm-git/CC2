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

    float width1 = Screen.width / 6;
    float width2 = Screen.width / 4;
    float width3 = Screen.width / 3;
    float width4 = Screen.width / 2.4F;

    //Assign in inspector
    #region GameObjects
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
    #endregion

    //Ints designate which part is to be rendered
    int intBarrel = 0;
    int intMag = 0;
    int intSight = 0;
    int intUnder = 0;
    int intGun = 0;
	
	// Update is called once per frame
    void Start() {

        //Derender alle objecter
        #region Derender
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
        #endregion

        //dafaulting which objects to render to make sure there is a object to render
        renderBarrel = Barrel1;
        renderSight = Sight1;
        renderMag = Mag1;
        renderUnder = Under1;
        
    }

	void Update () {

        //Switch statments som afhænger af nogle intergers længere oppe
        #region switches
        switch (intBarrel){
            case 0:
                renderBarrel = Barrel1;
                Derender();
                break;

            case 1:
                renderBarrel = Barrel2;
                Derender();
                break;

            case 2:
                renderBarrel = Barrel3;
                Derender();
                break;

            case 3:
                renderBarrel.renderer.enabled = false;
                Derender();
                break;

            default:
                renderBarrel = Barrel1;
                Derender();
                break;
        }

        switch (intMag)
        {
            case 0:
                renderMag = Mag1;
                Derender();
                break;

            case 1:
                renderMag = Mag2;
                Derender();
                break;

            case 2:
                renderMag = Mag3;
                Derender();
                break;

            case 3:
                renderMag.renderer.enabled = false;
                Derender();
                break;

            default:
                renderMag = Mag1;
                Derender();
                break;
        }

        switch (intSight)
        {
            case 0:
                renderSight = Sight1;
                Derender();
                break;

            case 1:
                renderSight = Sight2;
                Derender();
                break;

            case 2:
                renderSight = Sight3;
                Derender();
                break;

            case 3:
                renderSight.renderer.enabled = false;
                Derender();
                break;

            default:
                renderSight = Sight1;
                Derender();
                break;
        }

        switch (intUnder)
        {
            case 0:
                renderUnder = Under1;
                Derender();
                break;

            case 1:
                renderUnder = Under2;
                Derender();
                break;

            case 2:
                renderUnder = Under3;
                Derender();
                break;

            case 3:
                renderUnder.renderer.enabled = false;
                Derender();
                break;

            default:
                renderUnder = Under1;
                Derender();
                break;
        }
        #endregion



    }

    void OnGUI () { 

        //Guns
        if (GUI.Button(new Rect(width1, height0, buttonWidth, buttonHeight), "CR"))
        {
            intGun = 0;
        }

        if (GUI.Button(new Rect(width2, height0, buttonWidth, buttonHeight), "AR"))
        {
            intGun = 2;
        }

        //all buttons for the attachments
        #region Attachment Buttons

        //Barrel
        #region
        if (GUI.Button(new Rect(width1, height1, buttonWidth, buttonHeight), "Barrel 1"))
        {
            intBarrel = 0;
        }

        if (GUI.Button(new Rect(width1, height2, buttonWidth, buttonHeight), "Barrel 2"))
        {
            intBarrel = 1;
        }

        if (GUI.Button(new Rect(width1, height3, buttonWidth, buttonHeight), "Barrel 3"))
        {
            intBarrel = 2;
        }

        if (GUI.Button(new Rect(width1, height4, buttonWidth, buttonHeight), "None"))
        {
            intBarrel = 3;
        }
        #endregion

        //Sight
        #region
        if (GUI.Button(new Rect(width2, height1, buttonWidth, buttonHeight), "Sight 1"))
        {
            intSight = 0;
        }

        if (GUI.Button(new Rect(width2, height2, buttonWidth, buttonHeight), "Sight 2"))
        {
            intSight = 1;
        }

        if (GUI.Button(new Rect(width2, height3, buttonWidth, buttonHeight), "Sight 3"))
        {
            intSight = 2;
        }

        if (GUI.Button(new Rect(width2, height4, buttonWidth, buttonHeight), "None"))
        {
            intSight = 3;
        }
        #endregion

        //Mag
        #region
        if (GUI.Button(new Rect(width3, height1, buttonWidth, buttonHeight), "Mag 1"))
        {
            intMag = 0;
        }

        if (GUI.Button(new Rect(width3, height2, buttonWidth, buttonHeight), "Mag 2"))
        {
            intMag = 1;
        }

        if (GUI.Button(new Rect(width3, height3, buttonWidth, buttonHeight), "Mag 3"))
        {
            intMag = 2;
        }

        if (GUI.Button(new Rect(width3, height4, buttonWidth, buttonHeight), "None"))
        {
            intMag = 4;
        }
        #endregion

        //Under
        #region
        if (GUI.Button(new Rect(width4, height1, buttonWidth, buttonHeight), "Under 1"))
        {
            intUnder = 0;
        }

        if (GUI.Button(new Rect(width4, height2, buttonWidth, buttonHeight), "Under 2"))
        {
            intUnder = 1;
        }

        if (GUI.Button(new Rect(width4, height3, buttonWidth, buttonHeight), "Under 3"))
        {
            intUnder = 2;
        }

        if (GUI.Button(new Rect(width4, height4, buttonWidth, buttonHeight), "None"))
        {
            intUnder = 3;
        }
        #endregion

        #endregion
    }

    void Derender() 
    {
        //Derender alle objecter
        #region Derender
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
        #endregion

        //renderer de korrekte objekter hele tiden
        renderBarrel.renderer.enabled = true;
        renderSight.renderer.enabled = true;
        renderMag.renderer.enabled = true;
        renderUnder.renderer.enabled = true;
    }
}
