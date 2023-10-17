using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 10;

    void Update()
    {
        // Mueve la bala hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verifica si la bala colisiona con un enemigo u otro objeto
        if (other.CompareTag("Enemy"))
        {
            // Intenta obtener el componente "EnemyHealth"
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            else
            {
                // Si no se encuentra "EnemyHealth," intenta obtener el componente "IceCream"
                IceCream enemyIceCream = other.GetComponent<IceCream>();
                if (enemyIceCream != null)
                {
                    enemyIceCream.TakeDamage(damage);
                }
            }

            // Destruye la bala
            Destroy(gameObject);
        }
        else
        {
            // Si colisiona con otro objeto, simplemente destruye la bala
            Destroy(gameObject);
        }
    }
}
