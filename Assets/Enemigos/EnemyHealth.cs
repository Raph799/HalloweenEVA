using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxShieldHealth = 5;

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
        // Puedes personalizar esta función para hacer cualquier cosa cuando el enemigo muera, como reproducir una animación, reproducir un sonido, etc.
        Destroy(gameObject);
    }

    public int  GetCurrenShieldtHealth()
    {
        return currentShieldHealth; 
    }
}
