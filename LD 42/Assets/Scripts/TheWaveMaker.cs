using System.Collections;
using UnityEngine;

public class TheWaveMaker : MonoBehaviour
{

    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int EnemyCount;
        public float rate;
    }

    public Wave[] waves;
    public int nextWave = 0;

    public Transform[] SpawnPoints;

    public float TimeBetween = 5f;
    public float WaveCountDown = 0f;

    private float searchCountDown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        WaveCountDown = TimeBetween;
    }


    void Update()
    {
        print(state);
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                //Where to add point or spawn a new wave ect.
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (WaveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            WaveCountDown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        WaveCountDown = TimeBetween;
        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETE");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;


        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("EnemyHit").Length == 1)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.EnemyCount; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1 / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);

        Transform _sp = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }
}
