using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private int extraSpeed;
    [SerializeField]
    private int extraBombDistance;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerController>().Speed += extraSpeed;
            collider.gameObject.GetComponent<PlayerController>().BombDistance += extraBombDistance;

            Destroy(gameObject);
        }
    }
}