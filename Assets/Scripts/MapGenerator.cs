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
    GameObject[,] mapArray;

    void Start()
    {
        // Generate(); Wordt nu uitgevoerd vanuit de IngameMenu script
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
        floor.transform.localScale = new Vector3(floor.transform.localScale.x * mapWidth, 1, floor.transform.localScale.z * mapHeight);

        //Start placing walls and blocks
        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                //Walls for around map
                if (x == 0 || x == mapWidth - 1)
                {
                    mapArray[x, z] = Instantiate(wall, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
                }

                else if (z == 0 || z == mapHeight - 1)
                {
                    mapArray[x, z] = Instantiate(wall, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
                }

                //Block placement
                else if (x != 1 && x != mapWidth - 2 && z != 1 && z != mapHeight - 2 && !IsOdd(z) && !IsOdd(x))
                {
                    mapArray[x, z] = Instantiate(wall, new Vector3(x, 1, z), Quaternion.identity) as GameObject;
                }

                /* Random crate spawning - NOT DONE
                else if (Random.Range(0,5) == 1)
                {
                    mapArray[i, j] = Instantiate(wall, new Vector3(i, 1, j), Quaternion.identity) as GameObject;
                }
                */
            }
        }
    }

    void PlaceWall(int x, int y)
    {
        mapArray[x, y] = Instantiate(wall, new Vector3(x, 1, y), Quaternion.identity) as GameObject;
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
}
