using UnityEngine;
using UnityEngine.SceneManagement;
using static Tags;

public class MenuButtonController : MonoBehaviour
{
    // Used to cycle between our menu buttons when we press up and down like any other normal menu behaviour, it complements the MenuButton script.
    public int index;
    public int maxIndex; //TODO: Crear un dictionary en LevelManager que en funcion del menú te devuelva el maxIndex. Y luego cambiar a privado.
    private bool keyDown;

    void Update()
    {
        //var sceneName = SceneManager.GetActiveScene().name;
        //if (sceneName == ScenesEnum.DeadScreen.ToString() || gameObject.tag == tags.MenuHorizontal.ToString())
        //{
            //IndexHandler("Horizontal");
        //}
        //else
        //{
            IndexHandler("Vertical");
        //}
    }

    private void IndexHandler(string axis)
    {
        var sceneName = SceneManager.GetActiveScene().name;
        if (gameObject.tag == tags.MenuHorizontal.ToString() || sceneName == ScenesEnum.DeadScreen.ToString())
        {
            if (Input.GetAxisRaw(axis) != 0)
            {
                if (!keyDown)
                {
                    if (Input.GetAxisRaw(axis) > 0)
                    {
                        if (index < maxIndex)
                        {
                            index++;
                        }
                        else
                        {
                            index = 0;
                        }
                    }
                    else if (Input.GetAxisRaw(axis) < 0)
                    {
                        if (index > 0)
                        {
                            index--;
                        }
                        else
                        {
                            index = maxIndex;
                        }
                    }
                    keyDown = true;
                }
            }
            else
            {
                keyDown = false;
            }
        }
        else
        {
            if (Input.GetAxisRaw(axis) != 0)
            {
                if (!keyDown)
                {
                    if (Input.GetAxisRaw(axis) < 0)
                    {
                        if (index < maxIndex)
                        {
                            index++;
                        }
                        else
                        {
                            index = 0;
                        }
                    }
                    else if (Input.GetAxisRaw(axis) > 0)
                    {
                        if (index > 0)
                        {
                            index--;
                        }
                        else
                        {
                            index = maxIndex;
                        }
                    }
                    keyDown = true;
                    if (GameManager.Instance.State == GameState.Pause || GameManager.Instance.State == GameState.Menu) { SoundManager.PlaySound(SoundType.MENUCHANGE); }
                    Debug.Log("Sound exected. as you see this logs on more time each arrow moves it means this class is instanciate twice and it needs to be solved");
                    
                }
            }
            else
            {
                keyDown = false;
            }
        }
       
    }
}