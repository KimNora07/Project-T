namespace ProjectT.Player
{
    //Systems
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;

    //UnityEngine
    using UnityEngine;

    public class PlayerControl : MonoBehaviour
    {
        [Header("PlayerInfo")]
        [SerializeField] private float jumpPower             = default;
        [SerializeField] private float jumpRange             = default;
        [SerializeField] private float fallingGravityScale   = default;
        [SerializeField] private LayerMask groundLayer       = default;
        [SerializeField] private KeyCode jumpKey             = KeyCode.None;

        private float originGravityScale = default;
        private Rigidbody2D rb = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            originGravityScale = rb.gravityScale;
        }

        void Update()
        {
            GravityControl();
            if(Input.GetKeyDown(jumpKey))
            {
                Jump(jumpPower, jumpKey);
            }
        }

        private void Jump(float jumpPower, KeyCode jumpKey)
        {
            if(CheckGround(jumpRange, groundLayer))
            {
                rb.velocity = Vector2.zero;                                         //Don't Add Force
                rb.AddForce(Vector2.up * jumpPower , ForceMode2D.Impulse);
            }
        }

        private void GravityControl()
        {
            //Control Falling Gravity
            if(rb.velocity.y <= 0)
            {
                rb.gravityScale = fallingGravityScale;
            }
            else
            {
                rb.gravityScale = originGravityScale;
            }
        }

        private bool CheckGround(float jumpRange, LayerMask groundLayer)
        {
            return Physics2D.Raycast(transform.position, Vector2.down, jumpRange, groundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector2.down * jumpRange);
        }
    }
}


