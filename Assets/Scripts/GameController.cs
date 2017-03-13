using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] 
    private Button _startGame;

    [SerializeField]
    private WaveSpawn _spawn1;
    [SerializeField]
    private WaveSpawn _spawn2;
    [SerializeField] 
    private Base _base;

    private bool gameOver;

    private bool restart;


   

    private void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        _startGame.onClick.AddListener(OnStartGameButtonPressed);
    }

    private void OnStartGameButtonPressed()
    {
        _base.Lose += OnLose;
        _spawn1.StartGame(7, 2);
        _spawn2.StartGame(6, 1);
        _base.Reset();
        _startGame.gameObject.SetActive(false);
    }

    private void OnLose()
    {
        _base.Lose -= OnLose;
        _spawn1.FinishGame();
        _spawn2.FinishGame();
        _startGame.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        gameOverText.text = "GameOver!";
        gameOver = true;

    }

}
