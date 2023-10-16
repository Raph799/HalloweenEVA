using UnityEngine;

public class IceCreamController : MonoBehaviour
{
    public int maxHP = 30; // Puntos de vida máximos del enemigo de helado
    public GameObject iceCreamPrefab; // Prefab del nuevo enemigo de helado a aparecer
    public Transform[] spawnPoints; // Array de puntos de aparición del nuevo enemigo de helado

    private int currentHP; // Puntos de vida actuales del enemigo de helado

    private void Start()
    {
        currentHP = maxHP; // Inicializa los puntos de vida actuales
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage; // Reduce los puntos de vida del enemigo de helado

        if (currentHP <= 0)
        {
            Die(); // Llama a la función "Die" si los puntos de vida llegan a 0
        }
    }

    private void Die()
    {
        if (spawnPoints.Length > 0 && iceCreamPrefab != null)
        {
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform selectedSpawnPoint = spawnPoints[randomSpawnPointIndex];

            Instantiate(iceCreamPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
        }

        Destroy(gameObject); // Destruye este enemigo de helado
    }
}
