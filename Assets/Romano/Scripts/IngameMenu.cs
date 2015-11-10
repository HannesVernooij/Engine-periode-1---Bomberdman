using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IngameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasIngame;

    [SerializeField]
    private Slider lengthUI;
    [SerializeField]
    private Text lengthNumberUI;

    [SerializeField]
    private Slider widthUI;
    [SerializeField]
    private Text widthNumberUI;

    [SerializeField]
    private Slider cratesUI;
    [SerializeField]
    private Text cratesNumberUI;

    [SerializeField]
    private Slider playersUI;
    [SerializeField]
    private Text playersNumberUI;

    [SerializeField]
    private GameObject canvasEndgame;

    private GameManager gameManager;

    // Use this for initialization
    private void Start()
    {
        gameManager = GameObject.Find("_Scripts").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        UI();
    }

    public void Create()
    {
        canvasIngame.SetActive(false);

        GameObject.Find("MapCreator").GetComponent<MapGenerator>().mapHeight = (int)lengthUI.value;
        GameObject.Find("MapCreator").GetComponent<MapGenerator>().mapWidth = (int)widthUI.value;
        GameObject.Find("MapCreator").GetComponent<MapGenerator>().CratesPerQuadrant = (int)cratesUI.value;
        gameManager.PlayerAmount = (int)playersUI.value;

        GameObject.Find("MapCreator").GetComponent<MapGenerator>().Generate();
        gameManager.SpawnPlayers();
    }

    private void UI()
    {
        if (canvasIngame.activeSelf)
        {
            lengthNumberUI.text = "" + (int)lengthUI.value;
            widthNumberUI.text = "" + (int)widthUI.value;
            cratesNumberUI.text = "" + (int)cratesUI.value;
            playersNumberUI.text = "" + (int)playersUI.value;
        }

        if (gameManager.PlayerAmount == 1)
        {
            if (!canvasEndgame.activeSelf)
            {
                canvasEndgame.SetActive(true);
            }
        }
    }
}