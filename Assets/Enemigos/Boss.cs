using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array de prefabs de enemigos disponibles.
    public Transform[] spawnPoints;    // Array de puntos de spawn para los enemigos.
    public float spawnInterval = 5.0f; // Intervalo de tiempo entre apariciones en segundos.
    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0.0f; // Reinicia el temporizador.
        }
    }

    void SpawnEnemy()
    {
        // Elige aleatoriamente uno de los prefabs de enemigos disponibles.
        int randomPrefabIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject selectedEnemyPrefab = enemyPrefabs[randomPrefabIndex];

        // Elige aleatoriamente uno de los puntos de spawn.
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[randomSpawnIndex];

        // Crea una instancia del enemigo seleccionado en el punto de spawn seleccionado.
        Instantiate(selectedEnemyPrefab, selectedSpawnPoint.position, Quaternion.identity);
    }
}
