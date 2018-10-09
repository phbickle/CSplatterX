using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyPool : MonoBehaviour 
{
    [SerializeField] private List<GameObject> _myEnemyList;
    [SerializeField] private List<Transform> _enemySpawnPoints;
    [SerializeField] private IntegerVariable _enemiesSpawnedCap;
    [SerializeField] private IntegerVariable _enemyCounter;
    [SerializeField] private FloatVariable _spawnRate;
    private Transform _myTransform;
    private float _spawnTime;
    private float _canSpawn;
    private int _arraySize;
    private bool _shouldSpawn;
	
    void Awake()
    {
        _enemyCounter.value = 0;
        _arraySize = _myEnemyList.Count;
        _canSpawn = 0;
        _shouldSpawn = false;
        for(int i = 0; i < _arraySize; i++)
        {
            _myEnemyList[i] = Instantiate(_myEnemyList[i], transform.position, Quaternion.identity) as GameObject;
            _myEnemyList[i].transform.position = _enemySpawnPoints[i].transform.position;
            _myEnemyList[i].SetActive(false);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        SpawnCounter();
    }

    void SpawnCounter()
    {
        _spawnTime = Time.time;
        if ((_spawnTime > _canSpawn))
        {
            ActivateEnemies();
            _canSpawn = _spawnTime + _spawnRate.value;
        }
        
    }

    private void ActivateEnemies()
    {
        for(int i = 0; i < _myEnemyList.Count; ++i)
        {
            if (_enemyCounter.value < _enemiesSpawnedCap.value)
            {
                _shouldSpawn = true;
            }
            else
            {
                _shouldSpawn = false;
            }

            if (_myEnemyList[i].activeSelf == false && _shouldSpawn)
            {
                _myEnemyList[i].transform.position = _enemySpawnPoints[i].transform.position;
                _myEnemyList[i].SetActive(true);
                _enemyCounter.value++;
                return;
            }
        }
    }
}
