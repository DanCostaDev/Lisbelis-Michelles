using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGeneration : MonoBehaviour
{
    //[SerializeField] private GameObject GrassTile;    
    [SerializeField] private Tile GrassTile;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private TilemapRenderer tileMapRenderer;
    [SerializeField] private SpawnEnemy spawnEnemy;
    [SerializeField] private int minWidth, width, height, minHeight, maxHeight, repeatNum;
    // Start is called before the first frame update
    private void Awake()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
        tileMap = GetComponentInChildren<Tilemap>();
        tileMapRenderer = GetComponentInChildren<TilemapRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generator()
    {
        int repeatValue = 0;
        for(int x = minWidth; x < width; x++)
        {
            if(repeatValue == 0)
            {
                height = Random.Range(minHeight, maxHeight);
                GeneratePlatform(x);
                repeatValue = repeatNum;
            }
            else
            {
                GeneratePlatform(x);
                repeatValue--;
            }

        }
    }

    public void Generator(int newMinWidth, int newWidth, int newMinHeight, int newMaxHeight, int newRepeatNum)
    {
        int repeatValue = 0;
        for (int x = newMinWidth; x < newWidth; x++)
        {
            if (repeatValue == 0)
            {
                height = Random.Range(newMinHeight, newMaxHeight);
                GeneratePlatform(x);
                repeatValue = Random.Range(newRepeatNum, newRepeatNum + 5);
            }
            else
            {
                GeneratePlatform(x);
                repeatValue--;
            }

        }
    }

    private void GeneratePlatform(int x)
    {
        SpawnObj(GrassTile, x, height);
    }

    //private void SpawnObj(GameObject obj, int width, int height)
    //{
    //    obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
    //    obj.transform.parent = this.transform;
    //}

    private void SpawnObj(TileBase obj, int width, int height)
    {
        Vector3Int pos = new Vector3Int(width, height, 0);
        tileMap.SetTile(pos, obj);
        if(Random.Range(1,20) == 1)
        {
            SetEnemy(pos);
        }
    }

    private void SetEnemy(Vector3Int pos)
    {
        Vector3Int multi = new Vector3Int(1, 5, 0);
        Vector3Int enemyPos = pos * multi;
        spawnEnemy.SetEnemy(enemyPos);
    }
}
