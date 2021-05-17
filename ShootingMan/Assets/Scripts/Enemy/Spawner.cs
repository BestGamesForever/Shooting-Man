using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Spawner : MonoBehaviour
{
    //Took the values from Spawner ScripablesObject Class.
    float remainigtimeToEnemySpawn = 0.6f;
    public GameObject SpawnPrefab;
    public List<GameObject> spawnObjectList;
    public SpawnManagerScriptableObject spawnManagerValues;
    int instanceNumber = 1;
    int SpawnIncreamentForspeedUp;
    public int TotalEnemy;

    void Start()
    {
        StartCoroutine(SpawnEnemiesInterval());
    }

    void SpawnEnemies()
    {
        int currentSpawnPointIndex = 0;
        for (int i = 0; i < spawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            GameObject currentEnemy = Instantiate(SpawnPrefab, spawnManagerValues.spawnPoints[currentSpawnPointIndex] + new Vector3(Random.Range(-4, 4), 0, Random.Range(2, 10)), Quaternion.Euler(0, 180, 0));
            currentEnemy.name = spawnManagerValues.prefabName + instanceNumber;

            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnManagerValues.spawnPoints.Length;
            instanceNumber++;
            spawnObjectList.Add(SpawnPrefab);
            for (int j = 0; j < spawnObjectList.Count; j++)
            {
                spawnObjectList[i].GetComponent<EnemyMovement>()._speed = (spawnManagerValues.Speed + (Random.Range(-2, 2))) + SpawnIncreamentForspeedUp * 3;
            }
        }
        TotalEnemy += spawnManagerValues.numberOfPrefabsToCreate;
        var UIupdater = GetComponent<UIManager>();
        UIupdater.UpdateEnemyCount();
       
       
    }
    IEnumerator SpawnEnemiesInterval()
    {
        float startTime = Time.time;
        while (Time.time - startTime <= remainigtimeToEnemySpawn)
        {
            SpawnEnemies();
            yield return new WaitForSeconds(2);
            startTime = 0;
            startTime = Time.time;
            SpawnIncreamentForspeedUp++;
            remainigtimeToEnemySpawn -= .03f;           
            yield return null;
            if (TotalEnemy >= spawnManagerValues.numberOfTotalPrefabs)
            {
                break;
            }

        }

    }
}