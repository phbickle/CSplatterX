using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyPool : MonoBehaviour 
{
    private List<GameObject> myEnemyList;
    private GameObject myEnemy;
    private int totalEnemiesCreated;
    private float spawnTime;
	
    void Awake()
    {
        spawnTime = 0.0f;
        totalEnemiesCreated = 4;
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
        if(spawnTime >= 2.0f)
        {
            ActivateEnemies();
            spawnTime = 0.0f;
        }
        
    }

    private void CreateEnemies()
    {
        for(int i = 0; i < totalEnemiesCreated; ++i)
        {
            myEnemy = Instantiate(Resources.Load("PREFABS/PlaceHolderEnemy")) as GameObject;
            myEnemyList.Add(myEnemy);
            myEnemyList[i].SetActive(false);
        }
    }

    private void ActivateEnemies()
    {
        for(int i = 0; i < totalEnemiesCreated; ++i)
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
