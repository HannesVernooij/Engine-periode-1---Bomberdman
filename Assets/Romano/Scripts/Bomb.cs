using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    private float lifeTimer = 0.2f;

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

    public void CalculateObjectsAffected(Vector3 position, int distance, GameObject playerWhoDroppedMe)
    {
        RaycastHit hitForward;
        RaycastHit hitBackward;
        RaycastHit hitLeft;
        RaycastHit hitRight;

        if (Physics.Raycast(position, transform.forward, out hitForward, distance))
        {
            GameObject GO = hitForward.collider.gameObject;

            if (GO.tag != "Wall")
            {
                if (GO.tag == "Player")
                {
                    GO.GetComponent<PlayerController>().Health -= 1;
                }

                if (GO.tag == "Crate")
                {
                    GO.GetComponent<Crate>().RandomPowerup();
                    Destroy(GO);
                }
            }
        }

        if (Physics.Raycast(position, -transform.forward, out hitBackward, distance))
        {
            if (hitBackward.collider.gameObject.tag != "Wall" && hitBackward.collider.gameObject != playerWhoDroppedMe)
            {
                GameObject GO = hitBackward.collider.gameObject;

                if (GO.tag == "Player")
                {
                    GO.GetComponent<PlayerController>().Health -= 1;
                }

                if (GO.tag == "Crate")
                {
                    GO.GetComponent<Crate>().RandomPowerup();
                    Destroy(GO);
                }
            }
        }

        if (Physics.Raycast(position, -transform.right, out hitLeft, distance))
        {
            GameObject GO = hitLeft.collider.gameObject;

            if (GO.tag != "Wall")
            {
                if (GO.tag == "Player")
                {
                    GO.GetComponent<PlayerController>().Health -= 1;
                }

                if (GO.tag == "Crate")
                {
                    GO.GetComponent<Crate>().RandomPowerup();
                    Destroy(GO);
                }
            }
        }

        if (Physics.Raycast(position, transform.right, out hitRight, distance))
        {
            GameObject GO = hitRight.collider.gameObject;

            if (GO.tag != "Wall")
            {
                if (GO.tag == "Player")
                {
                    GO.GetComponent<PlayerController>().Health -= 1;
                }

                if (GO.tag == "Crate")
                {
                    GO.GetComponent<Crate>().RandomPowerup();
                    Destroy(GO);
                }
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
            Destroy(gameObject);
        }
    }
}