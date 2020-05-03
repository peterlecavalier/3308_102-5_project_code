using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayScript : MonoBehaviour
{
    public void ReplayGame()
    {
        CoinCollection.scoreValue = 0;
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
