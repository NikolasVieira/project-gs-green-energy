using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 10f;
    public int health = 100;
    public int reward = 50;
    public GameObject deathEffect;

    private Transform target;
    private int waypointIndex = 0;

    public void Start() {
        target = WaypointsManager.waypoints[0];
    }

    public void TakeDamage(int amout) {
        health -= amout;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die() {
        StatsManager.Money += reward;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
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
            EndPath();
            return;
        }
        waypointIndex++;
        target = WaypointsManager.waypoints[waypointIndex];
    }

    void EndPath() {
        StatsManager.Lives--;
        Destroy(gameObject);
    }
}