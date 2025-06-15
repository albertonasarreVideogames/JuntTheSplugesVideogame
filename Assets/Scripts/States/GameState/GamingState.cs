using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamingState : MonoBehaviour
{
    public static GamingState Instance;
    public static MovementsManagerPlay PlayerMovementsStored;
    private ManagePlayersMovement managePlayerMovement;
    private CheckPlayerSelected checkPlayerSelected;
    private ScenarioConditionsUpdater scenarioConditionsUpdater;
    private Player[] allPlayers;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
        SceneManager.sceneLoaded += OnLevelFinishedLoading;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayerMovementsStored = new MovementsManagerPlay();
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    //Invoked functions
    private void GameManagerOnGameStateChanged(GameState state)
    {
        if (state != GameState.Pause && state != GameState.Rewind && state != GameState.Gaming)
        {
            PlayerMovementsStored = new MovementsManagerPlay();
            if (allPlayers != null)
            {
                foreach (Player player in allPlayers)
                {
                    player.PlayerMovementsStored.buttonspressed.Clear();
                }
            }
        }

        if(state == GameState.Victory)
        {
             allPlayers = null;
        }
    }
  
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {

        Player.currentAllowedType = Player.PlayerType.Type1;
        MapLoader.Instance.LoadLevel();

        Player[] players = GameObject.FindGameObjectsWithTag("Player").Select(playerObject => playerObject.GetComponent<Player>()).ToArray();
        Enemy[] enemies = GameObject.FindGameObjectsWithTag("Enemy").Select(playerObject => playerObject.GetComponent<Enemy>()).ToArray();
        MainPlayer[] mainPlayesrs = GameObject.FindGameObjectsWithTag("MainPlayer").Select(playerObject => playerObject.GetComponent<MainPlayer>()).ToArray();
       
        allPlayers = players
            .Concat(enemies)
            .Concat(mainPlayesrs)
            .ToArray();
        Player[] playersWithMain = players.Concat(mainPlayesrs).ToArray();
     
        managePlayerMovement = new ManagePlayersMovement(allPlayers, mainPlayesrs, enemies, CheckSceneConditionsAfterMove);
        checkPlayerSelected = new CheckPlayerSelected();
        scenarioConditionsUpdater = new ScenarioConditionsUpdater(playersWithMain, enemies, getKeeperObjects(), getPulseObjects(), getswitchTypeMap());

    }

    // Update is called once per frame
    public void UpdateState()
    {
        managePlayerMovement.Execute();
        checkPlayerSelected.Execute();
        

        if (Input.GetKeyDown(KeyCode.Return))
        { 
            GameManager.Instance.UpdateGameState(GameState.Pause);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.Instance.UpdateGameState(GameState.Rewind);
        }
    }

    private void CheckSceneConditionsAfterMove()
    {
        scenarioConditionsUpdater.execute();
    }

    private Dictionary<Type, string> getswitchTypeMap()
    {
        return new Dictionary<Type, string>()
{
                { typeof(Pinchos), "OrangeSwitch" },
                { typeof(OrangeBloc), "OrangeSwitch" },
                { typeof(GreenPinchos), "GreenSwitch" },
                { typeof(GreenBloc), "GreenSwitch" },
                { typeof(BlueBloc), "BlueSwitch" },
                { typeof(BluePinchos), "BlueSwitch" },
                { typeof(PinkBlocs), "PinkSwitch" },
                { typeof(PinkPinchos), "PinkSwitch" }
            };
    }

    private ISwitchKeeperObjetiveElement[][] getKeeperObjects()
    {
        Pinchos[] pinchos = GameObject.FindGameObjectsWithTag("Pincho").Select(pinchoGameObject => pinchoGameObject.GetComponent<Pinchos>()).ToArray();
        GreenPinchos[] greenPinchos = GameObject.FindGameObjectsWithTag("GreenPincho").Select(pinchoGameObject => pinchoGameObject.GetComponent<GreenPinchos>()).ToArray();
        BluePinchos[] bluepinchos = GameObject.FindGameObjectsWithTag("BluePincho").Select(pinchoGameObject => pinchoGameObject.GetComponent<BluePinchos>()).ToArray();
        PinkPinchos[] pinkPinchos = GameObject.FindGameObjectsWithTag("PinkPincho").Select(pinchoGameObject => pinchoGameObject.GetComponent<PinkPinchos>()).ToArray();
        BlueBloc[] blueBlocs = GameObject.FindGameObjectsWithTag("Bloc").Select(blocGameObject => blocGameObject.GetComponent<BlueBloc>()).ToArray();
        PinkBlocs[] pinkBlocs = GameObject.FindGameObjectsWithTag("PinkBloc").Select(blocGameObject => blocGameObject.GetComponent<PinkBlocs>()).ToArray();
        OrangeBloc[] orangeBlocs = GameObject.FindGameObjectsWithTag("OrangeBloc").Select(blocGameObject => blocGameObject.GetComponent<OrangeBloc>()).ToArray();
        GreenBloc[] greenBlocs = GameObject.FindGameObjectsWithTag("GreenBloc").Select(blocGameObject => blocGameObject.GetComponent<GreenBloc>()).ToArray();

        ISwitchKeeperObjetiveElement[][] KeeperElements = {
                pinchos,
                orangeBlocs,
                greenPinchos,
                greenBlocs,
                blueBlocs,
                bluepinchos,
                pinkBlocs,
                pinkPinchos
            };
        return KeeperElements;
    }

    private ISwitcPulseObjetiveElement[][] getPulseObjects()
    {
        Pinchos[] pinchos = GameObject.FindGameObjectsWithTag("Pincho").Select(pinchoGameObject => pinchoGameObject.GetComponent<Pinchos>()).ToArray();
        GreenPinchos[] greenPinchos = GameObject.FindGameObjectsWithTag("GreenPincho").Select(pinchoGameObject => pinchoGameObject.GetComponent<GreenPinchos>()).ToArray();
        BluePinchos[] bluepinchos = GameObject.FindGameObjectsWithTag("BluePincho").Select(pinchoGameObject => pinchoGameObject.GetComponent<BluePinchos>()).ToArray();
        PinkPinchos[] pinkPinchos = GameObject.FindGameObjectsWithTag("PinkPincho").Select(pinchoGameObject => pinchoGameObject.GetComponent<PinkPinchos>()).ToArray();
        BlueBloc[] blueBlocs = GameObject.FindGameObjectsWithTag("Bloc").Select(blocGameObject => blocGameObject.GetComponent<BlueBloc>()).ToArray();
        PinkBlocs[] pinkBlocs = GameObject.FindGameObjectsWithTag("PinkBloc").Select(blocGameObject => blocGameObject.GetComponent<PinkBlocs>()).ToArray();
        OrangeBloc[] orangeBlocs = GameObject.FindGameObjectsWithTag("OrangeBloc").Select(blocGameObject => blocGameObject.GetComponent<OrangeBloc>()).ToArray();
        GreenBloc[] greenBlocs = GameObject.FindGameObjectsWithTag("GreenBloc").Select(blocGameObject => blocGameObject.GetComponent<GreenBloc>()).ToArray();

        ISwitcPulseObjetiveElement[][] KeeperElements = {
                pinchos,
                orangeBlocs,
                greenPinchos,
                greenBlocs,
                blueBlocs,
                bluepinchos,
                pinkBlocs,
                pinkPinchos
            };
        return KeeperElements;
    }

    public void SimulatemovementAtPlayerLevel()
    {
        managePlayerMovement.movePlayersWithLastMovementStored();
    }

    //TESTING
    public void Simulatemovement(Vector2 movement)
    {
        if(GameManager.Instance.State != GameState.Lose) { 
            managePlayerMovement.Simulatemovement(movement);
        }
    }

    public bool getIfPlayersStopMoving()
    {
        return managePlayerMovement.checkAnyPlayerIsmoving();
    }
}
