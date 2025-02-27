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
public class MovementsManagerPlay
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
