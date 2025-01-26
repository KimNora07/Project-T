using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrDirt : NormalEnemy
{
    private void OnEnable()
    {
        ChangeState(new RunState());
    }

    private void Update()
    {
        currentState?.Updated(this);

        BubbleSize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bubble") && currentEnemyType == EnemyType.Dirty)
        {
            currentDirtyGuage -= 1f;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Berrier"))
        {
            Destroy(this.gameObject);
        }
    }
}
