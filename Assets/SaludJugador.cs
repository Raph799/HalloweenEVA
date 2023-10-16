using UnityEngine;

public class SaludJugador : MonoBehaviour
{
    public int saludMaxima = 100; // Salud máxima del jugador.
    private int saludActual; // Salud actual del jugador.

    void Start()
    {
        saludActual = saludMaxima; // Al inicio, la salud actual es igual a la salud máxima.
    }

    // Método para recibir daño.
    public void RecibirDanio(int cantidadDanio)
    {
        saludActual -= cantidadDanio;

        // Comprobar si el jugador ha muerto.
        if (saludActual <= 0)
        {
            Morir();
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
        // Puedes agregar más lógica según tus necesidades.
    }
}
