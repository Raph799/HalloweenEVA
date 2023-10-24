using UnityEngine;

public class PlayerMordisco : MonoBehaviour
{
    public float attackRange = 3.0f; // Rango de ataque del jugador.
    public int attackDamage = 100; // Cantidad de da�o que el jugador inflige al jefe.
    public LayerMask bossLayer; // Capa que identifica al jefe.
    public float cooldown = 5.0f; // Tiempo de reutilizaci�n en segundos.
    public int playerHealAmount = 80; // Cantidad de salud que el jugador recupera al atacar al jefe.

    private float cooldownTimer = 0.0f;
    private bool canUseSkill = true;
    private SaludJugador playerHealth;

    void Start()
    {
        playerHealth = GetComponent<SaludJugador>();
    }

    void Update()
    {
        if (canUseSkill && Input.GetMouseButtonDown(1)) // Comprueba si se ha presionado el bot�n derecho del rat�n y la habilidad est� habilitada.
        {
            TryAttack();
        }

        // Actualiza el temporizador de reutilizaci�n.
        if (!canUseSkill)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer >= cooldown)
            {
                canUseSkill = true; // Habilita la habilidad despu�s de que pase el tiempo de reutilizaci�n.
                cooldownTimer = 0.0f; // Reinicia el temporizador.
            }
        }
    }

    void TryAttack()
    {
        // Realiza un raycast en la direcci�n de la c�mara.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, attackRange, bossLayer))
        {
            // Comprueba si el objeto golpeado es el jefe.
            BossHealth bossHealth = hit.collider.GetComponent<BossHealth>();

            if (bossHealth != null)
            {
                // El jugador ha atacado al jefe.
                bossHealth.TakeDamage(attackDamage);

                // El jugador recupera salud al atacar al jefe.
                playerHealth.Curar(playerHealAmount);

                canUseSkill = false; // Deshabilita la habilidad.
            }
        }
    }
}
