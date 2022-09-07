using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGeneration : MonoBehaviour
{
    //[SerializeField] private GameObject GrassTile;    
    [SerializeField] private Tile GrassTile;
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private GameObject tileMapWall;
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

    public void Generator(int newMinWidth, int newWidth, int newMinHeight, int newMaxHeight, int newRepeatNum)
    {
        int repeatValue = 0;
        int y;
        newMinWidth = GetComponentInChildren<Tilemap>().size.x;
        for (int x = newMinWidth; x < newWidth; x++)
        {
            if (repeatValue == 0)
            {
                height = Random.Range(minHeight, maxHeight);
                var ran = Random.Range(0, 20);
                if (ran == 1)
                {
                    y = GeneratePlatform(x, true) -1;
                    x += y;
                    newMinWidth += y;
                    newWidth += y;
                    //Debug.Log("REPEAT VALUE NA PAREDE= " + repeatValue);
                }
                else
                {
                    GeneratePlatform(x, false);
                }
                repeatValue = Random.Range(repeatNum-3, repeatNum+3);
            }
            else
            {
                GeneratePlatform(x, false);
                repeatValue--;
            }
            //Debug.Log("x= " + x + " RepeatValue = " + repeatValue + " MaxWidth= " + newWidth + " NewMinWidth= " + newMinWidth + " TilemapSize= " + GetComponentInChildren<Tilemap>().size.x);
        }
    }

    private int GeneratePlatform(int x, bool isTilemap)
    {
        if (isTilemap)
        {
            //var tile = randomizerTilemap();
            Instantiate(tileMapWall, new Vector2(x+4, height), Quaternion.identity);
            minWidth = tileMapWall.GetComponentInChildren<Tilemap>().size.x - 4;
            //Debug.Log("FEZ PAREDE==========================");
            return minWidth;
        }
        else
        {
            SpawnObj(GrassTile, x, height);
            return 0;
        }

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

    private void SetEnemy(Vector3Int pos)
    {
        Vector3Int multi = new Vector3Int(1, 5, 0);
        Vector3Int enemyPos = pos * multi;
        //spawnEnemy.SetEnemy(enemyPos);
    }

    private GameObject randomizerTilemap()
    {
        tilemapList[0] = tileMapWall;
        var num = Random.Range(0, tilemapList.Length - 1);
        return tilemapList[num];
    }

    private void GenerateTileMap()
    {
        Vector3Int origin = tileMapWall.GetComponentInChildren<Tilemap>().origin;
        Vector3Int size = tileMapWall.GetComponentInChildren<Tilemap>().size;

    }
}
