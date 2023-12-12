using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Booleans to be used by PlayerController and HUD for maximum pressure levels.
    public static bool Steel = false;
    public static bool Titanium = false;
    public static bool Trieste = false;

    public void OnIronButton()
    {
        Steel = true;
        Titanium = false;
        Trieste = false;

        SceneManager.LoadScene(1);
    }

    public void OnTitaniumButton()
    {
        Titanium = true;
        Steel = false;
        Trieste = false;

        SceneManager.LoadScene(1);
    }

    public void OnTriesteButton()
    {
        Trieste = true;
        Steel = false;
        Titanium = false;

        SceneManager.LoadScene(1);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
