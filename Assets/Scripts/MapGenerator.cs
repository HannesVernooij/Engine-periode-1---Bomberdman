using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{
    public GameObject wall;
    public GameObject floorPrefab;
    GameObject floor;
    //Width & Height should always be uneven
    public int mapHeight;
    public int mapWidth;
    public GameObject[,] mapArray;

    private int currentQuadrant = 0;
    private int quadrantX = 0;
    private int quadrantY = 0;

    [SerializeField]
    private GameObject crate;

    [SerializeField]
    private int cratesPerQuadrant;


    void Start()
    {
        // Generate(); Wordt nu uitgevoerd vanuit de IngameMenu script
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void Generate()
    {
        //Fix map if given wrong number
        mapHeight = Mathf.Abs(mapHeight);
        mapWidth = Mathf.Abs(mapWidth);
        if (!IsOdd(mapHeight)) mapHeight++;
        if (!IsOdd(mapWidth)) mapWidth++;

        mapArray = new GameObject[mapWidth, mapHeight];

        //Set Camera size and location
        Vector3 center = new Vector3(mapWidth / 2, 0, mapHeight / 2);
        Camera.main.transform.position = new Vector3(center.x, 10, center.z);
        if (mapWidth > mapHeight * 1.8f)
        {
            Camera.main.orthographicSize = mapWidth / 3.7f;
        }
        else
        {
            Camera.main.orthographicSize = mapHeight / 2;
        }

        //Set floor
        floor = Instantiate(floorPrefab, center, Quaternion.identity) as GameObject;
        floor.name = "Floor";
        floor.transform.localScale = new Vector3(floor.transform.localScale.x * mapWidth, 1, floor.transform.localScale.z * mapHeight);

        //Start placing walls and blocks
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                //Walls for around map
                if ((x == 0 || x == mapWidth - 1) || (z == 0 || z == mapHeight - 1) || (x != 1 && x != mapWidth - 2 && z != 1 && z != mapHeight - 2 && !IsOdd(z) && !IsOdd(x)))
                {
                    PlaceWall(x, z);
                }

                /* Random crate spawning - NOT DONE
                else if (Random.Range(0,5) == 1)
                {
                    mapArray[i, j] = Instantiate(wall, new Vector3(i, 1, j), Quaternion.identity) as GameObject;
                }
                */
            }
        }

        SpawnCrates();
    }

    //Map is divided in 4 quadrants, for each quadrant cratesToSpawn is spawned.
    private void SpawnCrates()
    {
        while (currentQuadrant < 4)
        {
            int cratesToSpawn = cratesPerQuadrant;

            while (cratesToSpawn > 0)
            {
                for (int x = quadrantX; x < quadrantX + mapWidth / 2; x++)
                {
                    for (int y = quadrantY; y < quadrantY + mapHeight / 2; y++)
                    {
                        if (cratesToSpawn <= 0)
                            break;
                        if (Random.Range(0, 5) == 2 && GetTile(x, y) == null)
                        {
                            //Stupidly long if statement to prevent crates from spawning in the corner
                            if (!(x == 1 && y == 1) && !(x == 2 && y == 1) && !(x == 1 && y == 2) && !(x == mapWidth - 1 && y == 1) && !(x == mapWidth - 2 && y == 1) && !(x == mapWidth - 2 && y == 2) && !(x == 1 && y == mapHeight - 1) && !(x == 2 && y == mapHeight - 1) && !(x == 1 && y == mapHeight - 2) && !(x == mapWidth - 1 && y == mapHeight - 1) && !(x == mapWidth - 2 && y == mapHeight - 1) && !(x == mapWidth - 1 && y == mapHeight - 2))
                            {
                                PlaceCrate(x, y);
                                cratesToSpawn--;
                            }
                        }
                    }
                }
            }

            if (currentQuadrant == 0 || currentQuadrant == 2)
            {
                quadrantX += mapWidth / 2;
                Debug.Log(quadrantX);
            }
            if (currentQuadrant == 1)
            {
                quadrantX = 0;
                quadrantY += mapHeight / 2;
                Debug.Log(quadrantY);
            }

            currentQuadrant++;
        }

        /*for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                if (GetTile(x, z) == null)
                {
                    mapArray[x, z] = Instantiate(crate, new Vector3(x, 0.5f, z), Quaternion.identity) as GameObject;
                    mapArray[x, z].name = "Crate_" + x + "_" + z;
                }
            }
        }*/
    }

    void PlaceWall(int x, int y)
    {
        mapArray[x, y] = Instantiate(wall, new Vector3(x, 1, y), Quaternion.identity) as GameObject;
        mapArray[x, y].name = "Wall_" + x + "_" + y;
    }

    void PlaceCrate(int x, int y)
    {
        mapArray[x, y] = Instantiate(crate, new Vector3(x, 1, y), Quaternion.identity) as GameObject;
        mapArray[x, y].name = "Crate_" + x + "_" + y;
    }

    static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    public GameObject GetTile(int x, int z)
    {
        //X = now actually width & z = is now actually height
        if (mapArray[x, z] != null) return mapArray[x, z];
        else return null;
    }

    public Vector3[] GetPlayerSpawnPoints()
    {
        Vector3[] playerSpawnPoints = new Vector3[4];
        int y = 1;

        playerSpawnPoints[0] = new Vector3(1, y, 1);
        playerSpawnPoints[1] = new Vector3(mapWidth, y, 1);
        playerSpawnPoints[2] = new Vector3(1, y, mapHeight - 1);
        playerSpawnPoints[3] = new Vector3(mapWidth - 1, y, mapHeight - 1);

        return playerSpawnPoints;
    }
}
