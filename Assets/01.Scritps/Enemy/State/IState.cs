public interface IState
{
    void Enter(Enemy enemy);
    void Updated(Enemy enemy);
    void Exit(Enemy enemy);
}
