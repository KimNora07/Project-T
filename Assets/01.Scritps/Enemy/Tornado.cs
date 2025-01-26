using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : BossEnemy
{
    public GameObject dustPrefab;

    public GameObject effectObject1;
    public GameObject effectObject2;

    public delegate void TornadoDelegate();
    public event TornadoDelegate OnDeleted;

    private IEnumerator SummonTime()
    {
        float rand = Random.Range(0.5f, 2f);
        yield return new WaitForSeconds(rand);

        GameObject go = Instantiate(dustPrefab);
        go.transform.position = this.transform.position;

        StartCoroutine(SummonTime());
    }

    public void SummonDust()
    {
        StartCoroutine(SummonTime());
    }

    public void OnEffect1()
    {
        effectObject1.SetActive(true);
    }

    public void OnEffect2()
    {
        effectObject2.SetActive(true);
    }

    private void OnDestroy()
    {
        OnDeleted?.Invoke();
    }
}
