using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float fuseDuration = 3.0f;   // Duraci�n de la mecha en segundos
    public float explosionRadius = 5.0f; // Radio de explosi�n
    public int explosionDamage = 50;    // Da�o de la explosi�n

    private bool hasExploded = false;
    private float explosionTime;

    void Start()
    {
        // Iniciar la cuenta regresiva de la mecha
        explosionTime = Time.time + fuseDuration;
    }

    void Update()
    {
        // Comprobar si ha llegado el momento de la explosi�n
        if (!hasExploded && Time.time >= explosionTime)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Marcar la bomba como explotada para evitar m�ltiples explosiones
        hasExploded = true;

        // Buscar todos los objetos en el radio de explosi�n
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            // Aplicar da�o a los objetos que tengan un componente "Health" (ajusta seg�n tus necesidades)
            /*
            Health targetHealth = hit.GetComponent<Health>();
            if (targetHealth != null)
            {
                targetHealth.TakeDamage(explosionDamage);
            }
            */
        }

        // Destruir la bomba despu�s de la explosi�n
        Destroy(gameObject);
    }
}
