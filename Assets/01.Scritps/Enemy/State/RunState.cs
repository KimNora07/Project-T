using UnityEngine;

public class RunState : IState
{
    public void Enter(Enemy enemy)
    {

    }
    public void Updated(Enemy enemy)
    {
        Vector3 moveVec = new Vector3(-1, enemy.body.velocity.y, 0) * enemy.moveSpeed * Time.deltaTime;
        enemy.transform.position += moveVec;
    }
    public void Exit(Enemy enemy)
    {

    }
}
