using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;
using System;


public class VictoryState : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    public static VictoryState Instance;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        _text.SetActive(state == GameState.Victory);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateState()
    {

        if (Input.GetKeyDown(KeyCode.Space) && GameManager.Instance.State == GameState.Victory)
        {
            SaveLevel();
            GoToNextLevel();
        }

    }

    private void GoToNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        GameManager.Instance.UpdateGameState(GameState.Gaming);
    }


    private void SaveLevel()
    {
     
        int world, level;
        string sceneName = SceneManager.GetActiveScene().name;

        if (ParseSceneName(sceneName, out world, out level))
        {
            Debug.Log($"World: {world}, Level: {level}");
        }
        else
        {
            Debug.Log("No se pudo parsear el nombre de la escena.");
        }
    }


    private bool ParseSceneName(string sceneName, out int world, out int level)
    {
        // Inicializamos los valores en -1 por si falla el parseo
        world = -1;
        level = -1;

        // Usamos una expresión regular para capturar los números después de 'World' y 'Level'
        Regex regex = new Regex(@"World(\d+)Level(\d+)");
        Match match = regex.Match(sceneName);

        if (match.Success)
        {
            // Extraemos los números
            world = int.Parse(match.Groups[1].Value);
            level = int.Parse(match.Groups[2].Value);
            return true;
        }
        else
        {
            Debug.Log("El nombre de la escena no sigue el formato esperado.");
            return false;
        }
    }


}
