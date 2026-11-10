
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;

    private bool isGameOver = false;

    private void Start()
    {
        healthBar.fillAmount = healthAmount / 100f;

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void TakeDamage(float damage)
    {
        if (isGameOver) return;

        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;

        if (healthAmount <= 0)
        {
            GameOver();
        }
    }

    public void Heal(float healingAmount)
    {
        if (isGameOver) return;

        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }

    private void GameOver()
    {
        isGameOver = true;

        gameOverScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
