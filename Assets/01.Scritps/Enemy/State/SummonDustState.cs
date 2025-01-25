using UnityEngine;

public class SummonDustState : MonoBehaviour, IState
{
    private Tornado tornado;

    // ���� �ð� ���� Dust�� ��ȯ�� �߻�
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
