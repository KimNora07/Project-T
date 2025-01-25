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
    }
}
