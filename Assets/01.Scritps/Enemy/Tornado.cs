using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : BossEnemy
{
    public GameObject dustPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameObject go = Instantiate(dustPrefab);
            go.transform.position = this.transform.position;
        }
        
    }
}
