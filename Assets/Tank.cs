using UnityEngine;
using UnityEngine.AI;

public class Tank : MonoBehaviour
{
    public Transform jugador; // Referencia al GameObject del jugador

    public float distanciaDeteccion = 6.0f; // Distancia a la que el enemigo detecta al jugador
    public float velocidadMovimiento = 5.0f; // Velocidad de movimiento del enemigo

    private NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.speed = velocidadMovimiento;
    }

    private void Update()
    {
        // Calcula la distancia entre el enemigo y el jugador
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        // Si el jugador está a menos de la distancia de detección
        if (distanciaAlJugador <= distanciaDeteccion)
        {
            // Calcula la dirección para huir del jugador
            Vector3 direccionHuida = transform.position - jugador.position;
            direccionHuida.y = 0; // Mantén la misma altura

            // Obtiene la posición de huida
            Vector3 posicionHuida = transform.position + direccionHuida.normalized * distanciaDeteccion;

            // Establece el destino del NavMeshAgent al punto de huida
            agente.SetDestination(posicionHuida);
        }
    }
}
