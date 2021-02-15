using Godot;
using System;

public class BallLabel2D : Node2D
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		Position = GetNode<KinematicBody2D>("../Ball").Position;
		if (Position.y > 100 && Position.y < 250) {
			GetNode<Label>("BallLabel").Text = "Wait.. no no no.";
		} else if (Position.y > 250) {
			GetNode<Label>("BallLabel").Text = "NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO";
		}
	}
}
