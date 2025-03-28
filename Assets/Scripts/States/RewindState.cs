using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewindState : MonoBehaviour
{
    [SerializeField] private GameObject _text;
    [SerializeField] private GameObject _vhsEffect;
    public static RewindState Instance;
    private bool stopRewind = false;
    public GameObject rewindEffects;


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
        rewindEffects.SetActive(state == GameState.Rewind); 
        _text.SetActive(state == GameState.Rewind);
        _vhsEffect.SetActive(state == GameState.Rewind);
        if (state == GameState.Rewind){ StartCoroutine(RunRewind(GamingState.PlayerMovementsStored)); }

    }

    public void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            stopRewind = true; // Interrumpe la corutina
        }
        if (Input.GetKeyUp(KeyCode.Q)) { SoundManager.ChangeOSTpitch(1f); _vhsEffect.GetComponent<Image>().material.SetFloat("_Velocity", 3); }
    }

    public IEnumerator RunRewind(MovementsManagerPlay movementsManager)
    {


        yield return new WaitForSeconds(0.2f);

        // Iterar sobre los comandos de movimiento
        for (int i = movementsManager.buttonspressed.Count - 1; i >= 0; i--)
        {
            if (GamingState.Instance != null)
            {

                yield return new WaitUntil(() => (Input.GetKey(KeyCode.Q) && GamingState.Instance.getIfPlayersStopMoving()) || stopRewind);
                
                if (stopRewind)
                {
                    SoundManager.ChangeOSTpitch(1);
                    stopRewind = false;
                    GameManager.Instance.UpdateGameState(GameState.Gaming);
                    yield break; // Termina la corutina si se presiona "E"
                }    

                GamingState.Instance.SimulatemovementAtPlayerLevel();
                SoundManager.ChangeOSTpitch(-1.5f);
                _vhsEffect.GetComponent<Image>().material.SetFloat("_Velocity", 1);
                movementsManager.buttonspressed.RemoveAt(i);              

            }
            else
            {
                Debug.Log("No GamingState");
            }
        }
        // Si llegas al final quita el rewind solo
        SoundManager.ChangeOSTpitch(1f);
        stopRewind = false;
        GameManager.Instance.UpdateGameState(GameState.Gaming);
        yield break;

    }

}
