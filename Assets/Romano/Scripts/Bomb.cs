using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    private float lifeTimer = 2f;

    private GameObject playerWhoDroppedMe;
    public GameObject PlayerWhoDroppedMe
    {
        get
        {
            return playerWhoDroppedMe;
        }

        set
        {
            playerWhoDroppedMe = value;
        }
    }

    private GameManager gameManager;

    // Use this for initialization
    private void Start()
    {
        gameManager = GameObject.Find("_Scripts").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        SnapToGrid();
        DestroyOverLifetime();
    }

    private void SnapToGrid()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), 0f, Mathf.RoundToInt(transform.position.z));
    }

    public void CalculateObjectsAffected(Vector3 position, int distance)
    {
        RaycastHit hitForward;
        RaycastHit hitBackward;
        RaycastHit hitLeft;
        RaycastHit hitRight;

        if (Physics.Raycast(position, transform.forward, out hitForward, distance))
        {
            if (hitForward.collider.gameObject.tag != "Wall")
            {
                if (hitForward.collider.gameObject.tag == "Player")
                {
                    gameManager.PlayerAmount -= 1;
                }

                Destroy(hitForward.collider.gameObject);
            }
        }

        if (Physics.Raycast(position, -transform.forward, out hitBackward, distance))
        {
            if (hitBackward.collider.gameObject.tag != "Wall")
            {
                if (hitBackward.collider.gameObject.tag == "Player")
                {
                    gameManager.PlayerAmount -= 1;
                }

                Destroy(hitBackward.collider.gameObject);
            }
        }

        if (Physics.Raycast(position, -transform.right, out hitLeft, distance))
        {
            if (hitLeft.collider.gameObject.tag != "Wall")
            {
                if (hitLeft.collider.gameObject.tag == "Player")
                {
                    gameManager.PlayerAmount -= 1;
                }

                Destroy(hitLeft.collider.gameObject);
            }
        }

        if (Physics.Raycast(position, transform.right, out hitRight, distance))
        {
            if (hitRight.collider.gameObject.tag != "Wall")
            {
                if (hitRight.collider.gameObject.tag == "Player")
                {
                    gameManager.PlayerAmount -= 1;
                }

                Destroy(hitRight.collider.gameObject);
            }
        }
    }

    private void DestroyOverLifetime()
    {
        if (lifeTimer > 0)
        {
            lifeTimer -= Time.deltaTime;
        }

        if (lifeTimer <= 0)
        {
            CalculateObjectsAffected(transform.position, playerWhoDroppedMe.GetComponent<PlayerController>().BombDistance);
            Destroy(gameObject);
        }
    }
}