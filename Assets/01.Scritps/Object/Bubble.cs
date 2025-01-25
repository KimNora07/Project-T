namespace ProjectT.Object
{
    //System
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    //UnityEngine
    using UnityEngine;
    using UnityEngine.UIElements;

    public class Bubble : MonoBehaviour
    {
        [Header("Bubble Setting")]
        [SerializeField] private LayerMask collidingLayer   = default;
        [SerializeField] private float checkRange           = default;
        [SerializeField] private float bubbleSpeed          = default;
        [SerializeField] private float bubbleDistroyTime    = default;

        private Rigidbody2D rb = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Destroy(gameObject, bubbleDistroyTime);
        }

        private void Update()
        {
            if(CheckCollider(collidingLayer))
            {
                Pop();
            }
        }

        private void FixedUpdate()
        {
            transform.Translate(Vector3.right * bubbleSpeed * Time.fixedDeltaTime);
        }

        private bool CheckCollider(LayerMask collidingLayer)
        {
            return Physics2D.OverlapCircle(transform.position, checkRange, collidingLayer);
        }

        private void Pop()
        {
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, checkRange);
        }
    }
}


