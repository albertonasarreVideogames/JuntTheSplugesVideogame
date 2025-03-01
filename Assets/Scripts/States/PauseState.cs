using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PauseState : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    public static PauseState Instance;

    private MenuButtonController menuButtonController;
    public bool disableOnce;
    public GameObject surePanel;

    public Animator newGameAnimator;
    public Animator settingsAnimator;
    public Animator quitAnimator;
    public Animator backToMenuAnimator;
    public GameObject ControlsPanel;
    private bool button1EndSequence = false;
    private bool buttoncontollerBlocked = false;

    private enum PauseOptions
    {
        NewGame = 0,
        Settings = 1,
        Quit = 2,
        BackTomenu = 3
    }

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
        if (state == GameState.Menu) { _text.GetComponent<Canvas>().enabled = false; }
        if (state == GameState.Pause) { _text.GetComponent<Canvas>().enabled = true; button1EndSequence = false; menuButtonController.index = 0; }
        if (state == GameState.Gaming) { _text.GetComponent<Canvas>().enabled = false; }


    }
    private void Start()
    {
      
        newGameAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        settingsAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        quitAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        backToMenuAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        menuButtonController = new MenuButtonController(3);
    }

    // Update is called once per frame
    public void UpdateState()
    {
        if (!buttoncontollerBlocked) { menuButtonController.Update(); }
        SetDefaultValues();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (buttoncontollerBlocked)
            {
                ControlsPanel.SetActive(false);
                buttoncontollerBlocked = false;
            }
        }

        switch (menuButtonController.index)
        {
            case (int)PauseOptions.NewGame:
                ExecuteButtonAction(() =>
                {
                    Resumegame();
                    button1EndSequence = true;
                }, newGameAnimator);
                break;

            case (int)PauseOptions.Settings:
                ExecuteButtonAction(() =>
                {
                    ControlsPanel.SetActive(!buttoncontollerBlocked);
                    buttoncontollerBlocked = !buttoncontollerBlocked;
                }, settingsAnimator);
                break;

            case (int)PauseOptions.Quit:
                ExecuteButtonAction(() =>
                {
                    var confirm = gameObject.AddComponent<ConfirmationPanel>();
                    buttoncontollerBlocked = !buttoncontollerBlocked;
                    confirm.Initiate(surePanel, () => Quit());
                }, quitAnimator);
                break;
            case (int)PauseOptions.BackTomenu:
                ExecuteButtonAction(() =>
                {
                    button1EndSequence = true;
                    buttoncontollerBlocked = false;
                    GoToMenu();
                }, backToMenuAnimator);
                break;
        }
    }

    private void SetDefaultValues()
    {
        if (!button1EndSequence)
        {
            newGameAnimator.SetBool("selected", false);
            newGameAnimator.SetBool("pressed", false);
            settingsAnimator.SetBool("selected", false);
            settingsAnimator.SetBool("pressed", false);
            quitAnimator.SetBool("selected", false);
            quitAnimator.SetBool("pressed", false);
            backToMenuAnimator.SetBool("selected", false);
            backToMenuAnimator.SetBool("pressed", false);
        }
    }
    private void Resumegame()
    {
        GameManager.Instance.UpdateGameState(GameState.Gaming);
    }

    private void GoToMenu()
    {
        GameManager.Instance.UpdateGameState(GameState.Menu);
        SceneManager.LoadScene(0);
    }

    protected void ExecuteButtonAction(Action actionToExecute, Animator anim)
    {

        anim.SetBool("selected", true);
        //SoundManager.PlaySound(SoundType.MENUCHANGE);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetBool("pressed", true);
            SoundManager.PlaySound(SoundType.MENUSELECTED);
            actionToExecute.Invoke();
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }
}
