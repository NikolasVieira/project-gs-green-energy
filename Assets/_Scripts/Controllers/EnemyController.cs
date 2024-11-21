using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    public int health = 100;
    public int reward = 50;
    public GameObject deathEffect;

    void Start() {
        speed = startSpeed;
    }

    public void TakeDamage(int amout) {
        health -= amout;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float percentage) {
        speed = startSpeed * (1f - percentage);
    }

    void Die() {
        StatsManager.Money += reward;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveManager.EnemiesAlive--;
        Destroy(gameObject);
    }
}