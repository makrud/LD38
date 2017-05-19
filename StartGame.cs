using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject Controls;
    public void NewGame()
    {
        SceneManager.LoadScene("Intro");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ShowControls()
    {
        Controls.SetActive(true);
    }
}
