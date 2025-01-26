using ProjectT.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NormalState : MonoBehaviour,ISpawnerState
{
    public void Enter(EnemySpawner spawner)
    {
        if(GameManager.instance.score >= 0 && GameManager.instance.score < 100)
        {
            spawner.FisrtSpawn();
        }
        else if(GameManager.instance.score >= 100 && GameManager.instance.score < 500)
        {
            spawner.SecondSpawn();
        }
        else if(GameManager.instance.score >= 500 && GameManager.instance.score < 2000)
        {
            spawner.ThirdSpawn();
        }
        else
        {
            spawner.FourthSpawn();   
        }
    }

    public void Exit(EnemySpawner spawner)
    {
        spawner.CancelInvoke();
    }
}
