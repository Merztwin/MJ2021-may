using System;
using Godot;


public class PlayerFSM : StateMachine
{
    public override void _Ready()
    {
        base._Ready();
        AddState("IDLE");
        AddState("RUNNING");
        AddState("JUMPING");
        AddState("FALLING");
        CallDeferred("_SetState", "IDLE");
    }

    public override void _StateLogic(float delta)
    {
        InputHandling(delta);
        ApplyGravity(delta);
    }

    private void InputHandling(float delta)
    {
        GetParent<Player>().moveDirection = (Input.GetActionStrength("MoveRight")-Input.GetActionStrength("MoveLeft"));
        GetParent<Player>().velocity.x = (GetParent<Player>().moveDirection*GetParent<Player>().SPEED);
        GetParent<Player>().velocity = GetParent<Player>().MoveAndSlide(GetParent<Player>().velocity, Vector2.Up);
    }

    private void ApplyGravity(float delta)
    {
        GetParent<Player>().OnGround = GetParent<Player>().IsOnFloor();
        GetParent<Player>().velocity.y += GetParent<Player>().GRAVITY;
        if(GetParent<Player>().OnGround&&Input.IsActionJustPressed("Jump"))
            GetParent<Player>().velocity.y = GetParent<Player>().JUMP; 
    }

}