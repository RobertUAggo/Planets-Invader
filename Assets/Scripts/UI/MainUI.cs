using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public static MainUI Instance;
    MainUI()
    {
        Instance = this;
    }
    public void ExitClick()
    { 
        if(MenuScript.Instance != null)
        {
            //Debug.Log("Quit");
            Application.Quit();
        }
        else
        {
            //Debug.Log("LoadMenu");
            Loader.LoadOtherScene(OtherScene.Menu);
        }
    }
}
