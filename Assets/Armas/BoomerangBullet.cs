using UnityEngine;

public class BoomerangBullet : MonoBehaviour
{
    public float speed = 10.0f;
    public float returnSpeed = 15.0f;
    public float maxDistance = 10.0f;
    public float healingAmount = 10.0f; // Cantidad de vida que recupera al jugador
    public float maxTimeAlive = 5.0f; // Tiempo máximo que la bala puede estar activa antes de desaparecer

    private Transform player;
    private bool isReturning = false;
    private Vector3 originalPosition;
    private float startTime;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        originalPosition = transform.position;
        startTime = Time.time;
    }

    void Update()
    {
        if (!isReturning)
        {
            float step = speed * Time.deltaTime;
            transform.Translate(Vector3.forward * step);

            // Comprobar si la bala ha alcanzado la distancia máxima
            if (Vector3.Distance(originalPosition, transform.position) >= maxDistance)
            {
                isReturning = true;
            }
        }
        else
        {
            float step = returnSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);

            // Comprobar si la bala ha vuelto al jugador
            if (Vector3.Distance(transform.position, player.position) < 0.1f)
            {
                // Recuperar vida del jugador
                SaludJugador saludJugador = player.GetComponent<SaludJugador>();
                if (saludJugador != null)
                {
                    saludJugador.Curar((int)healingAmount);
                }

                Destroy(gameObject); // Destruir la bala boomerang al tocar al jugador
            }
        }

        // Destruir la bala si ha estado activa durante demasiado tiempo
        if (Time.time - startTime >= maxTimeAlive)
        {
            Destroy(gameObject);
        }
    }
}
