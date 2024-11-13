using UnityEngine;
using System.Collections;
using TMPro;
public class WaveManager : MonoBehaviour
{
    public Transform pfEnemy;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 3f;
    public TextMeshProUGUI WaveCountdownText;
    private int waveIndex = 0;


    public void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        WaveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave() {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void SpawnEnemy() {
        Instantiate(pfEnemy, spawnPoint.position, spawnPoint.rotation);
    }
}
