using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;

    List<Transform> wayPoints;

    int wayPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
    }


    // Update is called once per frame
    void Update()
    {
        if (wayPointIndex >= wayPoints.Count)
        {
            Destroy(gameObject);
            return;
        }

        //Debug.Log("num waypoints: " + wayPoints.Count);
        //Debug.Log("way point pos: " + wayPointIndex);

        // find target position and move towards it
        Vector2 targetPos = wayPoints[wayPointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position,
            targetPos,
            waveConfig.MoveSpeed * Time.deltaTime);

        // go to a new target position when we reach the current target position
        if ((Vector2)transform.position == targetPos)
        {
            ++wayPointIndex;
        }
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
}
