﻿using UnityEngine;
using System.Collections;

public class LobbyScript : MonoBehaviour {

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
	
	// Update is called once per frame
	void OnGUI () {
        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), Screen.height / 2.4F - (buttonHeight / 2), buttonWidth, buttonHeight), "Start Game")) {
            Application.LoadLevel("MovementTest");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), Screen.height / 2 - (buttonHeight / 2), buttonWidth, buttonHeight), "Custimize muh guhn!"))
        {
            Application.LoadLevel("CustomizationScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), Screen.height / 1.7F - (buttonHeight / 2), buttonWidth, buttonHeight), "Exit Game"))
        {
            Application.Quit();
        }
	}
}
