using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMovementController : MonoBehaviour
{
    private EnemyController enemy;
    private Transform target;
    private int waypointIndex = 0;

    public void Start() {
        enemy = GetComponent<EnemyController>();
        target = WaypointsManager.waypoints[0];
    }

    public void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }

    public void GetNextWaypoint() {
        if (waypointIndex >= WaypointsManager.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = WaypointsManager.waypoints[waypointIndex];
    }

    void EndPath() {
        StatsManager.Lives--;
        WaveManager.EnemiesAlive--;
        Destroy(gameObject);
    }
}
