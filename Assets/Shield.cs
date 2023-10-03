using UnityEngine;

public class Shield : MonoBehaviour
{
    public int maxShieldHealth = 10; // Vida m�xima del escudo
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

        // Si el escudo se rompe, puedes realizar acciones adicionales aqu�
        if (currentShieldHealth <= 0)
        {
            OnShieldBreak();
        }
    }

    void OnShieldBreak()
    {
        // Aqu� puedes agregar la l�gica de lo que sucede cuando el escudo se rompe
    }
}
