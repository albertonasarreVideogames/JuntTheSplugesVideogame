using System;
using System.Collections;
using UnityEngine;
//using UnityEngine.InputSystem;

public class MenuBase : MonoBehaviour
{
    public MenuButtonController menuButtonController;
    public bool disableOnce;
    public GameObject surePanel;
    private AudioSource audioSource;
    //private InputActionAsset MenuControls;
    //protected InputAction Accept;

    protected void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //Accept = new InputAction(binding: "<Keyboard>/enter");
        //Accept.AddBinding("<Gamepad>/buttonSouth");
        //Accept.Enable();
        //Accept.Dispose();
        //Debug.Log(Accept.bindings[0]);

    }

    private void OnDisable()
    {
        //Accept.Disable();
    }

    private void OnEnable()
    {
        //Accept.Enable();
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
    protected IEnumerator LoadMainMenu(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Debug.Log("main menu");
        //LevelManager.Instance.InitialMenu();
    }

    protected IEnumerator RestartLevel(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Debug.Log("retry level");
        //LevelManager.Instance.RestartLevel();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit ();
#endif
    }

    protected void ShowSurePanel()
    {
        surePanel.SetActive(true);
    }

    protected IEnumerator LoadFirstLevel(float time)
    {
        yield return new WaitForSeconds(time);

        //LevelManager.Instance.LoadFirstLevel();
    }

    protected IEnumerator ShowResults(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        //LevelManager.Instance.ShowResults();
    }
}