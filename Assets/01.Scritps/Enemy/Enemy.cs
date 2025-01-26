using System.Runtime.CompilerServices;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Animations;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public EnemyData data;
    public IState currentState;

    public Rigidbody2D body;
    public Animator animator;

    #region Data
    [HideInInspector] public string enemyName;
    [HideInInspector] public int    dirtyLevel;    
    [HideInInspector] public float  maxDirtyGuage;
    public float  currentDirtyGuage;
    [HideInInspector] public float  moveSpeed;
    [HideInInspector] public AnimatorOverrideController changeCleanAnimator;
    #endregion

    private void Awake()
    {
        LoadData();
    }

    private void LoadData()
    {
        this.enemyName = data.enemyName;
        this.maxDirtyGuage = data.maxDirtyGuage;
        this.currentDirtyGuage = maxDirtyGuage;
        this.moveSpeed = data.moveSpeed;
        if(data.changeCleanAnimator != null)
        {
            this.changeCleanAnimator = data.changeCleanAnimator;
        }
    }
    
    public void ChangeState(IState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState?.Enter(this);
    }

    public virtual void Move() { }
}
