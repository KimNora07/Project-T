using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    public GameObject target;

    private void OnEnable()
    {
        ChangeState(new SummonDustState());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            ChangeState(new SplitState());
        }
    }
}
