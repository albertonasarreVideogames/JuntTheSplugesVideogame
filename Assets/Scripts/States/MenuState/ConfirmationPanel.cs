using System;
using UnityEngine;

public class ConfirmationPanel : MonoBehaviour
{
    public GameObject panel;
    public Action ConfirmAction;
    private bool hasInit = false;

    public void Initiate(GameObject panel, Action toExecute)
    {
        this.panel = panel;
        ConfirmAction = toExecute;
        panel.SetActive(true);
        hasInit = true;
    }

    private void Update()
    {
        if (hasInit)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ConfirmAction.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                panel.SetActive(false);
                Destroy(this);
            }
        }
    }
}

