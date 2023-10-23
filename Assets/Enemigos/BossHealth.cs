using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 1000; // Establece la salud máxima del jefe en 1000
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud actual al valor máximo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Resta el daño recibido a la salud actual

        // Puedes agregar aquí lógica adicional, como reproducir efectos visuales o sonidos
        // cuando el jefe recibe daño.

        if (currentHealth <= 0)
        {
            Die(); // Si la salud actual es igual o menor a 0, el jefe muere
        }
    }

    void Die()
    {
        // Agrega aquí cualquier lógica que desees cuando el jefe muera
        // Por ejemplo, reproducir una animación de muerte o eliminar el GameObject
        Destroy(gameObject);
    }
}
