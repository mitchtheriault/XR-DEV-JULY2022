using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool GameIsActive { get => _gameIsActive; set => _gameIsActive = value; }
    private bool _gameIsActive = false;

    public int score = 0;

    public float timer = 30f;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI timerText;


    private void Start()
    {
        timerText.text = "Time: " + timer;
    }


    public void AddToScore(int value)
    {
        if (timer > 0 && _gameIsActive == true)
        {
            score = score + value;
            scoreText.text = "Score: " + score;
        }
        
    }

    private void Update()
    {
        if (timer > 0 && _gameIsActive == true)
        {
            timer = timer - Time.deltaTime;
            timerText.text = "Time: " + timer;
        }
        
    }
}
