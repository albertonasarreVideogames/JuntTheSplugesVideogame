using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // static for grab it from anywhere
    public static GameManager Instance;

    public GameState State;
    public GameState OldState;

    public static event Action<GameState> OnGameStateChanged;


    private void Awake()
    {
        if(Instance == null) { 
        Instance = this;
        DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        UpdateGameState(State);
        OldState = GameState.Menu;
    }

    private void Update()
    {

        //DEBUG
        if (Input.GetKeyDown(KeyCode.P))
            {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
            UpdateGameState(GameState.Gaming);
            }
        if (Input.GetKeyDown(KeyCode.O))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex - 1);
            UpdateGameState(GameState.Gaming);
        }
        //FINISHDEBUG
        switch (State)
        {
            case GameState.Pause:
                PauseState.Instance.UpdateState();
                break;
            case GameState.Gaming:
                GamingState.Instance.UpdateState();
                break;
            case GameState.Victory:
                VictoryState.Instance.UpdateState();
                break;
            case GameState.Lose:
                LoseState.Instance.UpdateState();
                break;
            case GameState.Menu:
                MenuState.Instance.UpdateState();
                break;
            case GameState.Rewind:
                RewindState.Instance.UpdateState();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(State), State, null);
        }

    }



    public void UpdateGameState(GameState newState)
    {
        OldState = State;
        State = newState;

        switch (newState)
        {
            case GameState.Pause:
                HandlePause();
                break;
            case GameState.Gaming:
                HandleGaming();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            case GameState.Menu:
                HandleMenu();
                break;
            case GameState.Rewind:
                HandleRwind();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandleVictory()
    {
        //Time.timeScale = 0;
        
    }

    private void HandleGaming()
    {
        Time.timeScale = 1;
        if (OldState != GameState.Pause && OldState != GameState.Rewind)
        {
            SoundManager.StartOst();
        }
    }

    private void HandlePause()
    {
        Time.timeScale = 0;
    }

    private void HandleLose()
    {
        Time.timeScale = 0.5f;

    }

    private void HandleMenu()
    {
        Time.timeScale = 1;
        SoundManager.StopOst();

    }

    private void HandleRwind()
    {
        Time.timeScale = 1.5f;

    }


}

public enum GameState
{
    Pause,
    Gaming,
    Victory,
    Lose,
    Menu,
    Rewind
}