using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
/// <summary>
/// Helper class to manage state
/// </summary>
public class StateMachine
{
    public PlayerState CurrentPlayerState { get; set; }

    public void Init(PlayerState playerState)
    {
        CurrentPlayerState = playerState;
        CurrentPlayerState.EnterState();
    }




    /// <summary>
    /// Switch states with optional data
    /// </summary>
    /// <param name="newState"></param>
    /// <param name="data"> !!! Require downcasting (not ideal, to be removed) !!!</param>
    public void ChangeState(PlayerState newState, object data = null)
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = newState;
        if (data != null)
            CurrentPlayerState.EnterState(data);
        else
            CurrentPlayerState.EnterState();
    }
}
