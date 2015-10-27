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

    [SerializeField]
    private GameObject[] players = new GameObject[4];
    [SerializeField]
    private Material[] materials = new Material[4];
    [SerializeField]
    private Vector3[] spawnPositions = new Vector3[4];

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void SpawnPlayers()
    {
        for (int i = 0; i < playerAmount; i++)
        {
            GameObject GO = (GameObject)Instantiate(players[i], spawnPositions[i], Quaternion.identity);
            GO.GetComponent<Renderer>().material = materials[i];
            GO.name = "Player " + (i + 1);
        }
    }
}