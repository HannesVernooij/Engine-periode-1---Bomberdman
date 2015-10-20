using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int speed = 10;
    [SerializeField]
    private Vector3 position;

    [SerializeField]
    private GameObject bombSpawnPosition;
    [SerializeField]
    private GameObject bomb;
    [SerializeField]
    private bool canDrop;
    private float dropTimer = 0.5f;

    private int bombDistance = 5;

    // Use this for initialization
    private void Start()
    {
        transform.position = new Vector3(1f, 0f, 1f);
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (vertical > 0 && transform.position == position)
        {
            position += Vector3.forward;
        }
        else if (vertical < 0 && transform.position == position)
        {
            position += Vector3.back;
        }

        if (horizontal < 0 && transform.position == position)
        {
            position += Vector3.left;
        }
        else if (horizontal > 0 && transform.position == position)
        {
            position += Vector3.right;
        }

        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
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

        if (Input.GetButtonDown("Jump") && canDrop)
        {
            GameObject GO = (GameObject)Instantiate(bomb, bombSpawnPosition.transform.position, Quaternion.identity);
            GO.GetComponent<Bomb>().CalculateObjectsAffected(GO.transform.position, bombDistance);

            canDrop = false;
            dropTimer = 0.5f;
        }
    }
}