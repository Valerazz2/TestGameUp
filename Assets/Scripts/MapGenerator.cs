using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> FlorTiles = new List<GameObject>();
    private int mapWeight = 50, mapHeight = 60;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < mapWeight; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                var Tile = Instantiate(FlorTiles[Random.Range(0, FlorTiles.Count)]);
                Tile.transform.position = new Vector3(x, y, 0);
                Tile.transform.localScale = new Vector3(6.25f,6.25f,1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
