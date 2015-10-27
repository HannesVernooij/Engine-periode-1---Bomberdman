using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    GameObject[] _players;
    private void FixedUpdate()
    {
        if (_players != null)
        {
            for (int i = 0; i < _players.Length; i++)
            {
                gameObject.transform.position = new Vector3(Input.GetAxis("Horizontal_" + i), gameObject.transform.position.y, Input.GetAxis("Vertical_" + i));
            }
        }
    }

    public void SetPlayers(GameObject[] players)
    {
        _players = players;
    }
}