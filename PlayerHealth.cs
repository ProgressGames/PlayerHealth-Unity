using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Text healthText;
    public Transform respawnPoint; // “очка возрождени€ игрока

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthUI();

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString("F0");
        }
    }

    void Die()
    {
        // ƒействи€ при смерти (в данном случае возрождение)
        Respawn();
    }

    void Respawn()
    {
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            currentHealth = maxHealth;
            UpdateHealthUI();
        }
        else
        {
            Debug.LogWarning("Respawn point is not assigned for PlayerHealth.");
        }
    }
}
