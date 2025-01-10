using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : MonoBehaviour
{
    public static MenuState Instance;
    [SerializeField] private GameObject _text;

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
        _text.SetActive(state == GameState.Menu);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && GameManager.Instance.State == GameState.Menu)
        {
            GoToNextLevel();

        }else if (Input.GetKeyDown(KeyCode.Return) && GameManager.Instance.State == GameState.Gaming)
        {
            GoToMenu();
        }

    }
    private void GoToNextLevel()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        GameManager.Instance.UpdateGameState(GameState.Gaming);
    }

    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
        GameManager.Instance.UpdateGameState(GameState.Menu);
    }
}
