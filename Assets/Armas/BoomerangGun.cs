using UnityEngine;

public class BoomerangGun : MonoBehaviour
{
    public GameObject boomerangPrefab;
    public Transform firePoint;
    public float fireRate = 1.0f; // Cadencia de disparo en disparos por segundo
    private float nextFireTime = 0.0f;
    public SaludJugador jugador; // Agrega una referencia al script de salud del jugador

    public int danioDisparo = 10; // Variable pública para el daño al disparar

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime) // Clic izquierdo del mouse y se puede disparar
        {
            // Resta vida al jugador al disparar utilizando la variable pública danioDisparo
            jugador.RecibirDanio(danioDisparo);

            ShootBoomerang();
            nextFireTime = Time.time + 1.0f / fireRate; // Calcula el próximo tiempo de disparo basado en la cadencia de disparo
        }
    }

    void ShootBoomerang()
    {
        // Instanciar la bala boomerang en el punto de disparo
        GameObject boomerang = Instantiate(boomerangPrefab, firePoint.position, firePoint.rotation);

        // Configurar cualquier otra propiedad de la bala boomerang aquí
    }
}
