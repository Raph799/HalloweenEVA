using UnityEngine;
using System.Collections.Generic;

public class IceCream : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;

    public GameObject enemyPrefab;
    public GameObject deathEffectPrefab; // Prefab a instanciar al morir
    public List<Transform> spawnPoints;

    [SerializeField] EnemyHealthUI healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthUI>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

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
