using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data;
    private IState currentState;

    public Rigidbody2D body;
    public Animator animator;

    // Data
    [HideInInspector] public string enemyName;
    [HideInInspector] public int    dirtyLevel;    
    [HideInInspector] public float  maxDirtyGuage;
    [HideInInspector] public float  currentDirtyGuage;
    [HideInInspector] public float  moveSpeed;
    [HideInInspector] public AnimatorOverrideController changeCleanAnimator;

    public delegate void EnemyDelegate();
    public event EnemyDelegate onDirtyGuageToZeroEvent;    

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        onDirtyGuageToZeroEvent += ChangeCleanAnimator;
        ChangeState(new IdleState());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentDirtyGuage = 0;
            if (currentDirtyGuage <= 0)
            {
                onDirtyGuageToZeroEvent?.Invoke();
            }
        }
    }

    private void FixedUpdate()
    {
        currentState?.Updated(this);
    }

    private void LoadData()
    {
        this.enemyName = data.enemyName;
        this.maxDirtyGuage = data.maxDirtyGuage;
        this.currentDirtyGuage = maxDirtyGuage;
        this.moveSpeed = data.moveSpeed;
        this.changeCleanAnimator = data.changeCleanAnimator;
    }

    private void ChangeState(IState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    private void ChangeCleanAnimator()
    {
        animator.runtimeAnimatorController = changeCleanAnimator;
    }
}
