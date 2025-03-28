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
    public Animator levelSelectedAnimator;
    public GameObject ControlsPanel;
    public GameObject LevelSelector;
    public GameObject GameDescriptor;
    public GameObject LevelDescriptor;
    private bool button1EndSequence = false;
    private bool menuBlocked = false;

    [Header("Others")]
    public CinemachineVirtualCamera transitionCam; // used to reference the MainMenuController
    public GameObject transitionLvl1;
    private bool buttoncontollerBlocked = false;
    private enum MenuOptions
    {
        NewGame = 0,
        Settings = 1,
        Quit = 2,
        LevelSelected = 3
      
    }

    private void Start()
    {
        base.Start();
        menuButtonController = new MenuButtonController(3);
    }
    void Update()
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


        if (!menuBlocked) { executeSwitch(); } else
        {
            LevelDescriptor.SetActive(false);


            if (LevelSelector.active == false)
            {
                transitionCam.gameObject.SetActive(false);
                buttoncontollerBlocked = false;          
                menuBlocked = false;
            }
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
            levelSelectedAnimator.SetBool("selected", false);
            levelSelectedAnimator.SetBool("pressed", false);
        }
    }
    IEnumerator LoadFirstLevel(float time)
    {
        yield return new WaitForSeconds(time);

        //LevelManager.Instance.LoadFirstLevel();
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex + 1);
        GameManager.Instance.UpdateGameState(GameState.Gaming);

        LoadPlayerProgress();
    }

    public void LoadPlayerProgress()
    {
        // Verificamos si el jugador tiene progreso guardado
        if (PlayerPrefs.HasKey("LastWorld") && PlayerPrefs.HasKey("LastLevel"))
        {
            int lastWorld = PlayerPrefs.GetInt("LastWorld");
            int lastLevel = PlayerPrefs.GetInt("LastLevel");

            // Usar la información cargada para posicionar al jugador en el último mundo y nivel
            Debug.Log("Último mundo: " + lastWorld);
            Debug.Log("Último nivel: " + lastLevel);

            int leveltoChrage = lastLevel + 1;

            SceneManager.LoadScene("World" + lastWorld + "Level" + leveltoChrage);

            // Aquí puedes usar lastWorld y lastLevel para cargar la escena correspondiente
        }
        else
        {
            Debug.Log("No se encontró progreso guardado.");
            // Si no hay progreso guardado, quizás iniciar en el primer mundo/primer nivel
            SceneManager.LoadScene("World1Level1");
        }
    }

    private void executeSwitch()
    {
        GameDescriptor.SetActive(menuButtonController.index == (int)MenuOptions.NewGame);
        LevelDescriptor.SetActive(menuButtonController.index == (int)MenuOptions.LevelSelected);

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
                    ControlsPanel.SetActive(!buttoncontollerBlocked);
                    buttoncontollerBlocked = !buttoncontollerBlocked;
                }, settingsAnimator);
                break;

            case (int)MenuOptions.Quit:
                ExecuteButtonAction(() =>
                {
                    var confirm = gameObject.AddComponent<ConfirmationPanel>();
                    buttoncontollerBlocked = !buttoncontollerBlocked;
                    confirm.Initiate(surePanel, () => Quit());
                }, quitAnimator);
                break;
            case (int)MenuOptions.LevelSelected:
                ExecuteButtonAction(() =>
                {
                    transitionCam.gameObject.SetActive(true);
                    buttoncontollerBlocked = !buttoncontollerBlocked;
                    LevelSelector.SetActive(true);
                    menuBlocked = true;
                }, levelSelectedAnimator);
                break;
        }
    }

}