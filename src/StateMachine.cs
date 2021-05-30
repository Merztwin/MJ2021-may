using System;
using Godot;
using System.Collections.Generic;

public class StateMachine : Node
{
    string previousState = null, currentState = null, trasition = null;
    List<string> States = new List<string>();
    public string _StateTransition(float delta)
    {
        return null;
    }

    public virtual void _StateLogic(float delta)
    {

    }

    public override void _PhysicsProcess(float delta)
    {
        if(currentState!=null)
        {
            _StateLogic(delta);
            trasition = _StateTransition(delta);
            if(trasition!=null)
                _SetState(trasition);
        }
    }

    public virtual void EnterState(string newState, string oldState)
    {

    }

    public virtual void ExitState(string oldState, string newState)
    {

    }

    public void _SetState(string newState)
    {
        previousState = currentState;
        currentState = newState;

        if(previousState!=null)
            ExitState(previousState,newState);
        if(newState!=null)
            EnterState(newState,previousState);
    }

    public void AddState(string state)
    {
        States.Add(state);
    }
}