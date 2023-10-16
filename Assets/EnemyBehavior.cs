using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float rangoDeDeteccion = 10f; // Rango de detecci�n del jugador.
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del enemigo.
    public float tiempoEspera = 3f; // Tiempo de espera antes de comenzar a perseguir al jugador.
    public float tiempoExplosion = 1f; // Tiempo de espera antes de la explosi�n.
    public float radioExplosion = 5f; // Radio de explosi�n que da�a al jugador.
    public int danioExplosion = 50; // Cantidad de da�o causada por la explosi�n.
    public float rangoDeEspera = 2f; // Rango de detecci�n del jugador.

    private Transform jugador; // Referencia al Transform del jugador.
    private bool jugadorDetectado = false;
    private bool enPersecucion = false;
    private float tiempoInicioPersecucion;
    private bool BumOnce = false;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform; // Asume que el jugador tiene el tag "Player".
    }

    void Update()
    {
        if(BumOnce) return;

        if (!jugadorDetectado)
        {
            float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

            if (distanciaAlJugador <= rangoDeDeteccion)
            {
                jugadorDetectado = true;
                tiempoInicioPersecucion = Time.time + tiempoEspera;
            }
        }
        else if (Time.time >= tiempoInicioPersecucion && !enPersecucion)
        {
            enPersecucion = true;
        }

        if (enPersecucion)
        {
            Vector3 direccion = (jugador.position - transform.position).normalized;
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);

            float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);
            Debug.Log("Hola");
            if (distanciaAlJugador <= rangoDeEspera) // Si est� lo suficientemente cerca del jugador.
            {
                BumOnce = true;
                Debug.Log("BUUUMMM");
                enPersecucion = false;
                Invoke("Explotar", tiempoExplosion);
            }
        }
    }

    void Explotar()
    {
        // Detener el enemigo.
        enPersecucion = false;

        // Esperar 1 segundo y luego causar una explosi�n.
        Invoke("RealizarExplosion", 1f);
    }

    void RealizarExplosion()
    {
        // Coloca aqu� la l�gica de la explosi�n, como efectos visuales y de sonido.

        // Buscar todos los objetos en el radio de explosi�n y da�ar al jugador.
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                if (jugador.GetComponent<SaludJugador>() != null) { 
                    // Realizar da�o al jugador (ajusta esto seg�n tu sistema de salud).
                    jugador.GetComponent<SaludJugador>().RecibirDanio(danioExplosion);
                }
                else
                {
                    Debug.LogWarning("Missing Component SaludJugador");
                }
            }
        }

        // Destruir el enemigo despu�s de la explosi�n.
        Destroy(gameObject);
    }
}
