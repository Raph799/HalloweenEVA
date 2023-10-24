using UnityEngine;
using UnityEngine.AI;

public class EnemigoSiguelo : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform jugador;
    private Transform boss;
    public int damageAmount = 10;
    public int bossHealAmount = 10;

    private bool hasTouchedPlayer = false;

    void Start()
    {
        navMeshAgent = GetComponent <NavMeshAgent>();
        jugador = GameObject.FindWithTag("Player").transform;
        boss = GameObject.FindWithTag("Boss").transform; // Asigna el jefe al que seguir por la etiqueta "Boss".
    }

    void Update()
    {
        if (!hasTouchedPlayer)
        {
            // Si el enemigo no ha tocado al jugador, sigue al jugador.
            if (jugador != null && navMeshAgent != null)
            {
                navMeshAgent.SetDestination(jugador.position);
            }
        }
        else
        {
            // Si el enemigo ya ha tocado al jugador, sigue al jefe para curarlo.
            if (boss != null && navMeshAgent != null)
            {
                navMeshAgent.SetDestination(boss.position);
            }
        }
    }

    // Método para tratar el contacto con el jugador o el jefe.
    void OnTriggerEnter(Collider other)
    {
        if (!hasTouchedPlayer && other.CompareTag("Player"))
        {
            // Aplica daño al jugador y cambia al modo de seguir al jefe.
            SaludJugador saludJugador = other.GetComponent<SaludJugador>();
            if (saludJugador != null)
            {
                saludJugador.RecibirDanio(damageAmount);
            }
            hasTouchedPlayer = true;
        }
        else if (hasTouchedPlayer && other.CompareTag("Boss"))
        {
            // Cura al jefe y luego destruye el enemigo.
            BossHealth bossHealth = other.GetComponent<BossHealth>();
            if (bossHealth != null)
            {
                bossHealth.Curar(bossHealAmount);
            }
            Destroy(gameObject);
        }
    }
}
