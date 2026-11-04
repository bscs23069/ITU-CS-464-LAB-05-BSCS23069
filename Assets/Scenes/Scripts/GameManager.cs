
//using UnityEngine;
//using TMPro;

//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance;

//    public TMP_Text scoreText;
//    public TMP_Text timerText;
//    public TMP_Text messageText;

//    public int targetScore = 10;
//    public float gameTime = 60f;

//    private int score = 0;
//    private bool gameEnded = false;

//    void Awake()
//    {
//        instance = this;
//    }

//    void Start()
//    {
//        Time.timeScale = 1f;
//        UpdateScoreText();

//        if (messageText != null)
//            messageText.text = "";
//    }

//    void Update()
//    {
//        if (gameEnded)
//            return;

//        gameTime -= Time.deltaTime;

//        if (gameTime <= 0f)
//        {
//            gameTime = 0f;
//            EndGame(false);
//        }

//        if (timerText != null)
//            timerText.text = "Time: " + Mathf.CeilToInt(gameTime);
//    }

//    public void AddScore(int amount)
//    {
//        if (gameEnded)
//            return;

//        score += amount;
//        UpdateScoreText();

//        if (score >= targetScore)
//            EndGame(true);
//    }

//    void UpdateScoreText()
//    {
//        if (scoreText != null)
//            scoreText.text = "Score: " + score;
//    }

//    void EndGame(bool won)
//    {
//        gameEnded = true;

//        if (messageText != null)
//        {
//            messageText.text = won
//                ? "You Win!"
//                : "Time's Up!";
//        }

//        Time.timeScale = 0f;
//    }
//}


using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Existing UI")]
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text messageText;

    [Header("Game Settings")]
    public int targetScore = 10;
    public float gameTime = 60f;

    private int score = 0;
    private bool gameEnded = false;

    private bool redCoinCollected = false;
    private bool bonusRoundCompleted = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        UpdateScoreText();

        if (messageText != null)
        {
            messageText.text = "";
        }

        if (timerText != null)
        {
            timerText.text =
                "Time: " + Mathf.CeilToInt(gameTime);
        }
    }

    private void Update()
    {
        if (gameEnded)
            return;

        gameTime -= Time.deltaTime;

        if (gameTime <= 0f)
        {
            gameTime = 0f;
            EndGame(false);
        }

        if (timerText != null)
        {
            timerText.text =
                "Time: " + Mathf.CeilToInt(gameTime);
        }
    }

    public void AddScore(int amount)
    {
        if (gameEnded)
            return;

        score += amount;
        UpdateScoreText();

        CheckWinCondition();
    }

    public void RedCoinCollected()
    {
        redCoinCollected = true;

        CheckWinCondition();
    }

    public void BonusRoundCompleted()
    {
        bonusRoundCompleted = true;

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (score >= targetScore &&
            redCoinCollected &&
            bonusRoundCompleted)
        {
            EndGame(true);
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    private void EndGame(bool won)
    {
        if (gameEnded)
            return;

        gameEnded = true;

        if (messageText != null)
        {
            messageText.text = won
                ? "You Win!"
                : "Time's Up!";
        }

        Time.timeScale = 0f;
    }
}
