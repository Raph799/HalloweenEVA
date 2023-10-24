using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoHuye : MonoBehaviour
{
    public float distanciaParaHuir = 10f;
    public float velocidadHuida = 5f;

    private NavMeshAgent agente;
    private Transform jugador;
    private Vector3 destinoHuida;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        // Buscar al jugador con el tag "Player" al inicio
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (jugador == null)
        {
            // Si el jugador no se encuentra, detén al enemigo
            agente.speed = 0f;
            return;
        }

        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        if (distanciaAlJugador < distanciaParaHuir)
        {
            // Calcula el punto de huida en dirección opuesta al jugador
            Vector3 direccionHuida = transform.position - jugador.position;
            destinoHuida = transform.position + direccionHuida.normalized * 10f;

            // Asigna el destino al agente NavMesh
            agente.SetDestination(destinoHuida);
            agente.speed = velocidadHuida;
        }
        else
        {
            // Si el jugador está lo suficientemente lejos, detiene al enemigo
            agente.speed = 0f;
        }
    }
}
