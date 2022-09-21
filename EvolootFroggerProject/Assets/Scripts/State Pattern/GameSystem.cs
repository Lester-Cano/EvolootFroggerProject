using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : StateMachine
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Moving()
    {
        StartCoroutine(State.Move());
    }
}
