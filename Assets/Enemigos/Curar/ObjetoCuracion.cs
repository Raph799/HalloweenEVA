using UnityEngine;

public class ObjetoCuracion : MonoBehaviour
{
    public int cantidadACurar = 10; // Cantidad de salud que se cura.
    public float tiempoDestruccion = 15.0f; // Tiempo en segundos antes de que el objeto se destruya.

    private bool canCure = false; // Variable para controlar si el jugador puede curarse.

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entr� en el trigger es el jugador.
        if (other.CompareTag("Player"))
        {
            canCure = true; // El jugador puede curarse cuando est� en el rango del objeto de curaci�n.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sali� del trigger es el jugador.
        if (other.CompareTag("Player"))
        {
            canCure = false; // El jugador no puede curarse cuando est� fuera del rango del objeto de curaci�n.
        }
    }

    private void Start()
    {
        // Inicia una cuenta regresiva para la destrucci�n del objeto.
        Destroy(gameObject, tiempoDestruccion);
    }

    private void Update()
    {
        // Verifica si el jugador puede curarse y si se ha presionado el bot�n derecho del mouse.
        if (canCure && Input.GetMouseButtonDown(1))
        {
            // Obtiene una referencia al componente de salud del jugador.
            SaludJugador jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<SaludJugador>();

            // Aseg�rate de que el componente de salud del jugador exista.
            if (jugador != null)
            {
                // Llama al m�todo Curar del jugador para aumentar su salud.
                jugador.Curar(cantidadACurar);

                // Cancela la destrucci�n del objeto de curaci�n.
                CancelInvoke("DestruirObjetoCuracion");

                // Destruye el objeto de curaci�n.
                Destroy(gameObject);
            }
        }
    }

    // Funci�n para destruir el objeto de curaci�n despu�s de un tiempo.
    private void DestruirObjetoCuracion()
    {
        Destroy(gameObject);
    }
}
