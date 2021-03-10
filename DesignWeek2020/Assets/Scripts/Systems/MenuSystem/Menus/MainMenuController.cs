using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : Menu
{
    //Example classifier
    public MenuClassifier HUDMenuClassifier;
    public SceneReference gameSceneReference;

    //Example use
    public void ShowGameScene()
    {
        MenuManager.Instance.HideMenu(menuClassifier); // Hide self
        MenuManager.Instance.ShowMenu(HUDMenuClassifier); // Show HUD

        //ENABLE PLAYER INPUT

        SceneLoader.Instance.LoadScene(gameSceneReference);
    }
}
