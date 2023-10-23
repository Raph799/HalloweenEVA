using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    public SaludJugador jugador; // Agrega una referencia al script de salud del jugador
    [SerializeField] float force = 1000f;
    [SerializeField] float bulletSelfDestruct = 3f;

    public int danioDisparo = 10; // Variable pública para el daño al disparar

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
        // Resta vida al jugador al disparar utilizando la variable pública danioDisparo
        jugador.RecibirDanio(danioDisparo);

        // Instancia la bala en el punto de origen del arma
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Aplica fuerza para disparar la bala
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletSpawnPoint.forward * force);

        // Destruye la bala después de un tiempo (ajusta esto según tus necesidades)
        Destroy(bullet, bulletSelfDestruct);
    }
}
