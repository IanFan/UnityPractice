using System.Collections;
using UnityEngine;

public class StateMachineExample : MonoBehaviour
{
    private IState currentState;

    void Start()
    {
        StartCoroutine(handleState());
    }

    IEnumerator handleState()
    {
        ChangeState(new IdleState());
        yield return new WaitForSeconds(1);
        ChangeState(new BattleState());
        yield return new WaitForSeconds(3);
        ChangeState(new IdleState());
    }

    void FixedUpdate()
    {
        currentState?.Update();
    }

    void ChangeState(IState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }
}


// State 規格
public interface IState
{
    void Enter();
    void Update();
    void Exit();
}


// Idle
public class IdleState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Idle");
    }

    public void Update()
    {
        Debug.Log("Idle...");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle");
    }
}

// BattleState
public class BattleState : IState
{
    public void Enter()
    {
        Debug.Log("Enter Battle");
    }

    public void Update()
    {
        Debug.Log("Battling...");
    }

    public void Exit()
    {
        Debug.Log("Exit Battle");
    }
}