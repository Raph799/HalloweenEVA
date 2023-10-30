using UnityEngine;
using UnityEngine.SceneManagement;

public class SaludJugador : MonoBehaviour
{
    public int saludMaxima = 100; // Salud máxima del jugador.
    private int saludActual; // Salud actual del jugador.

    public HealthBar healthBar;

    void Start()
    {
        saludActual = saludMaxima; // Al inicio, la salud actual es igual a la salud máxima.
        healthBar.SetMaxHealth(saludMaxima);
    }

    // Método para recibir daño.
    public void RecibirDanio(int cantidadDanio)
    {
        saludActual -= cantidadDanio;

        healthBar.SetHealth(saludActual);

        // Comprobar si el jugador ha muerto.
        if (saludActual <= 0)
        {
            Morir();
            SceneManager.LoadScene("GameOver");
        }
    }

    // Método para curar al jugador.
    public void Curar(int cantidadCuracion)
    {
        saludActual = Mathf.Min(saludActual + cantidadCuracion, saludMaxima);
    }

    // Método para el jugador muere.
    
    void Morir()
    {
        // Coloca aquí la lógica de lo que sucede cuando el jugador muere, como mostrar un mensaje de Game Over, reiniciar el nivel, etc.
        // Por ejemplo:
        Debug.Log("¡El jugador ha muerto!");
        // Puedes agregar más lógica según tus necesidades //
    }
}
