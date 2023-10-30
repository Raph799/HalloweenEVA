using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [Header("health")]
    public int maxHealth = 1000; // Establece la salud máxima del jefe en 1000
    private int currentHealth;
    [Header("spawn")]
    public GameObject[] enemyPrefabs; // Array de prefabs de enemigos disponibles.
    public Transform[] spawnPoints;    // Array de puntos de spawn para los enemigos.
    public float spawnInterval = 5.0f; // Intervalo de tiempo entre apariciones en segundos.
    private float timer = 0.0f;
    private bool canSpawn = true;

    void Start()
    {
        currentHealth = maxHealth; // Inicializa la salud actual al valor máximo
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (canSpawn && timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0.0f; // Reinicia el temporizador.
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Resta el daño recibido a la salud actual

        if (currentHealth <= 0)
        {
            Die(); // Si la salud actual es igual o menor a 0, el jefe muere
            SceneManager.LoadScene("WinMovie");
        }
    }

    void Die()
    {
        // Agrega aquí cualquier lógica que desees cuando el jefe muera
        // Por ejemplo, reproducir una animación de muerte o eliminar el GameObject
        Destroy(gameObject);
    }

    void SpawnEnemy()
    {
        if (currentHealth > 50) // Verifica que la salud del jefe sea mayor de 50.
        {
            // Elige aleatoriamente uno de los prefabs de enemigos disponibles.
            int randomPrefabIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject selectedEnemyPrefab = enemyPrefabs[randomPrefabIndex];

            // Elige aleatoriamente uno de los puntos de spawn.
            int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            Transform selectedSpawnPoint = spawnPoints[randomSpawnIndex];

            // Crea una instancia del enemigo seleccionado en el punto de spawn seleccionado.
            Instantiate(selectedEnemyPrefab, selectedSpawnPoint.position, Quaternion.identity);

            // Resta 10 puntos de salud al jefe cada vez que spawnee un enemigo.
            TakeDamage(10);
        }
        else
        {
            canSpawn = false; // Desactiva la capacidad de spawnear si la salud del jefe es menor o igual a 50.
        }
    }

    // Método para curar al jefe.
    public void Curar(int cantidadCuracion)
    {
        currentHealth = Mathf.Min(currentHealth + cantidadCuracion, maxHealth);
    }
}
