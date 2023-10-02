using UnityEngine;

public class BoomerangGun : MonoBehaviour
{
    public GameObject boomerangPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clic izquierdo del mouse
        {
            ShootBoomerang();
        }
    }

    void ShootBoomerang()
    {
        // Instanciar la bala boomerang en el punto de disparo
        GameObject boomerang = Instantiate(boomerangPrefab, firePoint.position, firePoint.rotation);

        // Configurar cualquier otra propiedad de la bala boomerang aquí
    }
}
