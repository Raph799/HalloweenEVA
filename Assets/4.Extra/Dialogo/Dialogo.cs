using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject PanelDialogo;
    [SerializeField] private TMP_Text TextoDialogo;
    [SerializeField, TextArea(4, 6)] private string[] LineasDialogo;
    [SerializeField] private float tiempoVisible = 3f; // Tiempo en segundos que el di�logo estar� visible.

    private float TypingTime = 0.05f;
    private int LineIndex;
    private float timer;

    private IEnumerator Start()
    {
        PanelDialogo.SetActive(false); // Asegurarse de que el panel de di�logo est� desactivado al inicio.
        yield return null;
        // StartCoroutine(StartDialogSequence());
    }

    void Update()
    {
        // Verificar si el di�logo est� activo y actualizar el temporizador.
        if (PanelDialogo.activeSelf && LineIndex <= LineasDialogo.Length)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                bool end = !SiguienteDialogo();
                if (!end)
                {
                    StartCoroutine(endDialog());
                }

            }
        }
        if(LineIndex == LineasDialogo.Length)
        {
            StartCoroutine(endDialog());
        }
    }

    private IEnumerator StartDialogSequence()
    {

        yield return new WaitForSeconds(1f); // Esperar 1 segundo antes de comenzar el di�logo.

        while (LineIndex < LineasDialogo.Length)
        {
            StartDialogue();
            yield return new WaitForSeconds(tiempoVisible);
            bool end = SiguienteDialogo();
            if (!end)
            {
                yield return new WaitForSeconds(1f);
                
            }
            yield return new WaitForSeconds(1f); // Esperar 1 segundo entre l�neas de di�logo.
        }
    }

    public void StartDialogue()
    {
        PanelDialogo.SetActive(true);
        LineIndex = 0;
        //Time.timeScale = 0f;
        StartCoroutine(ShowLine());
        timer = tiempoVisible; // Inicializar el temporizador.
    }

    private bool SiguienteDialogo()
    {
        LineIndex++;
        if (LineIndex < LineasDialogo.Length)
        {
            StartCoroutine(ShowLine());
            timer = tiempoVisible; // Reiniciar el temporizador para la siguiente l�nea.
        }
        else
        {
            
            Time.timeScale = 1f;

            return false;
        }
        return true;
    }

    private IEnumerator ShowLine()
    {
        TextoDialogo.text = string.Empty;

        foreach (char ch in LineasDialogo[LineIndex])
        {
            TextoDialogo.text += ch;
            yield return new WaitForSecondsRealtime(TypingTime);
        }
    }

    public IEnumerator endDialog()
    {
        yield return new WaitForSecondsRealtime(1);
        PanelDialogo.SetActive(false);
    }
}
