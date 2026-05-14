using UnityEngine;
using TMPro; 

public class GameManager : MonoBehaviour
{
    public TMP_Text enemyCounterText;
    public GameObject winPanel;

    private int enemiesAlive = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RegisterEnemy()
    {
        enemiesAlive++;
        UpdateEnemyCounter();
    }

    public void EnemyDestroyed()
    {
        enemiesAlive--;
        UpdateEnemyCounter();

        if (enemiesAlive <= 0)
        {
            ShowWinScreen();
        }
    }

    public void UpdateEnemyCounter()
    {
        enemyCounterText.text = "Enemies Left: " + enemiesAlive;
    }

    public void ShowWinScreen()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
