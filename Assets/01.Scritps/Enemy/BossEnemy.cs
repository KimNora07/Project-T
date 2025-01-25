using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public EnemyData data;
    public GameObject target;

    // Data
    [HideInInspector] public string enemyName;
    [HideInInspector] public int dirtyLevel;
    [HideInInspector] public float maxDirtyGuage;
    [HideInInspector] public float currentDirtyGuage;
    [HideInInspector] public float moveSpeed;


    private void Awake()
    {
        LoadData();
    }

    private void LoadData()
    {
        this.enemyName = data.enemyName;
        this.maxDirtyGuage = data.maxDirtyGuage;
        this.currentDirtyGuage = maxDirtyGuage;
        this.moveSpeed = data.moveSpeed;
    }
}
