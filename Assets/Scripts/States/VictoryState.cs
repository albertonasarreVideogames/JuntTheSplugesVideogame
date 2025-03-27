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
    private LevelManager levelManager;

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

        levelManager = new LevelManager();
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
            SavePlayerProgress(world,level);
        }
        else
        {
            Debug.Log("No se pudo parsear el nombre de la escena.");
        }
    }

    private void SavePlayerProgress(int world, int level)
    {
        // Cargar el progreso guardado (último mundo y nivel)
        (int savedWorld, int savedLevel) = LoadPlayerProgress();

        // Comparar el nivel actual con el nivel guardado.
        // Solo se guarda si el jugador ha avanzado más.
        if (world > savedWorld || (world == savedWorld && level > savedLevel))
        {
            // Guardamos el nombre del mundo y el número del nivel
            PlayerPrefs.SetInt("LastWorld", world);
            PlayerPrefs.SetInt("LastLevel", level);

            // Asegúrate de guardar los datos
            PlayerPrefs.Save();

            Debug.Log("Progreso guardado.");
        }
        else
        {
            Debug.Log("El nivel actual no es más avanzado que el guardado. No se guardó progreso.");
        }

        levelManager.AgregarNivelCompletado(SceneManager.GetActiveScene().name);

    }

    private (int, int) LoadPlayerProgress()
    {
        // Si no se ha guardado nunca progreso, retornar un valor predeterminado (por ejemplo, mundo 0, nivel 0)
        int savedWorld = PlayerPrefs.GetInt("LastWorld", 0);
        int savedLevel = PlayerPrefs.GetInt("LastLevel", 0);

        return (savedWorld, savedLevel);
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
