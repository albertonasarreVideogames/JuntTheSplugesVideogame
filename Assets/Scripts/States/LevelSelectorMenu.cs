using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using System.Text.RegularExpressions;

public class LevelSelectorMenu : MonoBehaviour
{
    public GameObject worldChoose;
    public GameObject LevelChoose;

    // Prefabs de botones
    public GameObject levelButtonPrefab;
    public GameObject backtoMenuPrefab;

    // Diccionario para mapear mundos a sus niveles
    private Dictionary<string, List<string>> worldLevels = new Dictionary<string, List<string>>();

    private Dictionary<string, Animator> worldAnimators = new Dictionary<string, Animator>();
    private Dictionary<string, List<Animator>> levelAnimators = new Dictionary<string, List<Animator>>();

    private MenuButtonController menuButtonController;
    private MenuButtonController menuButtonControllerLevels;
    private string worldSelected = "";
    private bool button1EndSequence = false;

    void Start()
    {
        // Llenar el diccionario de mundos y niveles
        worldLevels.Add("World1", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" });
        worldLevels.Add("World2", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" });
        worldLevels.Add("World3", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" });
        worldLevels.Add("World4", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" });
        worldLevels.Add("World5", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" });
        worldLevels.Add("World6", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" });
        worldLevels.Add("World7", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" });
        worldLevels.Add("World8", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5", "Level6", "Level7", "Level8", "Level9", "Level10" });
        worldLevels.Add("BackToMenu", new List<string> {});

        // Crear los animadores de mundos y niveles
        InitializeWorldsAndLevels();

        menuButtonController = new MenuButtonController(worldLevels.Count - 1);
    }

    void Update()
    {
        SetDefaultValues();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuButtonController.Update();
            GoToMenu();
        }

        // Manejo de selección de mundo
        if (worldChoose.activeSelf)
        {
            menuButtonController.Update();
            string selectedWorld = worldLevels.Keys.ToList()[menuButtonController.index];
            HandleWorldSelection(selectedWorld);
        }

        // Manejo de selección de nivel
        if (LevelChoose.activeSelf)
        {
            menuButtonControllerLevels.Update();
            int selectedLevelIndex = menuButtonControllerLevels.index;
            HandleLevelSelection(worldSelected, selectedLevelIndex);
        }
    }

    private void InitializeWorldsAndLevels()
    {
        // Crear animadores para los mundos
        worldAnimators.Clear();
        int i = 0;
        foreach (var world in worldLevels.Keys)
        {        

            int numberOfWorlds = worldLevels.Count;

            float minPositionY = -636f;
            float maxPositionY = 612f;

            float spaceBetweenButtons = (maxPositionY - minPositionY) / (numberOfWorlds + 1);
            GameObject worldButton;
            if (world == "BackToMenu") { worldButton = Instantiate(backtoMenuPrefab, worldChoose.transform); } else { worldButton = Instantiate(levelButtonPrefab, worldChoose.transform); }
            
            worldButton.name = world;

            worldButton.transform.GetComponentInChildren<Text>().text = world;

            // Calcular la posición Y del botón (invertido)
            // Invertimos la fórmula para que el nivel 1 esté en la parte superior
            float buttonPositionY = maxPositionY - (spaceBetweenButtons * (i + 1));

            // Asignamos la posición del botón
            worldButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, buttonPositionY);
            worldAnimators.Add(world, worldButton.GetComponent<Animator>());
            SetButtonRed(worldButton);
            i++;

        }


        // Crear botones de niveles dinámicamente
        levelAnimators.Clear();
        foreach (var world in worldLevels.Keys)
        {
            List<Animator> animators = new List<Animator>();

            // Calculamos la cantidad de niveles para este mundo
            int numberOfLevels = worldLevels[world].Count;

            // Calculamos el rango de distribución
            float minPositionY = -636f;
            float maxPositionY = 612f;

            // Si hay niveles, distribuimos la distancia entre ellos
            float spaceBetweenButtons = (maxPositionY - minPositionY) / (numberOfLevels + 1);

            foreach (var (index, level) in worldLevels[world].Select((level, index) => (index, level)))
            {
                GameObject levelButton = Instantiate(levelButtonPrefab, LevelChoose.transform);
                levelButton.name = world + "_Level" + (index + 1);  // Asignamos un nombre único

                // Asignamos el texto del nivel al botón
                levelButton.transform.GetComponentInChildren<Text>().text = level;

                // Calcular la posición Y del botón (invertido)
                // Invertimos la fórmula para que el nivel 1 esté en la parte superior
                float buttonPositionY = maxPositionY - (spaceBetweenButtons * (index + 1));

                // Asignamos la posición del botón
                levelButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, buttonPositionY);

                // Obtén el Animator y lo agregamos a la lista
                Animator levelAnimator = levelButton.GetComponent<Animator>();
                animators.Add(levelAnimator);
                SetButtonRed(levelButton);
                levelButton.SetActive(false);
            }

            // Añadimos los animadores de los niveles al diccionario
            levelAnimators.Add(world, animators);
        }
    }


    private void SetDefaultValues()
    {
        if (!button1EndSequence)
        {
            ResetWorldAnimators();
            ResetLevelAnimators();
        }
    }

    private void HandleWorldSelection(string world)
    {
        ExecuteButtonAction(() =>
        {
            if (world == "BackToMenu")
            {
                GoToMenu();
            }
            else
            {
                worldSelected = world;
                if (worldChoose.transform.Find(world).gameObject.transform.Find("Red").gameObject.activeSelf) { SoundManager.PlaySound(SoundType.MENUDENIED); return; }
                SoundManager.PlaySound(SoundType.MENUSELECTED);
                ShowLevelsForWorld(worldSelected);
                StartCoroutine(SelectWorld(1.0f, world));
            }
        }, worldAnimators[world]);
    }

    private void HandleLevelSelection(string world, int levelIndex)
    {
        ExecuteButtonAction(() =>
        {
            string selectedLevel = worldLevels[world][levelIndex];
            if (LevelChoose.transform.Find(worldSelected + "_" + selectedLevel).gameObject.transform.Find("Red").gameObject.activeSelf) { SoundManager.PlaySound(SoundType.MENUDENIED); return; }
            SoundManager.PlaySound(SoundType.MENUSELECTED);
            Debug.Log(worldSelected + selectedLevel);
            GameManager.Instance.UpdateGameState(GameState.Gaming);
            SceneManager.LoadScene(worldSelected + selectedLevel);
        }, levelAnimators[world][levelIndex]);
    }

    private void ResetWorldAnimators()
    {
        foreach (var animator in worldAnimators.Values)
        {
            animator.SetBool("selected", false);
            animator.SetBool("pressed", false);
        }
    }

    private void ResetLevelAnimators()
    {
        foreach (var worldAnimatorsList in levelAnimators.Values)
        {
            foreach (var animator in worldAnimatorsList)
            {
                animator.SetBool("selected", false);
                animator.SetBool("pressed", false);
            }
        }
    }

    private void GoToMenu()
    {
        foreach (Transform hijo in LevelChoose.transform)
        {
            hijo.gameObject.SetActive(false);
            if(hijo.gameObject.name == "Quit") { hijo.gameObject.SetActive(true); }
        }
        LevelChoose.SetActive(false);
        worldChoose.SetActive(true);
        this.gameObject.SetActive(false);
    }

    protected void ExecuteButtonAction(Action actionToExecute, Animator anim)
    {
        anim.SetBool("selected", true);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetBool("pressed", true);          
            actionToExecute.Invoke();
        }
    }

    private IEnumerator SelectWorld(float time, string world)
    {
        yield return new WaitForSeconds(time);

        menuButtonControllerLevels = new MenuButtonController(worldLevels[world].Count -1);
        worldChoose.SetActive(false);
        LevelChoose.SetActive(true);
    }

    private void ShowLevelsForWorld(string world)
    {
       
        // Ahora, activamos solo los botones correspondientes al mundo seleccionado
        List<string> levelsForWorld = worldLevels[world]; // Obtén los niveles del mundo seleccionado

        for (int i = 0; i < levelsForWorld.Count; i++)
        {
            string buttonName = world + "_Level" + (i + 1);  // El nombre dinámico
            GameObject levelButton = LevelChoose.transform.Find(buttonName)?.gameObject;

            if (levelButton != null)
            {
                levelButton.SetActive(true);
            }
        }
    }

    private void SetButtonRed(GameObject levelButton)
    {

        (int savedWorld, int savedLevel) = LoadPlayerProgress();

        int world, level;

        ParseLevelName(levelButton.name, out world, out level);
        // Comparar el nivel actual con el nivel guardado.
        // Solo se pone en rojo si el jugador no ha llegado hasta ahi.
        if (world > savedWorld || (world == savedWorld && level > savedLevel + 1))
        {
            if((world == savedWorld + 1 && savedLevel >= 8 && (level == -1 || level == 1)) || (world == savedWorld && savedLevel >= 8)) { return; }
            // Buscar el hijo llamado "Red" dentro de levelButton
            Transform redTransform = levelButton.transform.Find("Red");

            // Si lo encontramos, activamos el GameObject
            if (redTransform != null)
            {
                redTransform.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("No se encontró el objeto 'Red' como hijo.");
            }
        }
    }

    private (int, int) LoadPlayerProgress()
    {
        // Si no se ha guardado nunca progreso, retornar un valor predeterminado (por ejemplo, mundo 0, nivel 0)
        int savedWorld = PlayerPrefs.GetInt("LastWorld", 0);
        int savedLevel = PlayerPrefs.GetInt("LastLevel", 0);

        return (savedWorld, savedLevel);
    }

    private bool ParseLevelName(string sceneName, out int world, out int level)
    {
        // Inicializamos los valores en -1 por si falla el parseo
        world = -1;
        level = -1;

        // Usamos una expresión regular para capturar el formato 'WorldX_LevelY' o 'WorldX'
        Regex regex = new Regex(@"World(\d+)(_Level(\d+))?");
        Match match = regex.Match(sceneName);

        if (match.Success)
        {
            // Extraemos el número del mundo
            world = int.Parse(match.Groups[1].Value);

            // Si existe la parte de Level (es decir, no es null), extraemos el número del nivel
            if (match.Groups[3].Success)
            {
                level = int.Parse(match.Groups[3].Value);
            }

            return true;
        }
        else
        {
            Debug.Log("El nombre de la escena no sigue el formato esperado.");
            return false;
        }
    }

}



