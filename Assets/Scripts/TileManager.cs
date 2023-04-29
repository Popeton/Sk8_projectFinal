using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
     [SerializeField] GameObject[] tilesPrefabs; //modulos de calles
    [SerializeField] Transform playerPos;
     int tilesAmn= 5; //numero de tiles que sale por ciclo 
    float tileLenght = 30f;
    float spawnZ = 0;
    
   
    
    List<GameObject> activeTiles = new List<GameObject>();
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.z - 50> spawnZ - (tileLenght * tilesAmn)) 
        {

            SpawnTile(Random.Range(0,tilesPrefabs.Length));
            //DeleteTile();
        }
    }
   public  void SpawnTile(int tileIndex) //metodo
   {
        spawnZ += tileLenght;
        GameObject go = Instantiate(tilesPrefabs[tileIndex], transform.forward * spawnZ, transform.rotation);
        
        activeTiles.Add(go);       
   }
    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
  
    
}
