using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] 
    private Button _startGameButton;

    [SerializeField]
    private WaveSpawn _spawn1;
    [SerializeField]
    private WaveSpawn _spawn2;
    [SerializeField] 
    private Base _base;
    [SerializeField] 
    private Text _resultText;

    private void Start()
    {
        _resultText.text = "";
        _startGameButton.onClick.AddListener(OnStartGameButtonPressed);
    }

    private void OnStartGameButtonPressed()
    {
        _base.Lose += OnLose;
        _spawn1.EnemyCountChanged += OnEnemyCountChanged;
        _spawn2.EnemyCountChanged += OnEnemyCountChanged;

        _spawn1.StartGame(7, 2);
        _spawn2.StartGame(6, 1);
        _base.Reset();
        _startGameButton.gameObject.SetActive(false);
        _resultText.gameObject.SetActive(false);
    }

    private void OnLose()
    {
        FinishGame(false);
    }

    private void OnEnemyCountChanged()
    {
        if (_spawn1.GetEnemyCount <= 0 && _spawn2.GetEnemyCount <= 0)
        {
            if (_base.CurrentHp > 0)
            {
                FinishGame(true);
            }
        }
    }

    private void FinishGame(bool isWin)
    {
        _base.Lose -= OnLose;
        _spawn1.FinishGame();
        _spawn2.FinishGame();
        _spawn1.EnemyCountChanged -= OnEnemyCountChanged;
        _spawn2.EnemyCountChanged -= OnEnemyCountChanged;
        _startGameButton.gameObject.SetActive(true);
        _resultText.gameObject.SetActive(true);
        if (isWin)
        {
            _resultText.text = "Winner!";
        }
        else
        {
            _resultText.text = "GameOver!";
        }
        Towers();
    }

    private void Towers()
    {
        var towers = Object.FindObjectsOfType<Tower>();
        for (int i = 0; i < towers.Length; i++)
        {
            Destroy(towers[i].gameObject);
        }
    }
}
