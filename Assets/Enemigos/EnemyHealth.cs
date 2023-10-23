using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxShieldHealth = 5;
    public GameObject deathEffectPrefab; // Prefab a instanciar al morir

    private int currentHealth;
    private int currentShieldHealth;

    void Start()
    {
        currentHealth = maxHealth;
        currentShieldHealth = maxShieldHealth;
    }

    public void TakeDamageShield(int damage)
    {
        if (currentShieldHealth > 0)
        {
            currentShieldHealth -= damage;

            if (currentShieldHealth <= 0)
            {
                currentShieldHealth = 0;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentShieldHealth <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, transform.rotation);
        }

        // Destruye el objeto actual
        Destroy(gameObject);
    }

    public int GetCurrentShieldHealth()
    {
        return currentShieldHealth;
    }
}
