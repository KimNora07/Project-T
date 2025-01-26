namespace ProjectT.Player
{
    //Systems
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;

    //UnityEngine
    using UnityEngine;
    using UnityEngine.Rendering;

    public class PlayerControl : MonoBehaviour
    {
        //[Header("PlayerInfo")]


        [Space(10)]
        [Header("PlayerFly Setting")]
        [SerializeField] private float minFlyDeg                  = default;
        [SerializeField] private float maxFlyDeg                  = default;
        [SerializeField] private float flyLimitY                  = default;
        [SerializeField] private float flyPower                   = default;
        [SerializeField] private float flyingGravityScale         = default;

        [Space(10)]
        [Header("PlayerJump Setting")]
        [SerializeField] private float jumpPower                  = default;
        [SerializeField] private float fallingGravityScale        = default;
        [SerializeField] private float groundCheckRange           = default;
        [SerializeField] private Transform groundCheckPosition    = null;
        [SerializeField] private LayerMask groundLayer            = default;
        [SerializeField] private KeyCode jumpKey                  = KeyCode.None;

        [Space(10)]
        [Header("PlayerShoot Setting")]
        [SerializeField] private float fireCoolTime               = default;
        [SerializeField] private int bulletSpreadAngleRange       = default;
        [SerializeField] private GameObject bubblePrefab          = default;
        [SerializeField] private Transform bubbleGunPosition      = default;
        [SerializeField] private Transform firePosition           = default;

        private float originGravityScale = default;

        private Rigidbody2D rb = null;
        private Animator anim  = null;
        private AudioSource sound = null;

        private float angle     = default;
        private float timer     = default;

        private bool isCanFire  = default;
        private bool isFlying   = default;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            sound = GetComponent<AudioSource>();
        }

        private void Start()
        {
            originGravityScale = 0;
        }

        private void Update()
        {
            Mathf.FloorToInt(angle);

            Debug.Log(CheckGround());

            if(rb.velocity.y < 0)
            {
                anim.SetBool("isFlying", true);
            }

            //reset GraityScale
            if (CheckGround())
            {
                anim.SetBool("isFlying", false);
                rb.gravityScale = originGravityScale;
            }

            if (angle > maxFlyDeg && angle < minFlyDeg)
            {
                Fly(flyPower);
            }
            else
            {
                isFlying = false;
                rb.gravityScale = fallingGravityScale;
            }


            SpinGun();
            Shooting();
        }
        private void Fly(float flyPower)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isFlying = true;
                anim.SetBool("isFlying", true);
                rb.velocity = Vector2.zero;
                rb.gravityScale = originGravityScale;

            }
            if (Input.GetMouseButton(0))
            {
                rb.AddForce(Vector2.up * flyPower, ForceMode2D.Force);
            }
            else
            {
                isFlying = false;
                rb.gravityScale = fallingGravityScale;
            }
        }

        //Check Ground
        private bool CheckGround()
        {
            if (!isFlying)
            {
                return Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRange, groundLayer);
            }
            else
            {
                return false;
            }
        }

        private void SpinGun()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            angle = Mathf.Atan2(mousePosition.y - bubbleGunPosition.position.y, mousePosition.x - bubbleGunPosition.position.x) * Mathf.Rad2Deg;
            bubbleGunPosition.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void Shooting()
        {
            if(isCanFire)
            {
                if(Input.GetMouseButton(0))
                {
                    FireBubble();
                    timer = 0f;
                    isCanFire = false;
                    sound.UnPause();
                }
                else
                {
                    sound.Pause();
                }
            }
            else
            {
                timer += Time.deltaTime;

                if(timer >= fireCoolTime)
                {
                    isCanFire = true;
                }
            }
        }

        private void FireBubble()
        {
            BulletSpread();
            Instantiate(bubblePrefab, firePosition.position, Quaternion.Euler(0, 0, angle));
        }

        private void BulletSpread()
        {
            int bulletSpreadAngle = (int)Random.Range(-bulletSpreadAngleRange, bulletSpreadAngleRange);
            angle += bulletSpreadAngle;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckPosition.position, groundCheckRange);
        }
    }
}


