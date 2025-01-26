using ProjectT.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : MonoBehaviour, ISpawnerState
{
    public void Enter(EnemySpawner spawner)
    {
        spawner.bossSpawned = true;
        Invoke(nameof(spawner.OnSummonBoss), 0.25f);
    }

    public void Exit(EnemySpawner spawner)
    {
        CancelInvoke();
    }
}
