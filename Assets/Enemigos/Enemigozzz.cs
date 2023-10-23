using UnityEngine;

public class Enemigozzz : MonoBehaviour
{
    public int maxHealth = 10;  // Valor editable desde el Editor

    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Aquí puedes agregar lógica para la muerte del enemigo, como reproducir una animación o efectos de sonido.
        Destroy(gameObject); // Este es solo un ejemplo; puedes ajustar esto según tus necesidades.
    }
}
