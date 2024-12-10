using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public TextMeshProUGUI scoreText; 
    public int totalCustomers;  
    private int servedCustomers = 0; 
    private int activeCustomers = 0;
    private bool gameWon = false;
    public GameObject customerPrefab;
    public GameObject winning_panel;
    public GameObject losing_panel;
    public TextMeshProUGUI winning_scores;

    private void Awake()
    {
        winning_panel.SetActive(false);
        losing_panel.SetActive(false);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount; 
        UpdateScoreUI(); 
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void CustomerServed()
    {
        servedCustomers++;
        activeCustomers--;

        if (servedCustomers == totalCustomers)
        {
            if (score < 0) LoseGame();
            else WinGame();
        }
    }

    private void WinGame()
    {
        if (gameWon) return;
        gameWon = true;
        winning_panel.SetActive(true);

        winning_scores.text = score.ToString();
    }

    private void LoseGame()
    {
        losing_panel.SetActive(true);
    }
}
