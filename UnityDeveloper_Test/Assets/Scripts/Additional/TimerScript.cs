using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;  
    public TextMeshProUGUI messageText; 
    public float timeLimit = 120f; 
    private float timeRemaining;

    private bool isGameOver = false;
    private int totalCoins;
    private int collectedCoins;

    void Start()
    {
        timeRemaining = timeLimit;
        messageText.text = "";
        totalCoins = FindObjectsOfType<CoinScript>().Length;
    }

    void Update()
    {
        if (isGameOver)
            return;

        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            GameOver();
        }

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        messageText.text = string.Format("Coins: {0}/{1}", collectedCoins, totalCoins);
    }

    void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("GameOverScene");
    }

    public void CollectCoin()
    {
        collectedCoins++;
        messageText.text = string.Format("Coins: {0}/{1}", collectedCoins, totalCoins);
        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        if (!isGameOver)
        {
            if (collectedCoins >= totalCoins)
            {
                isGameOver = true;
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
