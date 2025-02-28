using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindState : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    public static RewindState Instance;
    private bool stopRewind = false;

    private static bool spacePressedThisFrame = false;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        _text.SetActive(state == GameState.Rewind);
        if (state == GameState.Rewind){ StartCoroutine(RunRewind(GamingState.PlayerMovementsStored)); }

    }

    public void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            stopRewind = true; // Interrumpe la corutina
        }
    }

    public IEnumerator RunRewind(MovementsManagerPlay movementsManager)
    {


        yield return new WaitForSeconds(0.2f);

        // Iterar sobre los comandos de movimiento
        for (int i = movementsManager.buttonspressed.Count - 1; i >= 0; i--)
        {
            if (GamingState.Instance != null)
            {         
                // Espera a que se presione la tecla de espacio (pero evita múltiples presiones rápidas)
                yield return new WaitUntil(() => (Input.GetKey(KeyCode.Q) && !spacePressedThisFrame && GamingState.Instance.getIfPlayersStopMoving()) || stopRewind);

                if (stopRewind)
                {
                    spacePressedThisFrame = false;
                    stopRewind = false;
                    GameManager.Instance.UpdateGameState(GameState.Gaming);
                    yield break; // Termina la corutina si se presiona "E"
                }

                // Marcar que la tecla espacio ha sido presionada
                spacePressedThisFrame = true;

                GamingState.Instance.SimulatemovementAtPlayerLevel();
                //movementsManager.executeComandReverse(i);


                movementsManager.buttonspressed.RemoveAt(i);

                // Marcar que la tecla espacio ha sido liberada
                spacePressedThisFrame = false;
            }
            else
            {
                Debug.Log("No GamingState");
            }
        }
        // Si llegas al final quita el rewind solo
        spacePressedThisFrame = false;
        stopRewind = false;
        GameManager.Instance.UpdateGameState(GameState.Gaming);
        yield break;

    }

}
