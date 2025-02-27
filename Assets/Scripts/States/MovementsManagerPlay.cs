using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonPresed
{
    RIGHT,
    LEFT,
    UP,
    DOWN,
    CHANGEPLAYER,
    EMPTY
}
public class MovementsManagerPlay
{
    public List<ButtonPresed> buttonspressed = new List<ButtonPresed>();

    private Vector2 moventRight = new Vector2(1, 0);
    private Vector2 moventLeft = new Vector2(-1, 0);
    private Vector2 moventUp = new Vector2(0, 1);
    private Vector2 moventDown = new Vector2(0, -1);
    private Vector2 empty = new Vector2(0, 0);

    public void executeComandReverse(int i)
    {
        // Verificar que el índice i es válido para evitar desbordamientos
        if (i < 0 || i >= buttonspressed.Count)
        {
            Debug.LogError("Índice fuera de rango");
            return;
        }

        // Obtener el tipo de movimiento del botón presionado
        ButtonPresed button = buttonspressed[i];
        // Determinar el movimiento inverso según el tipo de botón
        switch (button)
        {
            case ButtonPresed.RIGHT:
                GamingState.Instance.Simulatemovement(moventLeft);
                break;

            case ButtonPresed.LEFT:
                GamingState.Instance.Simulatemovement(moventRight);
                break;

            case ButtonPresed.UP:
                GamingState.Instance.Simulatemovement(moventDown);
                break;

            case ButtonPresed.DOWN:
                GamingState.Instance.Simulatemovement(moventUp);
                break;

            case ButtonPresed.CHANGEPLAYER:
                Player.changePlayerTypeToMove();
                break;

            case ButtonPresed.EMPTY:
                break;

            default:
                Debug.LogWarning("Comando no reconocido: " + button);
                break;
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

    public void addMovement(Vector2 movement)
    {
        // Determinar el tipo de movimiento según el Vector2
        if (movement == moventRight)
        {
            buttonspressed.Add(ButtonPresed.RIGHT);
        }
        else if (movement == moventLeft)
        {
            buttonspressed.Add(ButtonPresed.LEFT);
        }
        else if (movement == moventUp)
        {
            buttonspressed.Add(ButtonPresed.UP);
        }
        else if (movement == moventDown)
        {
            buttonspressed.Add(ButtonPresed.DOWN);
        }
        else
        {
            // Si el movimiento no es uno de los predefinidos, podrías agregar un tipo especial o manejarlo de otro modo.
            buttonspressed.Add(ButtonPresed.EMPTY);
        }

        
    }

    public Vector2 getButtonOnLastPosition()
    {

        // Obtener el tipo de movimiento del botón presionado
        // Verificar si la lista tiene elementos
        if (buttonspressed.Count == 0)
        {
            // Si la lista está vacía, retornar un valor "empty"
            return empty;
        }

        // Obtener el tipo de movimiento del botón presionado (último elemento)
        ButtonPresed lastButton = buttonspressed[buttonspressed.Count - 1];

        // Variable para almacenar el resultado
        Vector2 movement = empty; // Valor predeterminado

        // Determinar el movimiento inverso según el tipo de botón
        switch (lastButton)
        {
            case ButtonPresed.RIGHT:
                movement = moventLeft;
                break;

            case ButtonPresed.LEFT:
                movement = moventRight;
                break;

            case ButtonPresed.UP:
                movement = moventDown;
                break;

            case ButtonPresed.DOWN:
                movement = moventUp;
                break;

            case ButtonPresed.CHANGEPLAYER:
                Player.changePlayerTypeToMove();
                movement = empty;
                break;

            case ButtonPresed.EMPTY:
                movement = empty;
                break;

            default:
                movement = empty;
                break;
        }

        // Eliminar el último elemento después de ejecutar el comando
        buttonspressed.RemoveAt(buttonspressed.Count - 1);       

        // Retornar el movimiento calculado
        return movement;

    }

    public void reverseTheLastMovement()
    {

        if (buttonspressed.Count == 0)
        {
            // Si la lista está vacía, retornar un valor "empty"
            return;
        }

        // Obtener el tipo de movimiento del botón presionado (último elemento)
        ButtonPresed lastButton = buttonspressed[buttonspressed.Count - 1];

        switch(lastButton){

            case ButtonPresed.RIGHT:
                buttonspressed[buttonspressed.Count - 1] = ButtonPresed.LEFT;         
                break;

            case ButtonPresed.LEFT:
                buttonspressed[buttonspressed.Count - 1] = ButtonPresed.RIGHT;
                break;

            case ButtonPresed.UP:
                buttonspressed[buttonspressed.Count - 1] = ButtonPresed.DOWN;
                break;

            case ButtonPresed.DOWN:
                buttonspressed[buttonspressed.Count - 1] = ButtonPresed.UP;
                break;

            case ButtonPresed.CHANGEPLAYER:
                break;
            case ButtonPresed.EMPTY:
                break;

            default:
                break;

        }



    }
}
