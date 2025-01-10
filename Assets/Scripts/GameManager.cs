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
    }



    public void UpdateGameState(GameState newState)
    {
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
                break;
            case GameState.Procesing:
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
    }

    private void HandlePause()
    {
        Time.timeScale = 0;
    }

    private void HandleLose()
    {
        //Time.timeScale = 0;

    }


}

public enum GameState
{
    Pause,
    Gaming,
    Victory,
    Lose,
    Menu,
    Procesing
}