using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowSpawnerScript : MonoBehaviour
{
    public GameObject crow;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-10.6f, 10.6f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(crow, whereToSpawn, Quaternion.identity);
        }
    }
}
