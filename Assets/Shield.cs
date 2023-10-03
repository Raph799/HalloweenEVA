using UnityEngine;

public class Shield : MonoBehaviour
{
    public int maxShieldHealth = 10; // Vida máxima del escudo
    private int currentShieldHealth; // Vida actual del escudo

    private void Start()
    {
        currentShieldHealth = maxShieldHealth;
    }

    public bool IsShieldActive()
    {
        return currentShieldHealth > 0;
    }

    public void TakeDamage(int damage)
    {
        currentShieldHealth -= damage;

        // Si el escudo se rompe, puedes realizar acciones adicionales aquí
        if (currentShieldHealth <= 0)
        {
            OnShieldBreak();
        }
    }

    void OnShieldBreak()
    {
        // Aquí puedes agregar la lógica de lo que sucede cuando el escudo se rompe
    }
}
