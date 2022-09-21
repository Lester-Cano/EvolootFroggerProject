using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine:MonoBehaviour
{
    //needs to be protected because so its derriving class can delegate behaviour to the current state
    protected State State;

    public void SetState(State state)
    {
        state = state;
        StartCoroutine(state.Start());
    }
}
