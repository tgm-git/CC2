using UnityEngine;
using System.Collections;

public class Custom : MonoBehaviour
{
    //Disse GameObjects bliver brugt til rendering. 
    //Når spilleren ændre hvilke vedhæftninger han/hun ønsker vist så bliver det nyvalgte GameObject sat lig med et af disse GameObjects for at blive vist.
    [System.NonSerialized]
    public GameObject renderBarrel;
    [System.NonSerialized]
    public GameObject renderSight;
    [System.NonSerialized]
    public GameObject renderMag;
    [System.NonSerialized]
    public GameObject renderUnder;

    //Dette er højden og breden på knapperne
    int buttonHeight = 50;
    int buttonWidth = 150;

    //Dette er nogle standard højde positioner, som bliver brugt til at holde knapperne på line
    float height0 = Screen.height * 0.32F;
    float height1 = Screen.height * 0.4F;
    float height2 = Screen.height * 0.46F;
    float height3 = Screen.height * 0.52F;
    float height4 = Screen.height * 0.58F;

    //Dette er nogle standard brede positioner, som bliver brugt til at holde knapperne på række
    float width1 = Screen.width / 6;
    float width2 = Screen.width / 4;
    float width3 = Screen.width / 3;
    float width4 = Screen.width / 2.4F; 

    //Dette er alle vedhæftningerne til våbentet
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


    void Start() {

        //Her tjekkes der efter tidligere tilpasninger af spilleren i den globale klasse
        if ((CCGlobal.barrel+CCGlobal.mag+CCGlobal.sight+CCGlobal.under) == "")
        {
            //Hvis der ikke er nogen tidligere tilpasning, så vises disse standard GameObjects
            renderBarrel = Barrel1;
            renderMag = Mag1;
            renderSight = Sight1;
            renderUnder = Under1;
        }
        else {

            Load();

        }

        //Her kalder jeg Derender metoden
        Derender();
        
    }

    void OnGUI()
    {
        //Dette stykke kode placere en knap over resten af knapperne lægnere nede som lader spilleren gå tilbage til hovedmenuen og gemme sin tilpasning
        if (GUI.Button(new Rect(width1, height0, buttonWidth, buttonHeight), "Exit to Menu"))
        {
            Save();
            Application.LoadLevel("LobbyScene");
        }

        //her er alle de individuelle knapper som spilleren bruger til at tilpasse våbenet
        #region Attachment Buttons

        #region Barrel
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

        #region Sight
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

        #region Mag
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

        #region Under
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
    //Denne metode derender alle de GameObjects og bagefter genrendere de objekter som skal vises
    void Derender() 
    {
        //Derender alle GameObjects
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

        //Metoden tjekker om det ønskede GameObject er null eller lig med intet før at den rendere det, hvis at GameObject er lig med intet så bliver det ikke renderet
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

    //Denne metode gemmer spilleren tilpasing af våbenet
    //Metoden gemmer navnene på alle de viste GameObjects, i den globale klasse så de kan hentes senere eller i en anden scene
    void Save() {

        //Metoden sørger for at der er et navn at gemme, ellers bliver strengen sat lig med intet
        if (renderBarrel != null)
        {
            CCGlobal.barrel = renderBarrel.name;
        }
        else {
            CCGlobal.barrel = null;
        }

        if (renderMag != null)
        {
            CCGlobal.mag = renderMag.name;
        }
        else {
            CCGlobal.mag = null;
        }

        if (renderSight != null)
        {
            CCGlobal.sight = renderSight.name;
        }
        else {
            CCGlobal.sight = null;
        }

        if (renderUnder != null)
        {
            CCGlobal.under = renderUnder.name;
        }
        else {
            CCGlobal.under = null;
        }
    }

    //Denne metode viser spilleren tidligere tilpasing ind i scenen
    //Den henter navnene på de tidliger vaglte GameObjects og sætter dem lig med de renderende GameObjects
    void Load() {
        //Dette GameObject er et midlertidigt GameObjects som bliver sat ligmed de GameObjects som skal vises
        //Så bliver den sat lig med de renderende GameObjects for at blive vist
        GameObject load;

        //Før at dette GameObject bliver hentet tjekker metoden om der et GameObject at hente, hvis ikke så er "load" lig med intet
        if (CCGlobal.barrel != null)
        {
            load = GameObject.Find(CCGlobal.barrel);
            renderBarrel = load;
        }
        else
        {
            load = null;
        }

        if (CCGlobal.mag != null)
        {
            load = GameObject.Find(CCGlobal.mag);
            renderMag = load;
        }
        else
        {
            load = null;
        }

        if (CCGlobal.sight != null)
        {
            load = GameObject.Find(CCGlobal.sight);
            renderSight = load;
        }
        else
        {
            load = null;
        }

        if (CCGlobal.under != null)
        {
            load = GameObject.Find(CCGlobal.under);
            renderUnder = load;
        }
        else
        {
            load = null;
        }
    }
}

//Denne klasse holder styr på spillerens tidligere tilpasning. Den gemmer navnene på de GameObjects som spilleren har valgt
public static class CCGlobal {

    public static string barrel;
    public static string mag;
    public static string sight;
    public static string under;
   
}
