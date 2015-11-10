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
            GameObject player = collider.gameObject;
            PlayerController playerController = player.GetComponent<PlayerController>();

            if (playerController.Speed < playerController.GetSpeedLimit)
            {
                playerController.Speed += extraSpeed;
            }

            if (playerController.BombDistance < playerController.GetBombDistanceLimit)
            {
                playerController.BombDistance += extraBombDistance;
            }

            Destroy(gameObject);
        }
    }
}