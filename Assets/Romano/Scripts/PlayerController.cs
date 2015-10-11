using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int speed = 10;
    [SerializeField]
    private Vector3 position;

    // Use this for initialization
    private void Start()
    {
        transform.position = new Vector3(1f, 0f, 1f);
        position = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
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
}