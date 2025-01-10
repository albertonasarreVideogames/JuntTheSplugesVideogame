using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapLoader : MonoBehaviour
{
    public static MapLoader Instance;
    public int NumberKindPlayers = 1;
    private Tilemap map;

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

    public void LoadLevel()
    {
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
            Instantiate(dataFromTiles[clickedTile].Prefab, map.GetCellCenterWorld(position), Quaternion.identity);

            Player player = dataFromTiles[clickedTile].Prefab.GetComponent<Player>();
            if (player != null) { updateNumberPLayersOnLevel(player); }

        }
        // hide objects layer
        map.GetComponent<TilemapRenderer>().sortingLayerName = "Default";
        SwitchManager.Initialize();
    }

    private void updateNumberPLayersOnLevel(Player player)
    {
        int playerNumber = (int)player.playerType + 1;
        if (playerNumber > NumberKindPlayers)
        {
            NumberKindPlayers = playerNumber;
        }
    }
}
