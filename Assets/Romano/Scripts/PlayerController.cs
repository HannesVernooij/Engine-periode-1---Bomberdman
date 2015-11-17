using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int playerID;
    public int PlayerID
    {
        get
        {
            return playerID;
        }

        set
        {
            playerID = value;
        }
    }

    [SerializeField]
    private Vector3 position;

    [SerializeField]
    private GameObject bombSpawnPosition;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private bool canDrop;
    private float dropTimer = 0.5f;

    private int health = 1;
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    private int speed = 200;
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

    private int speedLimit = 250;
    public int GetSpeedLimit
    {
        get
        {
            return speedLimit;
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

    private int bombDistanceLimit = 10;
    public int GetBombDistanceLimit
    {
        get
        {
            return bombDistance;
        }
    }

    private GameManager gameManager;

    // Use this for initialization
    private void Start()
    {
        position = transform.position;

        gameManager = GameObject.Find("_Scripts").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        Drop();
        Die();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    
    private void Movement()
    {
        float horizontal = Input.GetAxis("Player " + playerID + " Horizontal");
        float vertical = Input.GetAxis("Player " + playerID + " Vertical");

        if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
        {
            vertical = 0;
        }
        else if (Mathf.Abs(vertical) > Mathf.Abs(horizontal))
        {
            horizontal = 0;
        }

        GetComponent<Rigidbody>().velocity = new Vector3(horizontal * speed * Time.deltaTime, 1f, vertical * speed * Time.deltaTime);
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

        if (Input.GetButtonDown("Player " + playerID + " Fire") && canDrop)
        {
            GameObject GO = (GameObject)Instantiate(bomb, bombSpawnPosition.transform.position, Quaternion.identity);
            GO.GetComponent<Bomb>().CalculateObjectsAffected(transform.position, bombDistance, gameObject);

            canDrop = false;
            dropTimer = 0.5f;
        }
    }

    private void Die()
    {
        if (health <= 0)
        {
            gameManager.PlayerAmount -= 1;
            Destroy(gameObject);
        }
    }
}