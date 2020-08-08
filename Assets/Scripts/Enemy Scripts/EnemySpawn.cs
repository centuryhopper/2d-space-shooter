using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<WaveConfig> waveConfigs;

    //int startingWave = 0;

    [SerializeField] bool loopWaves = false;

    // Cannot run game if start is of type void when looping a coroutine
    IEnumerator Start()
    {
        //WaveConfig curWave = waveConfigs[startingWave];
        //StartCoroutine(SpawnAllEnemies(curWave));
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (loopWaves);
    }

    IEnumerator SpawnAllEnemies(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.NumEnemies; ++i)
        {
            var newEnemy = Instantiate(waveConfig.EnemyPrefab,
            waveConfig.GetWayPoints()[0].position,
            Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }

    IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig waveConfig in waveConfigs)
        {
            yield return StartCoroutine(SpawnAllEnemies(waveConfig));
        }
    }
}
