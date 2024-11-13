using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMainMenu : MonoBehaviour
{
    public void GoToStartMenu() //T‰m‰ funktio mahdollistaa sen, ett‰ Main Menu nappia klikatessa pelaaja p‰‰see takaisin Start Menu Sceneen, josta voi pelata uudelleen tai lopettaa pelin.
    {
        SceneManager.LoadSceneAsync(0);
    }
}