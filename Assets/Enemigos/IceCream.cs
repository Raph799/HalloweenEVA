using UnityEngine;
using System.Collections.Generic;

public class IceCream : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public GameObject enemyPrefab;
    public GameObject deathEffectPrefab; // Prefab a instanciar al morir
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
            SpawnEnemiesOnDamage(); // Llama al m�todo para spawnear enemigos al recibir da�o
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
