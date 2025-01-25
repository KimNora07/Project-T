using ProjectT.Player;
using UnityEngine;

public class Dust : MonoBehaviour
{
    public Transform target;
    private Vector3 targetDistance;
    public float moveSpeed;

    private void Awake()
    {
        target = FindAnyObjectByType<PlayerControl>().transform;  
    }
    private void Start()
    {
        targetDistance = (target.transform.position - this.transform.position).normalized;
    }

    private void Update()
    {
        this.transform.position += targetDistance * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
