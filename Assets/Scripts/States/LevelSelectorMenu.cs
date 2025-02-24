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

    public Animator world1Animator;
    public Animator world2Animator;
    public Animator world3Animator;
    public Animator world4Animator;
    public Animator backToMenuAnimator;
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
    void Start()
    {
        menuButtonController.index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SetDefaultValues();

        switch (menuButtonController.index)
        {
            case (int)WorldsOptions.World1:
                ExecuteButtonAction(() =>
                {
                    Debug.Log("World1");
                }, world1Animator);
                break;

            case (int)WorldsOptions.World2:
                ExecuteButtonAction(() =>
                {
                    Debug.Log("World2");
                }, world2Animator);
                break;

            case (int)WorldsOptions.World3:
                ExecuteButtonAction(() =>
                {
                    Debug.Log("World3");
                }, world3Animator);
                break;
            case (int)WorldsOptions.World4:
                ExecuteButtonAction(() =>
                {
                    Debug.Log("World4");
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

    private void SetDefaultValues()
    {
        if (!button1EndSequence)
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
}
