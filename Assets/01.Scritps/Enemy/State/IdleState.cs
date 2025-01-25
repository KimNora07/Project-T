using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public void Enter(Enemy enmey)
    {

    }

    public void Updated(Enemy enemy)
    {
        Vector3 moveVec = new Vector3(-1, 0, 0) * enemy.moveSpeed * Time.deltaTime;
        enemy.transform.position += moveVec;
    }

    public void Exit(Enemy enmey)
    {

    }
}
