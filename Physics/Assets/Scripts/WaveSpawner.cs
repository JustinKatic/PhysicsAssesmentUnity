/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: spawns enemies until all enemies in wave are spawned. wave last till all enemy count is 0 and then next 
 *wave will begin spawning repeating till no waves are left triggering the allWavesCompleted event.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;


public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string m_name;
        public Transform[] m_enemy;
        public float m_rate;
    }

    [SerializeField] IntVariable m_nextWaveNum;

    [Header("WAVE DETAILS")]
    [SerializeField] Wave[] m_waves;
    private int m_currentEnemy = 0;
    private float m_searchCountdown = 1f;

    [SerializeField] float m_timeBetweenWaves = 5f;
    private float m_waveCountdown;

    [SerializeField] FloatVariable m_numberOfActiveEnemies;

    [Header("EVENTS")]
    [SerializeField] GameEvent m_waveCompletedEvent;
    [SerializeField] GameEvent m_allWavesCompleted;


    [Header("UI TEXT")]
    [SerializeField] TextMeshProUGUI m_waveCounterTxt;
    [SerializeField] TextMeshProUGUI m_currentWaveTxt;






    public SpawnState State { get; private set; } = SpawnState.COUNTING;

    void Start()
    {
        m_currentWaveTxt.text = m_waves[m_nextWaveNum.RuntimeValue].m_name;
        m_waveCountdown = m_timeBetweenWaves;
    }

    void Update()
    {
        if (State == SpawnState.WAITING)
        {
            if (StartNextWave())
            {
                m_currentEnemy = 0;
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (m_waveCountdown <= 0)
        {
            if (State != SpawnState.SPAWNING)
            {
                m_waveCounterTxt.text = string.Empty;
                StartCoroutine(SpawnWave(m_waves[m_nextWaveNum.RuntimeValue]));
            }
        }

        else
        {
            m_waveCountdown -= Time.deltaTime;
            m_waveCounterTxt.text = Mathf.Round(m_waveCountdown).ToString();
        }
    }


    void WaveCompleted()
    {
        State = SpawnState.COUNTING;
        m_waveCountdown = m_timeBetweenWaves;


        if (m_nextWaveNum.RuntimeValue + 1 == m_waves.Length)
        {
            m_allWavesCompleted.Raise();
        }
        else
        {
            m_nextWaveNum.RuntimeValue++;
            m_currentWaveTxt.text = m_waves[m_nextWaveNum.RuntimeValue].m_name;
            m_waveCompletedEvent.Raise();
        }
    }

    bool StartNextWave()
    {
        m_searchCountdown -= Time.deltaTime;
        if (m_searchCountdown <= 0f)
        {
            m_searchCountdown = 1f;

            if (m_numberOfActiveEnemies.RuntimeValue <= 0)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        State = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.m_enemy.Length; i++)
        {
            SpawnEnemy(_wave.m_enemy[i]);
            yield return new WaitForSeconds(_wave.m_rate);
        }

        State = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform a_enemy)
    {
        GameObject[] spawnPoints;
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        int randSpawnPoint = Random.Range(0, spawnPoints.Length - 1);
        Transform _sp = spawnPoints[randSpawnPoint].transform;

        Instantiate(a_enemy, _sp.transform.position, _sp.transform.rotation);
        m_numberOfActiveEnemies.RuntimeValue += 1;

        m_currentEnemy++;
        if (m_currentEnemy >= spawnPoints.Length)
            m_currentEnemy = 0;
    }


}
