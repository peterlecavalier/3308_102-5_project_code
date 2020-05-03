using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public static Text scoreText;
    public static void setText(int scoreInt)
    {
        scoreText.text = "Score: " + scoreInt.ToString();
    }
}
