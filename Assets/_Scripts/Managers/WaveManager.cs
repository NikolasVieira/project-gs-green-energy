using UnityEngine;
using System.Collections;
using TMPro;
using System.Linq;
public class WaveManager : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 3f;
    public TextMeshProUGUI waveCountdownText;
    private int waveIndex = 0;

    public void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = (waveIndex+1).ToString()+"/"+waves.Count().ToString();
    }

    IEnumerator SpawnWave() 
    {
        StatsManager.Waves++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy) 
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
