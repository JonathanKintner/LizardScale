using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] EnemySO enemyType;
    [field: SerializeField] public GameObject player { get; private set;} //This gets assigned based on tagged gameobject
    [field: SerializeField] public float hp { get; private set; }
    public float speed { get; private set; }
    public float agroRange { get; private set; } //Distance before being agroed
    public bool canJump { get; private set; } //Can jump between platforms?
    public List<BaseState> states;
    public BaseState CurrentState { get; protected set; }

    public Platform Platform { get; protected set; }

    protected float width = .3f;


    private void Awake()//Set all the variables stored in the scriptable object. 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hp = enemyType.health;
        speed = enemyType.speed;
        agroRange = enemyType.agroDistance;
        canJump = enemyType.canJump;
        states = new List<BaseState>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walkable")
        {
            Platform = collision.gameObject.GetComponent<Platform>();
            Platform.EnemyWidthOffset = width;
            //print("here");
            Platform.SetBounds();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Walkable")
        {
            Platform = null;
        }
    }

    protected void SwitchState(BaseState state)
    {
        state.StateBegin(this);
        CurrentState = state;
    }
}
