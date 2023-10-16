using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFlee : MonoBehaviour
{
    public Transform jugador;
    public float distanciaParaHuir = 10f;
    public float distanciaParaTocar = 3f;
    public float velocidadHuida = 5f;
    public float velocidadHuidaMaxima = 10f;
    public float velocidadAproximacion = 2f;
    public float rangoDeAtk = 2f; 
    public int danio;

    private NavMeshAgent agente;
    private Vector3 destinoHuida;
    private bool tocadoJugador = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, jugador.position);

        if (!tocadoJugador)
        {
            if (distanciaAlJugador < distanciaParaTocar)
            {
                // El enemigo se aproxima y toca al jugador
                agente.SetDestination(jugador.position);
                agente.speed = velocidadAproximacion;

                if (distanciaAlJugador < rangoDeAtk)
                {
                    //daño
                    jugador.GetComponent<SaludJugador>().RecibirDanio(danio);

                    // El enemigo ha tocado al jugador
                    tocadoJugador = true;

                    // Deja de seguir al jugador y huye
                    agente.SetDestination(destinoHuida);
                    agente.speed = velocidadHuida;
                }
            }
            else if (distanciaAlJugador < distanciaParaHuir)
            {
                // El enemigo huye del jugador
                Vector3 direccionHuida = transform.position - jugador.position;
                destinoHuida = transform.position + direccionHuida.normalized * 10f;
                agente.SetDestination(destinoHuida);
                agente.speed = velocidadHuida;
            }
            else
            {
                // Si el jugador está lejos, detiene al enemigo
                agente.speed = 0f;
            }
        }
        else
        {
            Vector3 direccionHuida = transform.position - jugador.position;
            destinoHuida = transform.position + direccionHuida.normalized * 10f;
            // El enemigo ya tocó al jugador, así que sigue huyendo
            agente.SetDestination(destinoHuida);
            agente.speed = velocidadHuidaMaxima;
        }
    }
}
