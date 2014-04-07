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

	
	// Update is called once per frame
    void Start() {

        //Default Attachments
        renderBarrel = Barrel1;
        renderMag = Mag1;
        renderSight = Sight1;
        renderUnder = Under1;

        //Derender alle objecter
        Derender();
        
    }

    void OnGUI () { 

        //Guns
        if (GUI.Button(new Rect(width1, height0, buttonWidth, buttonHeight), "CR"))
        {
            //render gun
            Derender();
        }

        if (GUI.Button(new Rect(width2, height0, buttonWidth, buttonHeight), "AR"))
        {
            //render gun
            Derender();
        }

        if (GUI.Button(new Rect(width3, height0, buttonWidth, buttonHeight), "Exit to Menu"))
        {
            Application.LoadLevel("LobbyScene");
        }

        //all buttons for the attachments
        #region Attachment Buttons

        //Barrel
        #region
        if (GUI.Button(new Rect(width1, height1, buttonWidth, buttonHeight), "Barrel 1"))
        {
            renderBarrel = Barrel1;
            Derender();
        }

        if (GUI.Button(new Rect(width1, height2, buttonWidth, buttonHeight), "Barrel 2"))
        {
            renderBarrel = Barrel2;
            Derender();
        }

        if (GUI.Button(new Rect(width1, height3, buttonWidth, buttonHeight), "Barrel 3"))
        {
            renderBarrel = Barrel3;
            Derender();
        }

        if (GUI.Button(new Rect(width1, height4, buttonWidth, buttonHeight), "None"))
        {
            renderBarrel = null;
            Derender();
        }
        #endregion

        //Sight
        #region
        if (GUI.Button(new Rect(width2, height1, buttonWidth, buttonHeight), "Sight 1"))
        {
            renderSight = Sight1;
            Derender();
        }

        if (GUI.Button(new Rect(width2, height2, buttonWidth, buttonHeight), "Sight 2"))
        {
            renderSight = Sight2;
            Derender();
        }

        if (GUI.Button(new Rect(width2, height3, buttonWidth, buttonHeight), "Sight 3"))
        {
            renderSight = Sight3;
            Derender();
        }

        if (GUI.Button(new Rect(width2, height4, buttonWidth, buttonHeight), "None"))
        {
            renderSight = null;
            Derender();
        }
        #endregion

        //Mag
        #region
        if (GUI.Button(new Rect(width3, height1, buttonWidth, buttonHeight), "Mag 1"))
        {
            renderMag = Mag1;
            Derender();
        }

        if (GUI.Button(new Rect(width3, height2, buttonWidth, buttonHeight), "Mag 2"))
        {
            renderMag = Mag2;
            Derender();
        }

        if (GUI.Button(new Rect(width3, height3, buttonWidth, buttonHeight), "Mag 3"))
        {
            renderMag = Mag3;
            Derender();
        }

        if (GUI.Button(new Rect(width3, height4, buttonWidth, buttonHeight), "None"))
        {
            renderMag = null;
            Derender();
        }
        #endregion

        //Under
        #region
        if (GUI.Button(new Rect(width4, height1, buttonWidth, buttonHeight), "Under 1"))
        {
            renderUnder = Under1;
            Derender();

        }

        if (GUI.Button(new Rect(width4, height2, buttonWidth, buttonHeight), "Under 2"))
        {
            renderUnder = Under2;
            Derender();
        }

        if (GUI.Button(new Rect(width4, height3, buttonWidth, buttonHeight), "Under 3"))
        {
            renderUnder = Under3;
            Derender();
        }

        if (GUI.Button(new Rect(width4, height4, buttonWidth, buttonHeight), "None"))
        {
            renderUnder = null;
            Derender();
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
        if(renderBarrel != null){
            renderBarrel.renderer.enabled = true;
        }

        if(renderSight != null)
        {
            renderSight.renderer.enabled = true;
        }

        if(renderMag != null)
        {
            renderMag.renderer.enabled = true;
        }
         
        if(renderUnder != null)
        {
            renderUnder.renderer.enabled = true;
        }
    }
}
