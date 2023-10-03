using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20; // Vida máxima del enemigo
    private int currentHealth; // Vida actual del enemigo

    public Shield shield; // Referencia al componente de escudo

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Si el escudo está roto, el enemigo recibe daño
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
        // Aquí puedes agregar la lógica de lo que sucede cuando el enemigo muere
        Destroy(gameObject);
    }
}
