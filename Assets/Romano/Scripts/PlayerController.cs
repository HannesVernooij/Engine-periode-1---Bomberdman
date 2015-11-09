using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int playerID;

    [SerializeField]
    private Vector3 position;

    [SerializeField]
    private GameObject bombSpawnPosition;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private bool canDrop;
    private float dropTimer = 0.5f;

    private float moveX = 0f;
    private float moveZ = 0f;

    private int speed = 15;
    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    private int bombDistance = 5;
    public int BombDistance
    {
        get
        {
            return bombDistance;
        }

        set
        {
            bombDistance = value;
        }
    }

    // Use this for initialization
    private void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Drop();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Crate")
        {
            collider.gameObject.GetComponent<Crate>().RandomPowerup();
            Destroy(collider.gameObject);
        }
    }

    private void Movement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

	if (Mathf.Abs(moveX) > Mathf.Abs(moveZ))
	{
		moveZ = 0;
	}
	else
	{
		moveX = 0;
	}

        GetComponent<Rigidbody>().velocity = new Vector3(moveX * speed, GetComponent<Rigidbody>().velocity.y, moveZ * speed);
    }

    private void Drop()
    {
        if (dropTimer > 0)
        {
            dropTimer -= Time.deltaTime;
        }

        if (dropTimer <= 0)
        {
            canDrop = true;
        }

        if (Input.GetButtonDown("Drop") && canDrop)
        {
            GameObject GO = (GameObject)Instantiate(bomb, bombSpawnPosition.transform.position, Quaternion.identity);
            GO.GetComponent<Bomb>().PlayerWhoDroppedMe = gameObject;

            canDrop = false;
            dropTimer = 0.5f;
        }
    }
}