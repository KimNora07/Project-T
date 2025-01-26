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
        if (collision.CompareTag("Bubble"))
        {
            currentDirtyGuage -= 0.25f;
        }
    }
}
