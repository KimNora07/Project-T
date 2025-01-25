using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Dirty, Clean }

public class NormalEnemy : Enemy
{
    public EnemyType currentEnemyType = EnemyType.Dirty;

    public const float bubbleLevel1 = 0.5f;
    public const float bubbleLevel2 = 0.75f;
    public const float bubbleLevel3 = 1f;

    public GameObject bubbleObject;

    private float dirtyGuagePercent => currentDirtyGuage / maxDirtyGuage;

    public delegate void EnemyDelegate();
    public event EnemyDelegate onDirtyGuageToZeroEvent;

    void Start()
    {
        onDirtyGuageToZeroEvent += OnChangedClean;
        //ChangeState(new RunState());
    }

    void Update()
    {
        //currentState?.Updated(this);

        if (currentDirtyGuage <= 0)
        {
            onDirtyGuageToZeroEvent?.Invoke();
        }

        if (dirtyGuagePercent <= 0.75f && dirtyGuagePercent > 0.5f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel1, bubbleLevel1, bubbleLevel1);
        }
        else if (dirtyGuagePercent <= 0.5f && dirtyGuagePercent > 0.25f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel2, bubbleLevel2, bubbleLevel2);
        }
        else if (dirtyGuagePercent <= 0.25f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel3, bubbleLevel3, bubbleLevel3);
        }
    }

    private void OnChangedClean()
    {
        animator.runtimeAnimatorController = changeCleanAnimator;
        bubbleObject.SetActive(false);
        currentEnemyType = EnemyType.Clean;
    }
}
