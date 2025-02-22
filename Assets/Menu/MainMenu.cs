using Cinemachine;
using System;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MenuBase
{
    [Header("Animators")]
    public Animator newGameAnimator;
    public Animator settingsAnimator;
    public Animator quitAnimator;
    public GameObject ControlsPanel;
    private bool button1EndSequence = false;

    [Header("Others")]
    public CinemachineVirtualCamera transitionCam; // used to reference the MainMenuController
    public GameObject transitionLvl1;
    private enum MenuOptions
    {
        NewGame = 0,
        Settings = 1,
        Quit = 2
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
            case (int)MenuOptions.NewGame:
                ExecuteButtonAction(() =>
                {
                    transitionCam.gameObject.SetActive(true);
                    transitionLvl1.SetActive(true);
                    StartCoroutine(LoadFirstLevel(1.7f));
                    button1EndSequence = true;
                }, newGameAnimator);
                break;

            case (int)MenuOptions.Settings:
                ExecuteButtonAction(() =>
                {
                    ControlsPanel.SetActive(true);
                }, settingsAnimator);
                break;

            case (int)MenuOptions.Quit:
                ExecuteButtonAction(() =>
                {
					var confirm = gameObject.AddComponent<ConfirmationPanel>();
					confirm.Initiate(surePanel, ()=>Quit());
                }, quitAnimator);
                break;
        }
    }

    private void SetDefaultValues()
    {
        if(!button1EndSequence)
        {
            newGameAnimator.SetBool("selected", false);
            newGameAnimator.SetBool("pressed", false);
            settingsAnimator.SetBool("selected", false);
            settingsAnimator.SetBool("pressed", false);
            quitAnimator.SetBool("selected", false);
            quitAnimator.SetBool("pressed", false);
        }
    }
    IEnumerator LoadFirstLevel(float time)
    {
        yield return new WaitForSeconds(time);

        //LevelManager.Instance.LoadFirstLevel();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        GameManager.Instance.UpdateGameState(GameState.Gaming);
    }
}