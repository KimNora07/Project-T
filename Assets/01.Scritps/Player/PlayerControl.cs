namespace ProjectT.Player
{
    //Systems
    using System.Collections;
    using System.Collections.Generic;

    //UnityEngine
    using UnityEngine;
    using UnityEngine.Rendering;

    public class PlayerControl : MonoBehaviour
    {
        [Header("PlayerFly Setting")]
        [SerializeField] private float minFlyDeg                    = default;
        [SerializeField] private float maxFlyDeg                    = default;
        [SerializeField] private float flyLimitY                    = default;
        [SerializeField] private float flyPower                     = default;
        [SerializeField] private float flyingGravityScale           = default;
        [SerializeField] private float fallingGravityScale          = default;
        [SerializeField] private float groundCheckRange             = default;
        [SerializeField] private LayerMask groundLayer              = default;
        [SerializeField] private KeyCode flyKey                     = KeyCode.None;

        [Space(10)]
        [Header("PlayerShoot Setting")]
        [SerializeField] private int bulletSpreadAngleRange       = default;
        [SerializeField] private GameObject bubblePrefab          = default;
        [SerializeField] private Transform bubbleGunPosition      = default;
        [SerializeField] private Transform firePosition           = default;

        private float originGravityScale = default;

        private Rigidbody2D rb = null;

        private float angle = default;
        private bool isFlying = default;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            originGravityScale = 0;
        }

        private void Update()
        {
            Debug.Log(angle);

            Mathf.FloorToInt(angle);

            //reset GraityScale
            if (CheckGround())
            {
                rb.gravityScale = originGravityScale;
            }

            if (angle > maxFlyDeg && angle < minFlyDeg)
            {
                Fly(flyPower);
            }
            else
            {
                rb.gravityScale = fallingGravityScale;
            }



            SpinGun();
            Shoot();
        }

        //Player Jump
        private void Fly(float flyPower)
        {
            if (Input.GetMouseButtonDown(0))
            {

                rb.velocity = Vector2.zero;
                rb.gravityScale = originGravityScale;

            }
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(Vector2.up * flyPower, ForceMode2D.Force);
            }
            else
            {
                rb.gravityScale = fallingGravityScale;
            }
        }

        //Check Ground
        private bool CheckGround()
        {
            return Physics2D.Raycast(transform.position, Vector2.down, groundCheckRange, groundLayer);
        }

        private void SpinGun()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle = Mathf.Atan2(mousePosition.y - bubbleGunPosition.position.y, mousePosition.x - bubbleGunPosition.position.x) * Mathf.Rad2Deg;
            bubbleGunPosition.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void Shoot()
        {
            if(Input.GetMouseButton(0))
            {
                BulletSpread();
                Instantiate(bubblePrefab, firePosition.position, Quaternion.Euler(0, 0, angle));
            }
        }

        private void BulletSpread()
        {
            int bulletSpreadAngle = (int)Random.Range(-bulletSpreadAngleRange, bulletSpreadAngleRange);
            angle += bulletSpreadAngle;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector2.down * groundCheckRange);
        }
    }
}


