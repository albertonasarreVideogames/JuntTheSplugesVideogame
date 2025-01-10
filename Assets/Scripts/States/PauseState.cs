using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    public static PauseState Instance;

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
        _text.SetActive(state == GameState.Pause);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(GameManager.Instance.State == GameState.Pause) {

                GameManager.Instance.UpdateGameState(GameState.Gaming);

            } else if (GameManager.Instance.State == GameState.Gaming)
            {
                GameManager.Instance.UpdateGameState(GameState.Pause);
            }
        }


    }
}
