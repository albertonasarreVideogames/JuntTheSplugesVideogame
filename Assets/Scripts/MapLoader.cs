using System;
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
            GameObject instance = Instantiate(dataFromTiles[clickedTile].Prefab, map.GetCellCenterWorld(position), Quaternion.identity);

            Player player = dataFromTiles[clickedTile].Prefab.GetComponent<Player>();
            Ipinchos pincho = instance.GetComponent<Ipinchos>();
            if (player != null) { updateNumberPLayersOnLevel(player); }
            if( pincho != null) { updateShaderOptions(pincho); }

        }
        // hide objects layer
        map.GetComponent<TilemapRenderer>().sortingLayerName = "Default";
        SwitchManager.Initialize();
    }

    private void updateShaderOptions(Ipinchos pincho)
    {
        SpriteRenderer spriteRenderer = pincho.GetComponent<SpriteRenderer>();

        // Asegúrate de que el material no sea compartido
        spriteRenderer.material = new Material(spriteRenderer.material);

        spriteRenderer.material.SetFloat("_RandomSeed", pincho.transform.position.x * 100f);
        spriteRenderer.material.SetFloat("_RandomSeed2", pincho.transform.position.y * 100f);

        if (pincho.initialStatus == Ipinchos.InitialStatus.DOWN) { spriteRenderer.material.SetFloat("_Power", 0); }

        if (pincho.GetType() == typeof(Pinchos)) {
            Color hdrColor = new Color(1.0f, 0.5f, 0.0f) * 3f;
            spriteRenderer.material.SetColor("_Color", hdrColor); 
        }

        if (pincho.GetType() == typeof(PinkPinchos))
        {
            Color hdrColor = new Color(1.0f, 0.0f, 1.0f) * 2f;
            spriteRenderer.material.SetColor("_Color", hdrColor);
        }

        if (pincho.GetType() == typeof(GreenPinchos))
        {
            Color hdrColor = new Color(0.0f, 1.0f, 0.0f) * 3f;
            spriteRenderer.material.SetColor("_Color", hdrColor);
        }
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
