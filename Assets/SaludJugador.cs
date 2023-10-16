using UnityEngine;

public class SaludJugador : MonoBehaviour
{
    public int saludMaxima = 100; // Salud m�xima del jugador.
    private int saludActual; // Salud actual del jugador.

    void Start()
    {
        saludActual = saludMaxima; // Al inicio, la salud actual es igual a la salud m�xima.
    }

    // M�todo para recibir da�o.
    public void RecibirDanio(int cantidadDanio)
    {
        saludActual -= cantidadDanio;

        // Comprobar si el jugador ha muerto.
        if (saludActual <= 0)
        {
            Morir();
        }
    }

    // M�todo para curar al jugador.
    public void Curar(int cantidadCuracion)
    {
        saludActual = Mathf.Min(saludActual + cantidadCuracion, saludMaxima);
    }

    // M�todo para el jugador muere.
    void Morir()
    {
        // Coloca aqu� la l�gica de lo que sucede cuando el jugador muere, como mostrar un mensaje de Game Over, reiniciar el nivel, etc.
        // Por ejemplo:
        Debug.Log("�El jugador ha muerto!");
        // Puedes agregar m�s l�gica seg�n tus necesidades.
    }
}
