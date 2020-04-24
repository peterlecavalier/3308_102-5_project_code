using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitButton : MonoBehaviour
{
    public void DoExitGame()
    {
        Application.Quit();
        Debug.Log("Quit Success");
    }
}
