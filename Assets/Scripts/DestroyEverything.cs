using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyEverything : MonoBehaviour
{
    Tilemap tilemap;
    
    [SerializeField] private PlayerDeath playerDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        tilemap = collision.gameObject.GetComponent<Tilemap>();
    //        ContactPoint2D[] contacts;
    //        Vector3 hitPosition = Vector3.zero;
    //        contacts = collision.contacts;
    //        foreach (ContactPoint2D hit in contacts)
    //        {
    //            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
    //            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
    //            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
    //        }
    //    }
    //}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
          playerDeath.DeadPlayer();   
        } else {
            if (collision.gameObject.tag == "Ground")
            {
                tilemap = collision.gameObject.GetComponent<Tilemap>();
                ContactPoint2D[] contacts;
                Vector3 hitPosition = Vector3.zero;
                contacts = collision.contacts;
                foreach (ContactPoint2D hit in contacts)
                {
                    hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                    hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                    tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);
                }
            }
            else
            {
                Destroy(collision.gameObject);
            }
        } 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
