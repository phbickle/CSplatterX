using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyPool : MonoBehaviour 
{
    private List<GameObject> myEnemyList;
    private GameObject myEnemy;
    private IntegerVariable totalEnemiesCreated;
    private FloatVariable _spawnMaxTime;
    private float spawnTime;
	
    void Awake()
    {
        myEnemyList = new List<GameObject>();
        CreateEnemies();
    }
	
	// Update is called once per frame
	void Update () 
    {
        SpawnCounter();
	}

    void SpawnCounter()
    {
        spawnTime += Time.deltaTime;
        if(spawnTime >= _spawnMaxTime.value)
        {
            ActivateEnemies();
            spawnTime = 0.0f;
        }
        
    }

    private void CreateEnemies()
    {
        for(int i = 0; i < totalEnemiesCreated.value; ++i)
        {
            myEnemy = Instantiate(Resources.Load("PREFABS/TVHead")) as GameObject;
            myEnemyList.Add(myEnemy);
            myEnemyList[i].SetActive(false);
            myEnemy = Instantiate(Resources.Load("PREFABS/BrocoTree")) as GameObject;
            myEnemyList.Add(myEnemy);
            myEnemyList[i].SetActive(false);
        }
    }

    private void ActivateEnemies()
    {
        for(int i = 0; i < totalEnemiesCreated.value; ++i)
        {
            if(myEnemyList[i].activeSelf == false)
            {
                myEnemyList[i].SetActive(true);
                myEnemyList[i].GetComponent<EnemyMove>().SetPosition();
                myEnemyList[i].GetComponent<EnemyMove>().HEALTH = 2;
                return;
            }
        }
    }
}
