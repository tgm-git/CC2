using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

    public float value = 200;
    public float max = 200;
	// Use this for initialization
	void OnGUI()
    {

        GUI.Box(new Rect(0, 0, 100, 10), "100%");
        GUI.Box(new Rect(0, 12, (value/max)*100, 10), "wtf");
    }
}
