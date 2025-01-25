using UnityEngine;

public class SummonDustState : MonoBehaviour, IState
{
    private Tornado tornado;

    // 랜덤 시간 마다 Dust를 소환및 발사
    public void Enter(Enemy enemy)
    {
        tornado = enemy.GetComponent<Tornado>();
        tornado.SummonDust();
    }
    public void Updated(Enemy enemy)
    {
        
    }
    public void Exit(Enemy enemy)
    {
        tornado.StopAllCoroutines();
    }
}
