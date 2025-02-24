using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelSelectorMenu : MonoBehaviour
{

    [SerializeField] private GameObject _text;
    public static PauseState Instance;

    public MenuButtonController menuButtonController;
    public bool disableOnce;
    public GameObject surePanel;

    public Animator newGameAnimator;
    public Animator settingsAnimator;
    public Animator quitAnimator;
    public Animator backToMenuAnimator;
    public GameObject ControlsPanel;
    private bool button1EndSequence = false;
    // Start is called before the first frame update

    private enum PauseOptions
    {
        NewGame = 0,
        Settings = 1,
        Quit = 2,
        BackTomenu = 3
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetDefaultValues();
        if (ControlsPanel.activeSelf)
        {
            if (Input.anyKeyDown)
            {
                ControlsPanel.SetActive(false);
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
                    ControlsPanel.SetActive(true);
                }, settingsAnimator);
                break;

            case (int)PauseOptions.Quit:
                ExecuteButtonAction(() =>
                {
                    var confirm = gameObject.AddComponent<ConfirmationPanel>();
                    confirm.Initiate(surePanel, () => Quit());
                }, quitAnimator);
                break;
            case (int)PauseOptions.BackTomenu:
                ExecuteButtonAction(() =>
                {
                    button1EndSequence = true;
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
