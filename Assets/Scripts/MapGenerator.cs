using UnityEngine;
using System.Collections;

public class MapGenerator : MonoBehaviour
{
    public GameObject wall;
    public GameObject floorPrefab;
    GameObject floor;
    //Width & Height should always be uneven
    public int mapWidth;
    public int mapHeight;
    GameObject[,] mapArray;

    //Z = Width X = Height because fuck logic

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        mapWidth = Mathf.Abs(mapWidth);
        mapHeight = Mathf.Abs(mapHeight);

        mapArray = new GameObject[mapHeight, mapWidth];

        floor = Instantiate(floorPrefab, new Vector3(mapHeight / 2, 0, mapWidth / 2), Quaternion.identity) as GameObject;
        floor.transform.localScale = new Vector3(floor.transform.localScale.x * mapHeight, 1, floor.transform.localScale.z * mapWidth);

        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                //Walls for around map
                if (i == 0 || i == mapHeight-1)
                {
                    mapArray[i,j] = Instantiate(wall, new Vector3(i, 1, j),Quaternion.identity) as GameObject;
                }

                else if(j == 0 || j == mapWidth-1)
                {
                    mapArray[i, j] = Instantiate(wall, new Vector3(i, 1, j), Quaternion.identity) as GameObject;
                }

                //Block placement
                else if(i != 1 && i != mapHeight-2 && j != 1 && j != mapWidth-2 && !IsOdd(j) && !IsOdd(i))
                {
                    mapArray[i, j] = Instantiate(wall, new Vector3(i, 1, j), Quaternion.identity) as GameObject;
                }
            }
        }
    }

    static bool IsOdd(int value)
    {
        return value % 2 != 0;
    }

    public bool GetTile(int y, int x)
    {
        if (mapArray[y,x] == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
