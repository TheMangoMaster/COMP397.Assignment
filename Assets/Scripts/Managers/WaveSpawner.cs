using System.Xml.Serialization;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;
    public TextMeshProUGUI waveIndexText;

    private int waveIndex = 0;
    void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; //reduces countdown by 1 every second
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //waveCountdownText.text = "More bugs coming in:  " + Mathf.Round(countdown).ToString(); //sends countdown without decimals to the text object
        waveCountdownText.text = "BUGS INCOMING!!  " + string.Format("{0:00.00}", countdown); //sends countdown without decimals to the text object
        waveIndexText.text = "Wave:  " + waveIndex.ToString();                                                                               
    }

    IEnumerator SpawnWave()
    {
        waveIndex++; //adds an enemy each wave

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //spawns an enemy WITHIN the wave every .5s
        }        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
