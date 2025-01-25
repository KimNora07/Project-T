using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;


public enum EnemyType { Dirty, Clean }
public class Enemy : MonoBehaviour
{
    public EnemyData data;
    private IState currentState;
    public EnemyType currentEnemyType = EnemyType.Dirty;

    public Rigidbody2D body;
    public Animator animator;

    public const float bubbleLevel1 = 0.5f;
    public const float bubbleLevel2 = 0.75f;
    public const float bubbleLevel3 = 1f;

    public GameObject bubbleObject;

    // Data
    [HideInInspector] public string enemyName;
    [HideInInspector] public int    dirtyLevel;    
    [HideInInspector] public float  maxDirtyGuage;
    [HideInInspector] public float  currentDirtyGuage;
    [HideInInspector] public float  moveSpeed;
    [HideInInspector] public AnimatorOverrideController changeCleanAnimator;

    private float dirtyGuagePercent => currentDirtyGuage / maxDirtyGuage;

    public delegate void EnemyDelegate();
    public event EnemyDelegate onDirtyGuageToZeroEvent;    

    private void Awake()
    {
        LoadData();
    }

    private void Start()
    {
        onDirtyGuageToZeroEvent += OnChangedClean;
        ChangeState(new IdleState());
    }

    private void Update()
    {
        currentState?.Updated(this);

        if (Input.GetKeyDown(KeyCode.P))
        {
            currentDirtyGuage -= 10;
        }

        if (currentDirtyGuage <= 0)
        {
            onDirtyGuageToZeroEvent?.Invoke();
        }

        if (dirtyGuagePercent <= 0.75f && dirtyGuagePercent > 0.5f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel1, bubbleLevel1, bubbleLevel1);
        }
        else if(dirtyGuagePercent <= 0.5f && dirtyGuagePercent > 0.25f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel2, bubbleLevel2, bubbleLevel2);
        }
        else if(dirtyGuagePercent <= 0.25f)
        {
            bubbleObject.transform.localScale = new Vector3(bubbleLevel3, bubbleLevel3, bubbleLevel3);
        }
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

    private void OnChangedClean()
    {
        animator.runtimeAnimatorController = changeCleanAnimator;
        bubbleObject.SetActive(false);
        currentEnemyType = EnemyType.Clean;
    }
}
