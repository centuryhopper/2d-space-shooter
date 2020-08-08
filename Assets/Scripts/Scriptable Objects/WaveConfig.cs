using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config", fileName = "Wave x")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numEnemies = 5;
    [SerializeField] float moveSpeed = 2f;


    public GameObject EnemyPrefab
    {
        get { return enemyPrefab; }
    }

    // all the wave patterns are stored in what this function returns
    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach (Transform pos in pathPrefab.transform)
        {
            wayPoints.Add(pos);
        }

        return wayPoints;
    }

    public float TimeBetweenSpawns
    {
        get { return timeBetweenSpawns; }
    }

    public float SpawnRandomFactor
    {
        get { return spawnRandomFactor; }
    }

    public int NumEnemies
    {
        get { return numEnemies; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
    }


}
