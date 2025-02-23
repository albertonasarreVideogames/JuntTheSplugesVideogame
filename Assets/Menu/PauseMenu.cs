using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MenuBase
{
    [Header("Animators")]
    public Animator newGameAnimator;
    public Animator settingsAnimator;
    public Animator quitAnimator;
    public Animator backToMenuAnimator;
    public GameObject ControlsPanel;
    private bool button1EndSequence = false;
    private enum PauseOptions
    {
        NewGame = 0,
        Settings = 1,
        Quit = 2,
        BackTomenu = 3
    }

    private void Start()
    {
        base.Start();

        newGameAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        settingsAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        quitAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        backToMenuAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
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
}
