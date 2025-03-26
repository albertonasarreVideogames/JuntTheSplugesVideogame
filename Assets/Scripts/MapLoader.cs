using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour
{
    public static MapLoader Instance;
    public int NumberKindPlayers = 1;
    public GameObject StartsBackgound;
    public GameObject GlobalVolume;
    private Tilemap map;
    private Tilemap backgroundTilemap;
    private Tilemap lavaTilemap;
    public GameObject SplungesTypesPanel;

    [SerializeField]
    private List<TileInfo> tiledatas;

    private Dictionary<TileBase, TileInfo> dataFromTiles;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        dataFromTiles = new Dictionary<TileBase, TileInfo>();

        //Add correspondece with tile and tile information
        foreach(var tileData in tiledatas)
        {
            foreach(var tile in tileData.tiles)
            {
                dataFromTiles.Add(tile,tileData);
            }
        }

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadLevel()
    {
        Instantiate(StartsBackgound, Vector3.zero, Quaternion.identity);
        Instantiate(GlobalVolume, Vector3.zero, Quaternion.identity);
        NumberKindPlayers = 1;
        map = GameObject.Find("objects").GetComponent<Tilemap>();
        //full map with gameobjects
        foreach (var position in map.cellBounds.allPositionsWithin)
        {
            if (!map.HasTile(position))
            {
                continue;
            }
            // Tile is not empty; do stuff
            TileBase clickedTile = map.GetTile(position);

            GameObject prefab = dataFromTiles[clickedTile].Prefab;
            Vector3 positionOnmap = map.GetCellCenterWorld(position);

            if (prefab.GetComponent<IBloc>() != null) { positionOnmap += new Vector3(0, ((40 - 32) / 2f / map.cellSize.y) / 32, 0);  }

            GameObject instance = Instantiate(prefab, positionOnmap, Quaternion.identity);

            Player player = dataFromTiles[clickedTile].Prefab.GetComponent<Player>();
            Ipinchos pincho = instance.GetComponent<Ipinchos>();
            if (player != null) { updateNumberPLayersOnLevel(player); }
            if( pincho != null) { pincho.SetShaderColor(); }

        }
        // hide objects layer
        SplungesTypesPanel.SetActive(NumberKindPlayers > 1);
        map.GetComponent<TilemapRenderer>().sortingLayerName = "Default";
        SwitchManager.Initialize();
        CheckAndRemoveOverlappingTiles();
    }

    private void updateNumberPLayersOnLevel(Player player)
    {
        int playerNumber = (int)player.playerType + 1;
        if (playerNumber > NumberKindPlayers)
        {
            NumberKindPlayers = playerNumber;
        }
    }

    private void CheckAndRemoveOverlappingTiles()
    {
        backgroundTilemap = GameObject.Find("Background").GetComponent<Tilemap>();
        lavaTilemap = GameObject.Find("Lava").GetComponent<Tilemap>();
        // Obtener todas las posiciones con tiles en el Tilemap de Lava
        BoundsInt bounds = lavaTilemap.cellBounds;
            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    Vector3Int position = new Vector3Int(x, y, 0);

                    // Comprobar si hay un tile en ambas Tilemaps
                    if (lavaTilemap.HasTile(position) && backgroundTilemap.HasTile(position))
                    {
                        // Eliminar el tile del background si hay uno en la misma posición en el lava
                        backgroundTilemap.SetTile(position, null);

                    }
                }
            }

        lavaTilemap.GetComponent<TilemapRenderer>().enabled = false;
    }

   
    
    // funcion no que de momento no se usa para ajustar el tammaño de la celdas si cambia la resolucion. Tener en cuenta que los personajes se mueven segun el tamaño de las celdas, que por defecto es uno, asi que habria que cambiar eso tambnein
    private void AdjustCameraAndGrid()
    {
        int cellsX = 26; // Número de celdas en horizontal
        int cellsY = 14; // Número de celdas en vertical

        // Calcular la relación de aspecto de la pantalla
        float aspectRatio = (float)Screen.width / Screen.height;

        // Calculamos el tamaño visible en función de la relación de aspecto
        // El tamaño de la cámara es tal que se ajusta al tamaño de las celdas
        float desiredSize = Mathf.Max(cellsX / aspectRatio, cellsY) / 2;

        // Ajustar el tamaño de la cámara
        Camera.main.orthographicSize = desiredSize;

        // Calculamos el tamaño de las celdas en base al tamaño de la cámara
        float visibleWidth = 2 * Camera.main.orthographicSize * aspectRatio;
        float cellSize = visibleWidth / cellsX;

        // Ajustar el tamaño de las celdas
        Grid gridLayout = GameObject.Find("Grid").GetComponent<Grid>();

        gridLayout.cellSize = new Vector2(cellSize, cellSize);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 0.35f, Camera.main.transform.position.z);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cuando la escena esté cargada, llamamos a AdjustCameraAndGrid
        //if (GameManager.Instance.State == GameState.Gaming)
        //{
            AdjustCameraAndGrid();
        //}
    }

}
