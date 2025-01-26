using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnerState
{
    void Enter(EnemySpawner spawner);
    void Exit(EnemySpawner spawner);
}
