using UnityEngine;
using System.Collections.Generic;

public class IceCream : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public GameObject enemyPrefab;
    public List<Transform> spawnPoints;

    void Start()
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
        else
        {
            SpawnEnemiesOnDamage(); // Llama al método para spawnear enemigos al recibir daño
        }
    }

    void Die()
    {
        // Puedes agregar aquí cualquier lógica adicional cuando el enemigo muere.
        // Por ejemplo, reproducir una animación de muerte o desactivar el objeto.
        gameObject.SetActive(false);
    }

    void SpawnEnemiesOnDamage()
    {
        // Comprueba si se ha asignado un prefab de enemigo y al menos un punto de spawn
        if (enemyPrefab != null && spawnPoints.Count > 0)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
