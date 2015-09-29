using UnityEngine;
using System.Collections;

public class BombExplosionCalculation : MonoBehaviour
{
    private MapGenerator _MapGenerator;
    private int[,] BombPosition;

    void Start()
    {
        _MapGenerator = GameObject.FindObjectOfType<MapGenerator>();
    }
    public void GetBombInformation(int x, int y)
    {
        BombPosition = new int[x, y];
    }

    
}
