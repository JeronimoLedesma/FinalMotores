using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float minX;
    public float maxX;
    public float minXBarrera;
    public float maxXBarrera;
    public float minZ;
    public float maxZ;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnEnemy()
    {
        while (Score.wave <= 2)
        {
            Vector3 spawn = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
            Instantiate(enemy, spawn, transform.rotation);
            yield return new WaitForSeconds(time);
        }
        while (Score.wave > 2)
        {
            Vector3 spawn = new Vector3(Random.Range(minXBarrera, maxXBarrera), transform.position.y, Random.Range(minZ, maxZ));
            Instantiate(enemy, spawn, transform.rotation);
            yield return new WaitForSeconds(time);
        }
    }
}
