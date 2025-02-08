using Godot;
using System;

public partial class PlayerBaseControl : CsgSphere3D
{
	[Export]
	public float Speed = 5;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector3 currentPosition = this.Position;
        Vector2 input = Input.GetVector("Left", "Right", "Up", "Down");
		float deltaf = (float)delta;
		input = input * (Speed * deltaf );
		currentPosition +=new Vector3( input.X,0,input.Y);
		this.Position = currentPosition;
		
		
    }
}
