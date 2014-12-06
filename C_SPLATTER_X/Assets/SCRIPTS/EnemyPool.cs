using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyPool : MonoBehaviour 
{
    private List<GameObject> myEnemyList;
    private GameObject myEnemy;
    private int totalEnemiesCreated;
	
    void Awake()
    {
        totalEnemiesCreated = 5;
        myEnemyList = new List<GameObject>();
        CreateEnemies();
    }
	
	// Update is called once per frame
	void Update () 
    {
        ActivateEnemies();
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
                return;
            }
        }
    }
}
