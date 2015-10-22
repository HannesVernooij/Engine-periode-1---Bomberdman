using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}