using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fuseDuration = 3.0f;   // Duración de la mecha en segundos
    public float explosionRadius = 5.0f; // Radio de explosión
    public int explosionDamage = 50;    // Daño de la explosión

    private bool hasExploded = false;
    private float explosionTime;

    void Start()
    {
        // Iniciar la cuenta regresiva de la mecha
        explosionTime = Time.time + fuseDuration;
    }

    void Update()
    {
        // Comprobar si ha llegado el momento de la explosión
        if (!hasExploded && Time.time >= explosionTime)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Marcar la bomba como explotada para evitar múltiples explosiones
        hasExploded = true;

        // Buscar todos los objetos en el radio de explosión
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            // Aplicar daño a los objetos que tengan un componente "Health" (ajusta según tus necesidades)
            /*
            Health targetHealth = hit.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(explosionDamage);
            }
            */
        }

        // Destruir la bomba después de la explosión
        Destroy(gameObject);
    }
}
