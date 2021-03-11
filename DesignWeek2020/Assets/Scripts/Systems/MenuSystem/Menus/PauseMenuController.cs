using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : Menu
{
    public MenuClassifier HUDMenuClassifier;
    public MenuClassifier mainMenuClassifier;

    public SceneReference gameSceneReference;


    public void ResumeGame()
    {
        MenuManager.Instance.HideMenu(menuClassifier); // Hide self
        MenuManager.Instance.ShowMenu(HUDMenuClassifier); // Show HUD

        GameManager.Instance.SetGamePaused(false);
        //ENABLE PLAYER INPUT HERE
    }

    public void QuitGame()
    {
        MenuManager.Instance.HideMenu(menuClassifier); // Hide self
        MenuManager.Instance.ShowMenu(mainMenuClassifier); // Show Main

        SceneLoader.Instance.UnloadScene(gameSceneReference);
    }
}
