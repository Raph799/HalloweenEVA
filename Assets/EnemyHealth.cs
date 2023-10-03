using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20; // Vida m�xima del enemigo
    private int currentHealth; // Vida actual del enemigo

    public Shield shield; // Referencia al componente de escudo

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Si el escudo est� roto, el enemigo recibe da�o
        if (!shield.IsShieldActive())
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
        // Aqu� puedes agregar la l�gica de lo que sucede cuando el enemigo muere
        Destroy(gameObject);
    }
}
