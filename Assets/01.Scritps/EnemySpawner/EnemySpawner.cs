using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using ProjectT.Manager;

public class EnemySpawner : MonoBehaviour
{
    public GameObject mrDirtyPrefab;
    public GameObject speedyMrDirtPrefab;
    public GameObject heavyMrDirtPrefab;
    public GameObject tornadoBossPrefab;
    public Transform spawnPos;
    public Transform bossSpawnPos;

    public Image bossBanner;
    public List<GameObject> warningObject;

    public DOTweenAnimation warningFadeAnimation;

    private bool firstSpawn = false;
    private bool secondSpawn = false;
    private bool thirdSpawn = false;
    private bool fourthSpawn = false;

    private bool firstBossSpawn = false;
    private bool secondBossSpawn = false;
    private bool thirdBossSpawn = false;
    private bool fourthBossSpawn = false;

    public bool bossSpawned = false;

    private float timer = 0;

    private ISpawnerState currentSpawnState;

    private void Start()
    {
        ChangeSpawnState(new NormalState());
    }

    private void Update()
    {
        if (!bossSpawned)
        {
            if (GameManager.instance.score >= 0 && GameManager.instance.score < 100 && !firstSpawn)
            {
                ChangeSpawnState(new NormalState());
                firstSpawn = true;
            }
            else if (GameManager.instance.score >= 100 && GameManager.instance.score < 500 && !secondSpawn)
            {
                ChangeSpawnState(new NormalState());
                secondSpawn = true;
            }
            else if (GameManager.instance.score >= 500 && GameManager.instance.score < 2000 && !thirdSpawn)
            {
                ChangeSpawnState(new NormalState());
                thirdSpawn = true;
            }
            else if (GameManager.instance.score >= 2000 && !fourthSpawn)
            {
                ChangeSpawnState(new NormalState());
                fourthSpawn = true;
            }
        }

        if (GameManager.instance.score >= 1000 && !firstBossSpawn)
        {
            ChangeSpawnState(new BossState());
            firstBossSpawn = true;
        }
        else if (GameManager.instance.score >= 2000 && !secondBossSpawn)
        {
            ChangeSpawnState(new BossState());
            secondBossSpawn = true;
        }
        else if (GameManager.instance.score >= 3000 && !thirdBossSpawn)
        {
            ChangeSpawnState(new BossState());
            thirdBossSpawn = true;
        }
        else if (GameManager.instance.score >= 4000 && !fourthBossSpawn)
        {
            ChangeSpawnState(new BossState());
            fourthBossSpawn = true;
        }
    }

    public void FisrtSpawn()
    {
        InvokeRepeating(nameof(SpawnNormalMrDirt), 0.5f, Random.Range(1.5f, 5f));
    }
    public void SecondSpawn()
    {
        InvokeRepeating(nameof(SpawnSpeedyMrDirt), 0.5f, Random.Range(3f, 10f));
        InvokeRepeating(nameof(SpawnNormalMrDirt), 0.5f, Random.Range(1.5f, 5f));
    }
    public void ThirdSpawn()
    {
        InvokeRepeating(nameof(SpawnSpeedyMrDirt), 0.5f, Random.Range(3f, 10f));
        InvokeRepeating(nameof(SpawnHeavyMrDirt), 0.5f, Random.Range(3f, 10f));
    }
    public void FourthSpawn()
    {
        InvokeRepeating(nameof(SpawnNormalMrDirt), 0.5f, Random.Range(1.5f, 5f));
        InvokeRepeating(nameof(SpawnSpeedyMrDirt), 2.5f, Random.Range(3f, 10f));
        InvokeRepeating(nameof(SpawnHeavyMrDirt), 5f, Random.Range(3f, 10f));
    }

    public void SpawnNormalMrDirt()
    {
        GameObject go = Instantiate(mrDirtyPrefab);
        go.transform.position = spawnPos.position;
    }

    public void SpawnSpeedyMrDirt()
    {
        GameObject go = Instantiate(speedyMrDirtPrefab);
        go.transform.position = spawnPos.position;
    }

    public void SpawnHeavyMrDirt()
    {
        GameObject go = Instantiate(heavyMrDirtPrefab);
        go.transform.position = spawnPos.position;
    }

    public void SpawnTornadoBoss()
    {
        GameObject go = Instantiate(tornadoBossPrefab);
        go.transform.position = bossSpawnPos.position;
        go.GetComponent<Tornado>().OnDeleted += DisableBossSpawned;
    }

    private void DisableBossSpawned()
    {
        bossSpawned = false;
    }

    public void OnSummonBoss()
    {
        warningFadeAnimation.DORestartById("In");

        while(true)
        {
            timer += 1 * Time.deltaTime;
            if(timer >= 3)
            {            
                foreach (var obj in warningObject)
                {
                    obj.SetActive(false);
                }
                bossBanner.gameObject.SetActive(false);
                timer = 0;
                SpawnTornadoBoss();
                break;
            }
        }
    }

    public void ChangeSpawnState(ISpawnerState state)
    {
        currentSpawnState?.Exit(this);
        currentSpawnState = state;
        currentSpawnState?.Enter(this);
    }
}
