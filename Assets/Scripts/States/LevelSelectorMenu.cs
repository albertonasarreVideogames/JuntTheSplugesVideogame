using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class LevelSelectorMenu : MonoBehaviour
{
    public GameObject worldChoose;
    public GameObject LevelChoose;
    public GameObject surePanel;

    public Animator world1Animator;
    public Animator world2Animator;
    public Animator world3Animator;
    public Animator world4Animator;
    public Animator backToMenuAnimator;

    public Animator level1Animator;
    public Animator level2Animator;
    public Animator level3Animator;
    public Animator level4Animator;
    public Animator level5Animator;

    private string wordlSelected = "";

    private bool button1EndSequence = false;
    // Start is called before the first frame update

    private enum WorldsOptions
    {
        World1 = 0,
        World2 = 1,
        World3 = 2,
        World4 = 3,
        BackTomenu = 4
    }

    private enum levelOptions
    {
        Level1 = 0,
        Level2 = 1,
        Level3 = 2,
        Level4 = 3,
        Level5 = 4
    }
    void Start()
    {
        worldChoose.GetComponent<MenuButtonController>().index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetDefaultValues();

        if (worldChoose.activeSelf)
        {
            switch (worldChoose.GetComponent<MenuButtonController>().index)
            {
                case (int)WorldsOptions.World1:
                    ExecuteButtonAction(() =>
                    {
                        StartCoroutine( SelectWorld(1.0f, "World1"));
                    }, world1Animator);
                    break;

                case (int)WorldsOptions.World2:
                    ExecuteButtonAction(() =>
                    {
                        StartCoroutine(SelectWorld(1.0f, "World2"));
                    }, world2Animator);
                    break;

                case (int)WorldsOptions.World3:
                    ExecuteButtonAction(() =>
                    {
                        StartCoroutine(SelectWorld(1.0f, "World3"));
                    }, world3Animator);
                    break;
                case (int)WorldsOptions.World4:
                    ExecuteButtonAction(() =>
                    {
                        StartCoroutine(SelectWorld(1.0f, "World4"));
                    }, world4Animator);
                    break;
                case (int)WorldsOptions.BackTomenu:
                    ExecuteButtonAction(() =>
                    {
                        button1EndSequence = true;
                        GoToMenu();
                    }, backToMenuAnimator);
                    break;
            }


        }

        if (LevelChoose.activeSelf)
        {
            switch (LevelChoose.GetComponent<MenuButtonController>().index)
            {
                case (int)levelOptions.Level1:
                    ExecuteButtonAction(() =>
                    {
                     
                        Debug.Log(wordlSelected+ "level1");
                    }, level1Animator);
                    break;

                case (int)levelOptions.Level2:
                    ExecuteButtonAction(() =>
                    {
                        Debug.Log(wordlSelected + "level2");
                    }, level2Animator);
                    break;

                case (int)levelOptions.Level3:
                    ExecuteButtonAction(() =>
                    {
                        Debug.Log(wordlSelected + "level3");
                    }, level3Animator);
                    break;
                case (int)levelOptions.Level4:
                    ExecuteButtonAction(() =>
                    {
                        Debug.Log(wordlSelected + "level4");
                    }, level4Animator);
                    break;
                case (int)levelOptions.Level5:
                    ExecuteButtonAction(() =>
                    {
                        Debug.Log(wordlSelected + "level5");
                    }, level5Animator);
                    break;
            }


        }




    }

    private void SetDefaultValues()
    {
        if (!button1EndSequence)
        {
            if (worldChoose.activeSelf)
            {

                world1Animator.SetBool("selected", false);
                world1Animator.SetBool("pressed", false);
                world2Animator.SetBool("selected", false);
                world2Animator.SetBool("pressed", false);
                world3Animator.SetBool("selected", false);
                world3Animator.SetBool("pressed", false);
                world4Animator.SetBool("selected", false);
                world4Animator.SetBool("pressed", false);
                backToMenuAnimator.SetBool("selected", false);
                backToMenuAnimator.SetBool("pressed", false);
            }

            if (LevelChoose.activeSelf)
            {

                level1Animator.SetBool("selected", false);
                level1Animator.SetBool("pressed", false);
                level2Animator.SetBool("selected", false);
                level2Animator.SetBool("pressed", false);
                level3Animator.SetBool("selected", false);
                level3Animator.SetBool("pressed", false);
                level4Animator.SetBool("selected", false);
                level4Animator.SetBool("pressed", false);
                level5Animator.SetBool("selected", false);
                level5Animator.SetBool("pressed", false);
            }

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
        //SoundManager.PlaySound(SoundType.MENUCHANGE);
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
