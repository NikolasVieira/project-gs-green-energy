using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypointIndex = 0;

    public void Start() {
        target = WaypointsManager.waypoints[0];
    }

    public void Update() {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    public void GetNextWaypoint() {
        if (waypointIndex >= WaypointsManager.waypoints.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = WaypointsManager.waypoints[waypointIndex];
    }
}