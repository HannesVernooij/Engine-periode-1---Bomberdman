using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    private float lifeTimer = 2f;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void CalculateObjectsAffected(Vector3 position, int distance)
    {
        RaycastHit hitForward;
        RaycastHit hitBackward;
        RaycastHit hitLeft;
        RaycastHit hitRight;

        if (Physics.Raycast(position, transform.forward, out hitForward, distance))
        {
            if (hitForward.collider.gameObject.name != "Wall(Clone)")
            {
                Destroy(hitForward.collider.gameObject);
            }
        }

        if (Physics.Raycast(position, -transform.forward, out hitBackward, distance))
        {
            if (hitBackward.collider.gameObject.name != "Wall(Clone)")
            {
                Destroy(hitBackward.collider.gameObject);
            }
        }

        if (Physics.Raycast(position, -transform.right, out hitLeft, distance))
        {
            if (hitLeft.collider.gameObject.name != "Wall(Clone)")
            {
                Destroy(hitLeft.collider.gameObject);
            }
        }

        if (Physics.Raycast(position, transform.right, out hitRight, distance))
        {
            if (hitRight.collider.gameObject.name != "Wall(Clone)")
            {
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
            Destroy(gameObject);
        }
    }
}