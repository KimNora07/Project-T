using UnityEngine;

[CreateAssetMenu(fileName = "new Enemy", menuName = "Data/Unit/Enemy")]
public class EnemyData : ScriptableObject
{
    public string   enemyName;
    public int      dirtyLevel;
    public float    maxDirtyGuage;
    public float    moveSpeed;

    public AnimatorOverrideController changeCleanAnimator;
}
