using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerController player) : base(player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log($"{_player.name} is moving on");
    }

    public override void Update()
    {
        if (_player.InputDir.magnitude < 0.1f)
        {
            _player.ChangeState(_player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        Vector3 movementInput = HandleMovement();
        Movement(movementInput * _player.PlayerVariables.MovementSpeed);
        AimDirection();
    }

    Vector3 HandleMovement()
    {
        Vector3 motion = new Vector3(_player.InputDir.x, 0, _player.InputDir.y);

        return motion;
    }
}
