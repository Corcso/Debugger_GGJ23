using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundDrawer : MonoBehaviour
{
    public GameObject[] tiles;
    public Vector2 boardSize;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= boardSize.x; i++) {
            for (int j = 0; j <= boardSize.y; j++) {
                int choice = Random.Range(0, tiles.Length);
                Instantiate(tiles[choice], new Vector3(i - (boardSize.x /2), j - (boardSize.y / 2), 1), Quaternion.Euler(0, 0, 0), this.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
