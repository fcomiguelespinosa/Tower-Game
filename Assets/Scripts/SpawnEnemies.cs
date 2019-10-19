using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
	public GameObject Enemy;
	private float timerSpawn;
	private float waitforEnemy; 	
	
    // Start is called before the first frame update
    void Start()
    {
    	timerSpawn = 0;
    	waitforEnemy = 1;
    }

    // Update is called once per frame
    void Update()
    {
    	timerSpawn += Time.deltaTime;
    	
    	if(timerSpawn >= waitforEnemy ){
    		timerSpawn = 0;
    		
	        Instantiate (Enemy, new Vector3(Random.Range(-10.0f, 10.0f), 0, Random.Range(-10.0f, 10.0f)), Quaternion.identity);	
    	}  	
    }
}
