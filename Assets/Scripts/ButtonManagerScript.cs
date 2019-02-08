using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagerScript : MonoBehaviour {

    // Use this for initialization
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        SceneManager.UnloadSceneAsync("MainMenu");
       // Score.score = 0;
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    //public void Main_Menu_(string sceneName2)
    //{
    //    SceneManager.UnloadSceneAsync("GameOver");
    //    SceneManager.LoadScene(sceneName2);
    //    Time.timeScale = 1;
    //    GameObject.Find("AudioSource").SendMessage("Pitch1");
    //}
}
