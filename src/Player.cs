using System;
using Godot;


public class Player : KinematicBody2D
{
    public  int SPEED = 300;
    public  float GRAVITY = 12.0f;
    public  float JUMP = -400.0f;
    public bool OnGround;

    public float moveDirection;
    public Vector2 velocity = new Vector2();
    
    
}
