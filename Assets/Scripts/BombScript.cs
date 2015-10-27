using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour
{
    int[] PlayerBombAmount = new int[4] { 1, 1, 1, 1 };

    public void BombCheck(GameObject playerGameObject, int playerNumber)
    {
        if(PlayerBombAmount[playerNumber] > 0)
        {
            // Huseyins scriptje;
        }
    }
}
