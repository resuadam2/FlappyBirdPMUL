using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private TMP_Text scoreText;

    private int score = 0;

    public bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isGameOver && Input.GetMouseButtonDown(0))
        {
            Restart();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        gameOverUI.SetActive(true);
        isGameOver = true;
    }

    public void Restart()
    {
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
