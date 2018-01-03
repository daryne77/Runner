using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -13.9f;
    private float tileLength = 13.9f;
    private int amnTilesOnScreen = 12;
    private float safeZone = 30.0f;
    private float lastTileType = 0;

    private List<GameObject> activeTiles;

	// Use this for initialization
	private void Start () {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for (int i = 0; i < amnTilesOnScreen; ++i)
        {
            if (i < 3)
            {
                SpawnTile(0);
            } else
            {
                SpawnTile(RandomPrefab());
            }
        }
        
    }
	
	// Update is called once per frame
	private void Update () {
        if(playerTransform.position.z - safeZone > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile(RandomPrefab());
            DeleteTile();
        }
	}

    private void SpawnTile(int prefabIndex)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
        lastTileType = prefabIndex;
        
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefab()
    {
        int nextTileType;
        do
        {
            nextTileType = Random.Range(0, tilePrefabs.Length);
        }
        while (nextTileType == lastTileType);

        return nextTileType;
    }
}
