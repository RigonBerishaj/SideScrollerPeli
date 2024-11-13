using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPlayButton : MonoBehaviour
{
    public void PlayGame() // T�m� funktio mahdollistaa pelaajan pelaamaan peli� Start Menun Play napista klikkaamalla.
    {
        SceneManager.LoadSceneAsync(1); // T�ss� Unity projektissa on kaksi scenea Start Menu ja SideScroller numero 0 scene on Start Menu ja numero 1 scene on SideScroller.
    }

    public void QuitGame()
    {

#if UNITY_EDITOR
        // Kun ollaan editorissa, lopetetaan play mode painamalla QUIT nappia

        UnityEditor.EditorApplication.isPlaying = false;
#else
        // If not in the editor, quit the application
        Application.Quit();
#endif
    }
}