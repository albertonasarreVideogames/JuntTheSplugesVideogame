using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonPresed
{
    RIGHT,
    LEFT,
    UP,
    DOWN,
    CHANGEPLAYER
}
public class MovementsManager
{
    public List<ButtonPresed> buttonspressed = new List<ButtonPresed>();

    private Vector2 moventRight = new Vector2(1, 0);
    private Vector2 moventLeft = new Vector2(-1, 0);
    private Vector2 moventUp = new Vector2(0, 1);
    private Vector2 moventDown = new Vector2(0, -1);

    public void executeComand(int i)
    {
        if (buttonspressed[i] == ButtonPresed.RIGHT)
        {
            GamingState.Instance.Simulatemovement(moventRight);
        }
        if (buttonspressed[i] == ButtonPresed.LEFT)
        {
            GamingState.Instance.Simulatemovement(moventLeft);
        }
        if (buttonspressed[i] == ButtonPresed.UP)
        {
            GamingState.Instance.Simulatemovement(moventUp);
        }
        if (buttonspressed[i] == ButtonPresed.DOWN)
        {
            GamingState.Instance.Simulatemovement(moventDown);
        }
        if (buttonspressed[i] == ButtonPresed.CHANGEPLAYER)
        {
            Player.changePlayerTypeToMove();

            GameObject SplungesTypesPanel = MapLoader.Instance.SplungesTypesPanel;

            Transform splunges = SplungesTypesPanel.transform.GetChild(0); // Obtiene "Splunges"
            GameObject splunje1 = splunges.GetChild(0).gameObject;
            GameObject splunje2 = splunges.GetChild(1).gameObject;
            GameObject splunje3 = splunges.GetChild(2).gameObject;

            Canvas canvasHija = splunje1.transform.GetChild(0).gameObject.GetComponent<Canvas>();
            canvasHija.overrideSorting = true;

            splunje1.transform.GetChild(0).gameObject.SetActive(Player.currentAllowedType == Player.PlayerType.Type1);
            splunje2.transform.GetChild(0).gameObject.SetActive(Player.currentAllowedType == Player.PlayerType.Type2);
            splunje3.transform.GetChild(0).gameObject.SetActive(Player.currentAllowedType == Player.PlayerType.Type3);

            canvasHija.overrideSorting = true;
        }
    }

    public void AddMovementRight(int times) {

        for (int i = 0; i < times; i++)
        {
            buttonspressed.Add(ButtonPresed.RIGHT);
        }
    }

    public void AddMovementLeft(int times)
    {
        for (int i = 0; i < times; i++)
        {
            buttonspressed.Add(ButtonPresed.LEFT);
        }
    }

    public void AddMovementUp(int times)
    {
        for (int i = 0; i < times; i++)
        {
            buttonspressed.Add(ButtonPresed.UP);
        }
    }

    public void AddMovementDown(int times)
    {
        for (int i = 0; i < times; i++)
        {
            buttonspressed.Add(ButtonPresed.DOWN);
        }
    }

    public void AddMChangePlayer(int times)
    {
        for (int i = 0; i < times; i++)
        {
            buttonspressed.Add(ButtonPresed.CHANGEPLAYER);
        }
    }
}
