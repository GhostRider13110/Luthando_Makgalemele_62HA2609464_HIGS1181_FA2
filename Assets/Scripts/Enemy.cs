using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();

        gameManager.RegisterEnemy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            gameManager.EnemyDestroyed();

            Debug.Log("Enemy Destroyed");

            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Destroyed");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
