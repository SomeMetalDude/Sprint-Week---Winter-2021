using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    public float secondsUntilReset = 300; // 5 Mins
    public float secondsLeft;

    private bool gamePaused = true;

    public UnityEvent timeElapsedEvent = new UnityEvent();

    public MenuClassifier pauseMenuClassifier;

    // Start is called before the first frame update
    void Start()
    {
        ResetCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            secondsLeft -= Time.deltaTime;
            if (secondsLeft <= 0)
            {
                timeElapsedEvent.Invoke();
            }
        }
    }

    public void ResetCountdown()
    {
        secondsLeft = secondsUntilReset;
    }
    
    public void SetGamePaused(bool paused)
    {
        if (paused)
        {
            MenuManager.Instance.ShowMenu(pauseMenuClassifier);
            gamePaused = true;
            Time.timeScale = 0;
        }
        else
        {
            MenuManager.Instance.HideMenu(pauseMenuClassifier);
            gamePaused = false;
            Time.timeScale = 1;
        }
    }

    public bool isGamePaused()
    {
        return gamePaused;
    }
}
