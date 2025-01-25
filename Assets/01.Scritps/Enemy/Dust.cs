using ProjectT.Player;
using UnityEngine;

public class Dust : MonoBehaviour
{
    public Transform target;
    private Vector3 targetDistance;
    public float moveSpeed;

    private void OnEnable()
    {
        target = FindAnyObjectByType<PlayerControl>().transform;
        targetDistance = (target.position - this.transform.position).normalized;
    }

    private void Update()
    {
        targetDistance = (target.position - this.transform.position).normalized;
        this.transform.position += targetDistance * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this);
        }
    }
}
