using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGeneration : MonoBehaviour
{
    //[SerializeField] private GameObject GrassTile;    
    [SerializeField] private Tile GrassTile;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private GameObject[] tileMaps;
    [SerializeField] private TilemapRenderer tileMapRenderer;
    [SerializeField] private SpawnEnemy spawnEnemy;
    [SerializeField] private int minWidth, width, height, minHeight, maxHeight, repeatNum;
    private GameObject[] tilemapList;
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

    //public void Generator()
    //{
    //    int repeatValue = 0;
    //    for (int x = minWidth; x < width; x++)
    //    {
    //        Debug.Log("x = " + x);
    //        if (repeatValue == 0)
    //        {
    //            height = Random.Range(minHeight, maxHeight);
    //            var ran = Random.Range(0, 20);
    //            if(ran == 1)
    //            {
    //                x += GeneratePlatform(x, true);
    //            }
    //            else
    //            {
    //                x += GeneratePlatform(x, false);
    //            }
    //            repeatValue = repeatNum;
    //        }
    //        else
    //        {
    //            x += GeneratePlatform(x, false);
    //            repeatValue--;
    //        }
    //    }
    //}

    public int GenerateMap(int minWidth, int maxWidth, int newMinHeight, int newMaxHeight, int newRepeatNum)
    {
        Debug.Log("minWidth= " + minWidth + " maxWidth= " + maxWidth + " TilemapSize= " + GetComponentInChildren<Tilemap>().size.x);
        int ranValue;
        ranValue = Random.Range(1, 20);
        if(ranValue <= 13)
        {
            Generator(minWidth, maxWidth, newMinHeight, newMaxHeight, newRepeatNum);
            return maxWidth;
        }
        else
        {
            return minWidth + GenerateTileMap(minWidth);
        }

    }

    private void Generator(int newMinWidth, int newWidth, int newMinHeight, int newMaxHeight, int newRepeatNum)
    {
        int repeatValue = 0;
        //newMinWidth = GetComponentInChildren<Tilemap>().size.x;
        for (int x = newMinWidth; x < newWidth; x++)
        {
            if (repeatValue == 0)
            {
                height = Random.Range(minHeight, maxHeight);
                GenerateTiles(x);
                repeatValue = Random.Range(repeatNum-3, repeatNum+3);
                SpawnEnemy(new Vector3Int(x, height, 0));
            }
            else
            {
                GenerateTiles(x);
                repeatValue--;
            }
            //Debug.Log("y= " + y + " x= " + x + " RepeatValue = " + repeatValue + " MaxWidth= " + newWidth + " NewMinWidth= " + newMinWidth + " TilemapSize= " + GetComponentInChildren<Tilemap>().size.x);
        }
    }

    private void GenerateTiles(int x)
    {
        SpawnObj(GrassTile, x, height);
    }

    private int GenerateTileMap(int x)
    {
        var tileMap = randomizerTilemap();
        Instantiate(tileMap, new Vector2(x, height), Quaternion.identity);
        var tilemapSize = tileMap.GetComponentInChildren<Tilemap>().size.x;
        Debug.Log("TILEMAP SIZE = " + tilemapSize + " GAME OBJECT POSITION: " + tileMap.transform.position + " X= " + x);
        return tilemapSize;
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
        //if(Random.Range(1,20) == 1)
        //{
        //    SetEnemy(pos);
        //}
    }

    //private void SetEnemy(Vector3Int pos)
    //{
    //    Vector3Int multi = new Vector3Int(1, 5, 0);
    //    Vector3Int enemyPos = pos * multi;
    //    //spawnEnemy.SetEnemy(enemyPos);
    //}

    private GameObject randomizerTilemap()
    {
        var num = Random.Range(0, tileMaps.Length);
        Debug.Log("TILEMAP==========" + tileMaps[num]);
        return tileMaps[num];
    }

    //private void GenerateTileMap()
    //{
    //    Vector3Int origin = tileMapWall.GetComponentInChildren<Tilemap>().origin;
    //    Vector3Int size = tileMapWall.GetComponentInChildren<Tilemap>().size;

    //}

    private void SpawnEnemy(Vector3Int pos)
    {
        var ran = Random.Range(1, 10);
        if(ran <= 3)
        {
            Vector3Int multi = new Vector3Int(1, 5, 0);
            Vector3Int enemyPos = pos * multi;
            spawnEnemy.SetEnemy(enemyPos);
        }

    }
}
