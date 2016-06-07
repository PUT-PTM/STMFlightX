using UnityEngine;
using System.Collections;

public class CheckTime : MonoBehaviour
{

    public bool allOptions = false;
    public bool extended1 = false ;
    public bool extended2 = false;

    void Start()
    {
    }


    void OnGUI()
    {
        allOptions = GUI.Toggle(new Rect(0, 0, 150, 20), allOptions, "Choose time");
        GUI.enabled = allOptions;
        extended1 = GUI.Toggle(new Rect(20, 20, 130, 20), extended1, "1 minute");
        extended2 = GUI.Toggle(new Rect(20, 40, 130, 20), extended2, "2 minutes");
        GUI.enabled = true;

        if (extended1==true)
        {
            extended2 = false;
            ScoreCount.tim = 60;
        }

        if(extended2 == true)
        {
            extended1 = false;
            ScoreCount.tim = 120;
        }
    }
}
