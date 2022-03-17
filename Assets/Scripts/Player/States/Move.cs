using UnityEngine;

public class Move : State<PlayerData>
{
    public Move(PlayerData data, StateMachine<PlayerData> stateMachine) : base(data, stateMachine)
    {
    }

    //public override bool IsStatePlay() => Data.PlayerInput.IsMove;

    public override void Exit()
    {
        //Data.UnitNavMesh.SetDestination(Data.Rigidbody.position);
    }

    public override void PhysicsUpdate()
    {
        if (PlayerInput.Instance.ActiveRadius == false)
        {
            Data.AnimationComponent.PlayAnimation(UnitAnimations.Idle, true);
            return;
        }
        
        // var lerpSpeed = Mathf.InverseLerp(0, 80, Data.PlayerInput.Distance);
        // Data.AnimationComponent.SetSpeed(lerpSpeed);
        // Data.Transform.rotation = Quaternion.AngleAxis(-Data.PlayerInput.Angle + Data.AngleOffset, Vector3.up);
        // lerpSpeed = lerpSpeed < Data.MinWalkSpeed ? Data.MinWalkSpeed : lerpSpeed;
        // Data.UnitNavMesh.Move(Data.Transform.position + Data.Transform.forward * (Data.MoveSpeed * lerpSpeed));
        
        Data.AnimationComponent.PlayAnimation(UnitAnimations.Run, true);
        Data.Transform.rotation = Quaternion.AngleAxis(-PlayerInput.Instance.Angle + Data.AngleOffset, Vector3.up);
        Data.UnitNavMesh.Move(Data.Transform.position + Data.Transform.forward * Data.MoveSpeed);
    }
}