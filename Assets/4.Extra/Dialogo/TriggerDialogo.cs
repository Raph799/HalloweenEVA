using System.Collections;
using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    public Dialogo dialogo; // Asigna el componente Dialogo en el Inspector.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            dialogo.StartDialogue(); // Inicia el diálogo cuando el jugador colisiona con el objeto.
            Destroy(gameObject); 
        }
    }
}
