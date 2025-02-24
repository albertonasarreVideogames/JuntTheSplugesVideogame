using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class LevelSelectorMenu : MonoBehaviour
{
    public GameObject worldChoose;
    public GameObject LevelChoose;
    public GameObject surePanel;

    public Animator backToMenuAnimator;

    private string wordlSelected = "";
    private bool button1EndSequence = false;

    private enum WorldsOptions
    {
        World1 = 0,
        World2 = 1,
        World3 = 2,
        World4 = 3,
        BackToMenu = 4
    }

    private enum LevelOptions
    {
        Level1 = 0,
        Level2 = 1,
        Level3 = 2,
        Level4 = 3,
        Level5 = 4
    }

    // Diccionario para almacenar los animadores de mundos y niveles
    private Dictionary<WorldsOptions, Animator> worldAnimators = new Dictionary<WorldsOptions, Animator>();
    private Dictionary<LevelOptions, Animator> levelAnimators = new Dictionary<LevelOptions, Animator>();

    void Start()
    {
        // Accediendo a los animadores de los mundos desde la jerarquía
        worldAnimators.Add(WorldsOptions.World1, worldChoose.transform.Find("Menu/Buttons/World1").GetComponent<Animator>());
        worldAnimators.Add(WorldsOptions.World2, worldChoose.transform.Find("Menu/Buttons/World2").GetComponent<Animator>());
        worldAnimators.Add(WorldsOptions.World3, worldChoose.transform.Find("Menu/Buttons/World3").GetComponent<Animator>());
        worldAnimators.Add(WorldsOptions.World4, worldChoose.transform.Find("Menu/Buttons/World4").GetComponent<Animator>());
        worldAnimators.Add(WorldsOptions.BackToMenu, backToMenuAnimator);

        // Accediendo a los animadores de los niveles desde la jerarquía
        levelAnimators.Add(LevelOptions.Level1, LevelChoose.transform.Find("Menu/Buttons/Level1").GetComponent<Animator>());
        levelAnimators.Add(LevelOptions.Level2, LevelChoose.transform.Find("Menu/Buttons/Level2").GetComponent<Animator>());
        levelAnimators.Add(LevelOptions.Level3, LevelChoose.transform.Find("Menu/Buttons/Level3").GetComponent<Animator>());
        levelAnimators.Add(LevelOptions.Level4, LevelChoose.transform.Find("Menu/Buttons/Level4").GetComponent<Animator>());
        levelAnimators.Add(LevelOptions.Level5, LevelChoose.transform.Find("Menu/Buttons/Level5").GetComponent<Animator>());

        worldChoose.GetComponent<MenuButtonController>().index = 0;
    }

    void Update()
    {
        SetDefaultValues();

        // Manejo de selección de mundo
        if (worldChoose.activeSelf)
        {
            WorldsOptions selectedWorld = (WorldsOptions)worldChoose.GetComponent<MenuButtonController>().index;
            HandleWorldSelection(selectedWorld);
        }

        // Manejo de selección de nivel
        if (LevelChoose.activeSelf)
        {
            LevelOptions selectedLevel = (LevelOptions)LevelChoose.GetComponent<MenuButtonController>().index;
            HandleLevelSelection(selectedLevel);
        }
    }

    private void SetDefaultValues()
    {
        if (!button1EndSequence)
        {
            ResetWorldAnimators();
            ResetLevelAnimators();
        }
    }

    private void HandleWorldSelection(WorldsOptions world)
    {
        ExecuteButtonAction(() =>
        {
            switch (world)
            {
                case WorldsOptions.World1:
                    StartCoroutine(SelectWorld(1.0f, "World1"));
                    break;
                case WorldsOptions.World2:
                    StartCoroutine(SelectWorld(1.0f, "World2"));
                    break;
                case WorldsOptions.World3:
                    StartCoroutine(SelectWorld(1.0f, "World3"));
                    break;
                case WorldsOptions.World4:
                    StartCoroutine(SelectWorld(1.0f, "World4"));
                    break;
                case WorldsOptions.BackToMenu:
                    button1EndSequence = true;
                    GoToMenu();
                    break;
            }
        }, worldAnimators[world]);
    }

    private void HandleLevelSelection(LevelOptions level)
    {
        ExecuteButtonAction(() =>
        {
            Debug.Log(wordlSelected + level.ToString());
            GameManager.Instance.UpdateGameState(GameState.Gaming);
            SceneManager.LoadScene(wordlSelected + level.ToString());
        }, levelAnimators[level]);
    }

    private void ResetWorldAnimators()
    {
        foreach (var animator in worldAnimators.Values)
        {
            animator.SetBool("selected", false);
            animator.SetBool("pressed", false);
        }
    }

    private void ResetLevelAnimators()
    {
        foreach (var animator in levelAnimators.Values)
        {
            animator.SetBool("selected", false);
            animator.SetBool("pressed", false);
        }
    }

    private void GoToMenu()
    {
        GameManager.Instance.UpdateGameState(GameState.Menu);
        SceneManager.LoadScene(0);
    }

    protected void ExecuteButtonAction(Action actionToExecute, Animator anim)
    {
        anim.SetBool("selected", true);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetBool("pressed", true);
            SoundManager.PlaySound(SoundType.MENUSELECTED);
            actionToExecute.Invoke();
        }
    }

    private IEnumerator SelectWorld(float time, string world)
    {
        yield return new WaitForSeconds(time);

        worldChoose.SetActive(false);
        LevelChoose.SetActive(true);
        wordlSelected = world;
    }
}


