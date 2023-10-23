using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 1000; // Establece la salud m�xima del jefe en 1000
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud actual al valor m�ximo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Resta el da�o recibido a la salud actual

        // Puedes agregar aqu� l�gica adicional, como reproducir efectos visuales o sonidos
        // cuando el jefe recibe da�o.

        if (currentHealth <= 0)
        {
            Die(); // Si la salud actual es igual o menor a 0, el jefe muere
        }
    }

    void Die()
    {
        // Agrega aqu� cualquier l�gica que desees cuando el jefe muera
        // Por ejemplo, reproducir una animaci�n de muerte o eliminar el GameObject
        Destroy(gameObject);
    }
}
