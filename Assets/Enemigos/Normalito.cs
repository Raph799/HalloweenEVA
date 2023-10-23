using UnityEngine;

public class Normalito : MonoBehaviour
{
    public int maxHealth = 10;  // Valor editable desde el Editor
    public GameObject deathEffectPrefab; // Prefab que se instanciará al morir el enemigo

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
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, transform.rotation);
        }

        // Aquí puedes agregar más lógica, como sonidos, animaciones, puntos al jugador, etc.

        Destroy(gameObject);
    }
}
