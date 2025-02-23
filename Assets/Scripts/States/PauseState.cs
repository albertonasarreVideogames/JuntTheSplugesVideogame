using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(state == GameState.Menu) { _text.SetActive(false); }
        if (state == GameState.Pause) { _text.SetActive(true); }
        if (state == GameState.Gaming) { _text.SetActive(false); }


    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateState()
    {
        
    }
    
}
