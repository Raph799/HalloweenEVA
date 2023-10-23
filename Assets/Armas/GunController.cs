using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    public SaludJugador jugador; // Agrega una referencia al script de salud del jugador
    [SerializeField] float force = 1000f;
    [SerializeField] float bulletSelfDestruct = 3f;

    public int danioDisparo = 10; // Variable p�blica para el da�o al disparar

    private float nextFireTime = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Resta vida al jugador al disparar utilizando la variable p�blica danioDisparo
        jugador.RecibirDanio(danioDisparo);

        // Instancia la bala en el punto de origen del arma
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Aplica fuerza para disparar la bala
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletSpawnPoint.forward * force);

        // Destruye la bala despu�s de un tiempo (ajusta esto seg�n tus necesidades)
        Destroy(bullet, bulletSelfDestruct);
    }
}
