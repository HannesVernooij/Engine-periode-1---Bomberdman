using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cratePowerups = new GameObject[2];

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void RandomPowerup()
    {
        int random = (int)Random.Range(0, 2);

        GameObject GO = (GameObject)Instantiate(cratePowerups[random], transform.position, Quaternion.identity);
    }
}