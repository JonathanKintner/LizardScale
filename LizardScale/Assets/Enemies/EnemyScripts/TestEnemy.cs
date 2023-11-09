using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class TestEnemy : Enemy
{
    private void Start()
    {
        states.Add(new Idle());
        states.Add(new Pacing());
        CurrentState = states[0];
        SwitchState(states[1]);
    }

    private void FixedUpdate()
    {
        CurrentState.StateUpdate(this);
    }

    
}
