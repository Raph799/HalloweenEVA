using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("StartMovie");
    }

    public void QuitGame()
    {
        Debug.Log("Cerrado con Exitaso!");
        Application.Quit();
    }

    public void LevelOne()
    {
        Debug.Log("Haz entrado a nivel 1!");
        SceneManager.LoadScene("NivelUno");
    }

    public void LevelTwo()
    {
        Debug.Log("Haz entrado a nivel 2!");
        SceneManager.LoadScene("NivelDos");
    }

    public void BossLevel()
    {
        Debug.Log("Haz entrado a pelea contra boss!!");
        SceneManager.LoadScene("NivelBoss");
    }

    //Este scrip fue robado de, mi misma!! editalo como sea, pero este scrip va en un game object si o sis<3
}