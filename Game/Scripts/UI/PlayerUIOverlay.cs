using Godot;
using System;

public partial class PlayerUIOverlay : Control
{
	[Export]
	public RichTextLabel PlayerNameLabel;
	[Export]
	public RichTextLabel PlayerScoreLabel;
	public float CurrentScore = 0;
	public string PlayerName = "Player";
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		PlayerNameLabel.Text = SaveSystemLogic.CurrentPlayer;
		if(PlayerScoreLabel != null)
			PlayerScoreLabel.Text = "Highscore: " + CurrentScore;
	}
}
