using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player; // Referencia al objeto del jugador
    public float distanciaHuir = 6f; // Distancia a la que el enemigo comenzará a huir
    public float distanciaPerseguir = 3f; // Distancia a la que el enemigo comenzará a perseguir al jugador
    private NavMeshAgent navMeshAgent;
    private Vector3 puntoHuida; // Punto al que el enemigo huirá

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        puntoHuida = transform.position; // Inicialmente, el enemigo no se aleja de su posición actual
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, player.position);

        // Comprobar si el jugador está lo suficientemente cerca para perseguir o huir
        if (distanciaAlJugador <= distanciaPerseguir)
        {
            // El jugador está lo suficientemente cerca para perseguir
            navMeshAgent.SetDestination(player.position);
        }
        else if (distanciaAlJugador >= distanciaHuir)
        {
            // El jugador está lo suficientemente lejos para huir
            navMeshAgent.SetDestination(puntoHuida);
        }

        // Actualizar el punto de huida si el jugador se acerca demasiado
        if (distanciaAlJugador <= distanciaHuir)
        {
            puntoHuida = transform.position + (transform.position - player.position).normalized * 10f;
        }
    }
}
