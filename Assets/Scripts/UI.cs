using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using static Data;

public class UI : MonoBehaviour
{
    [SerializeField] private Sprite[] blockIcons;
    [SerializeField] private Image nextBlock;
    [SerializeField] private Text scoreHolder;
    [SerializeField] private Text timerHolder;
    [SerializeField] private Text levelHolder;
    [SerializeField] private Slider expHolder;
    [SerializeField] private Button pauseButton;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameoverScreen;
    [SerializeField] private Text gameOverScore;
    [SerializeField] private Text gameOverTime;
    [SerializeField] private Text gameOverLevel;


    void Start()
    {
        Time.timeScale = 1f;
        gameoverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        expHolder.maxValue = 10;
    }


    void Update()
    {
        nextBlock.sprite = blockIcons[Spawner.nextBlock];
        scoreHolder.text = score.ToString();
        timerHolder.text = time;
        levelHolder.text = level.ToString();
        expHolder.maxValue = maxExp;
        expHolder.value = currentExp;

        if(Block.isGameOver)
        {
            GameOver();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }

    public void Continue()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public static void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        gameoverScreen.SetActive(true);

        gameOverScore.text = score.ToString();
        gameOverTime.text = time;
        gameOverLevel.text = level.ToString();
        
        Block.isGameOver = false;
    }
}
