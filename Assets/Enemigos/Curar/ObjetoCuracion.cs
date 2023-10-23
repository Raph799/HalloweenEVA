using UnityEngine;

public class ObjetoCuracion : MonoBehaviour
{
    public int cantidadACurar = 10; // Cantidad de salud que se cura.
    public float tiempoDestruccion = 15.0f; // Tiempo en segundos antes de que el objeto se destruya.

    private bool canCure = false; // Variable para controlar si el jugador puede curarse.

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en el trigger es el jugador.
        if (other.CompareTag("Player"))
        {
            canCure = true; // El jugador puede curarse cuando está en el rango del objeto de curación.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que salió del trigger es el jugador.
        if (other.CompareTag("Player"))
        {
            canCure = false; // El jugador no puede curarse cuando está fuera del rango del objeto de curación.
        }
    }

    private void Start()
    {
        // Inicia una cuenta regresiva para la destrucción del objeto.
        Destroy(gameObject, tiempoDestruccion);
    }

    private void Update()
    {
        // Verifica si el jugador puede curarse y si se ha presionado el botón derecho del mouse.
        if (canCure && Input.GetMouseButtonDown(1))
        {
            // Obtiene una referencia al componente de salud del jugador.
            SaludJugador jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<SaludJugador>();

            // Asegúrate de que el componente de salud del jugador exista.
            if (jugador != null)
            {
                // Llama al método Curar del jugador para aumentar su salud.
                jugador.Curar(cantidadACurar);

                // Cancela la destrucción del objeto de curación.
                CancelInvoke("DestruirObjetoCuracion");

                // Destruye el objeto de curación.
                Destroy(gameObject);
            }
        }
    }

    // Función para destruir el objeto de curación después de un tiempo.
    private void DestruirObjetoCuracion()
    {
        Destroy(gameObject);
    }
}
