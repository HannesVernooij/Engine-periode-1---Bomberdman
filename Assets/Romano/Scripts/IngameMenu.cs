using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IngameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private Slider lengthUI;
    [SerializeField]
    private Text lengthNumberUI;

    [SerializeField]
    private Slider widthUI;
    [SerializeField]
    private Text widthNumberUI;

    [SerializeField]
    private Slider playersUI;
    [SerializeField]
    private Text playersNumberUI;

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
        canvas.SetActive(false);

        GameObject.Find("MapCreator").GetComponent<MapGenerator>().mapHeight = (int)lengthUI.value;
        GameObject.Find("MapCreator").GetComponent<MapGenerator>().mapWidth = (int)widthUI.value;
        gameManager.PlayerAmount = (int)playersUI.value;

        GameObject.Find("MapCreator").GetComponent<MapGenerator>().Generate();
        gameManager.SpawnPlayers();
    }

    private void UI()
    {
        if (canvas.activeSelf)
        {
            lengthNumberUI.text = "" + (int)lengthUI.value;
            widthNumberUI.text = "" + (int)widthUI.value;
            playersNumberUI.text = "" + (int)playersUI.value;
        }
    }
}