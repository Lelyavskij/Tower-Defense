using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    private bool gameOver;

    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";


    }

}