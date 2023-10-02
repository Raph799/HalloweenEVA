using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject[] weapons; // Lista de armas
    private int currentWeaponIndex = 0; // Índice de arma actual

    void Start()
    {
        // Desactivar todas las armas excepto la primera al inicio
        for (int i = 1; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }

    void Update()
    {
        // Cambiar de arma con las teclas Q y E
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon(-1); // Cambiar a la arma anterior
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeapon(1); // Cambiar a la siguiente arma
        }
    }

    void SwitchWeapon(int direction)
    {
        // Desactivar la arma actual
        weapons[currentWeaponIndex].SetActive(false);

        // Calcular el nuevo índice de arma
        currentWeaponIndex += direction;
        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = weapons.Length - 1;
        }
        else if (currentWeaponIndex >= weapons.Length)
        {
            currentWeaponIndex = 0;
        }

        // Activar la nueva arma
        weapons[currentWeaponIndex].SetActive(true);
    }
}
