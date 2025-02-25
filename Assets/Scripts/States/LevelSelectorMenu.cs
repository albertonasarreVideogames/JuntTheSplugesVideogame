using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

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
        worldLevels.Add("World1", new List<string> { "Level1", "Level2", "Level3", "Level4", "Level5" });
        worldLevels.Add("World2", new List<string> { "Level1", "Level2", "Level3" });
        worldLevels.Add("World3", new List<string> { "Level1", "Level2" });
        worldLevels.Add("World4", new List<string> { "Level1", "Level2", "Level3", "Level4" });
        worldLevels.Add("BackToMenu", new List<string> { "Level1", "Level2", "Level3", "Level4" });

        // Crear los animadores de mundos y niveles
        InitializeWorldsAndLevels();

        menuButtonController = new MenuButtonController(worldLevels.Count - 1);
    }

    void Update()
    {
        SetDefaultValues();

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

            float minPositionY = -736f;
            float maxPositionY = 512f;

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
            float minPositionY = -736f;
            float maxPositionY = 512f;

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
                button1EndSequence = true;
                GoToMenu();
            }
            else
            {
                worldSelected = world;
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
        GameManager.Instance.UpdateGameState(GameState.Menu);
        SceneManager.LoadScene(0);
    }

    protected void ExecuteButtonAction(Action actionToExecute, Animator anim)
    {
        anim.SetBool("selected", true);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetBool("pressed", true);
            SoundManager.PlaySound(SoundType.MENUSELECTED);
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

}



