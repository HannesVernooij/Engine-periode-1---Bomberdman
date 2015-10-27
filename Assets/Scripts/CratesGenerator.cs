using UnityEngine;
using System.Collections;

public class CratesGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject crate;

    private MapGenerator mapGen;
    private bool keepSpawning = true;

    void Start()
    {
        mapGen = gameObject.GetComponent<MapGenerator>();
    }

    void Update()
    {
        SpawnCrates();
    }

    private void SpawnCrates()
    {
        for (int x = 0; x < mapGen.mapWidth; x++)
        {
            for (int z = 0; z < mapGen.mapHeight; z++)
            {
                if (mapGen.GetTile(x, z) == null)
                {
                    mapGen.mapArray[x, z] = Instantiate(crate, new Vector3(x, 0.5f, z), Quaternion.identity) as GameObject;
                    mapGen.mapArray[x, z].name = "Crate_" + x + "_" + z;
                }
            }
        }
    }
}