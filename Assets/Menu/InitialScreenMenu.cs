using System.Collections;
using UnityEngine;
using Cinemachine;

public class InitialScreenMenu : MonoBehaviour
{
    public CinemachineVirtualCamera menuCamera;
    public GameObject menu;
    public Animator titleLogoAnim;
    public GameObject pressAButton;
    public Animator buttonsAnim;
    
    void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        if(Input.anyKey && !Input.GetKeyDown(KeyCode.Return) && !Input.GetKeyUp(KeyCode.Return) && !Input.GetKey(KeyCode.Return)) 
        {
            menuCamera.gameObject.SetActive(true);
            menu.SetActive(true);
            titleLogoAnim.SetBool("Transition", true);
            pressAButton.SetActive(false);
            StartCoroutine(ExecuteAfterTime(1f));
        }

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        buttonsAnim.enabled = false; //Used to fix a bug where the "New Game" Text animation of the menu never came back to deselected state when it wasn't selected
    }
}
