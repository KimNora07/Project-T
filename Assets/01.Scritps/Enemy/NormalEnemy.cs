using ProjectT.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Dirty, Clean }

public class NormalEnemy : Enemy
{
    public EnemyType currentEnemyType = EnemyType.Dirty;

    public const float bubbleLevel1 = 0.75f;
    public const float bubbleLevel2 = 1.25f;
    public const float bubbleLevel3 = 2f;

    public GameObject bubbleObject;

    private float dirtyGuagePercent => currentDirtyGuage / maxDirtyGuage;

    public delegate void EnemyDelegate();
    public event EnemyDelegate onDirtyGuageToZeroEvent;

    void Start()
    {
        onDirtyGuageToZeroEvent += OnChangedClean;
    }

    private void OnChangedClean()
    {
        animator.runtimeAnimatorController = changeCleanAnimator;
        GameManager.instance.score += getScore;
        bubbleObject.SetActive(false);
        currentEnemyType = EnemyType.Clean;
    }

    public void BubbleSize()
    {
        if (currentDirtyGuage <= 0)
        {
            onDirtyGuageToZeroEvent?.Invoke();
        }

        if (currentDirtyGuage / maxDirtyGuage <= 0.75f && currentDirtyGuage / maxDirtyGuage > 0.5f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel1, bubbleLevel1, bubbleLevel1);
        }
        else if (currentDirtyGuage / maxDirtyGuage <= 0.5f && currentDirtyGuage / maxDirtyGuage > 0.25f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel2, bubbleLevel2, bubbleLevel2);
        }
        else if (currentDirtyGuage / maxDirtyGuage <= 0.25f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel3, bubbleLevel3, bubbleLevel3);
        }
    }
}
