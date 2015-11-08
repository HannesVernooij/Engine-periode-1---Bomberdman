using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private int playerAmount;
    public int PlayerAmount
    {
        get
        {
            return playerAmount;
        }

        set
        {
            playerAmount = value;
        }
    }

    private GameObject[] currentPlayers = new GameObject[4];

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Material[] materials = new Material[4];
    private Vector3[] spawnPositions = new Vector3[4];

    private MapGenerator mapGenerator;

    // Use this for initialization
    private void Start()
    {
        mapGenerator = GameObject.Find("MapCreator").GetComponent<MapGenerator>();
    }

    // Update is called once per frame
    private void Update()
    {
        WhoIsTheWinner();
    }

    public void SpawnPlayers()
    {
        spawnPositions = mapGenerator.GetPlayerSpawnPoints();

        for (int i = 0; i < playerAmount; i++)
        {
            GameObject GO = (GameObject)Instantiate(player, spawnPositions[i], Quaternion.identity);
            GO.GetComponent<Renderer>().material = materials[i];
            GO.name = "Player " + (i + 1);

            currentPlayers[i] = GO;
        }
    }

    private void WhoIsTheWinner()
    {
        if (playerAmount == 1)
        {
            for (int i = 0; i < currentPlayers.Length; i++)
            {
                if (currentPlayers[i] != null)
                {
                    Debug.Log("Player " + (i + 1) + " wins");
                }
            }
        }
    }
}