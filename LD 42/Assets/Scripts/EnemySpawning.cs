using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    
    //Spawn rate throughout wave
    public float WaveSpawnRate;

    public GameObject[] Houses;
    public GameObject[] PlacesToSpawn;
    public Enemy enemy;

    void Start () {
        
        StartCoroutine(Spawning());
	}
	
	void Update () {
		
	}

    IEnumerator Spawning()
    {
        
        //creates an infinite loop
        Start:
        yield return new WaitForSeconds(WaveSpawnRate);
        Instantiate(enemy, PlacesToSpawn[Random.Range(1, PlacesToSpawn.Length)].transform.position, Quaternion.identity);

        if (WaveSpawnRate > .1f)
        {
            WaveSpawnRate -= .1f;
        }
        goto Start;
    }
}
