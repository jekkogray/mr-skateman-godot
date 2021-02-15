using Godot;
using System;

public class Ball : KinematicBody2D
{

	// Constants input player control.
	float _moveXvelocity = 100;
	float _moveYvelocity = 100;

	private Vector2 _playerVelocity = new Vector2(0, 9.8f);

	bool pressed = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Specify the signal
		GetNode<Button>("BallButton").Connect("pressed", this, nameof(_OnButtonPressed));
	}

	void _GetInput(float delta)
	{
		// Apply graviity
		_playerVelocity.y += 9.8f;
		if(Input.IsActionJustPressed("ui_up")){
			if(IsOnFloor()){
				_playerVelocity.y = _moveYvelocity;
			}
		}

		if (Input.IsActionPressed("ui_left"))
		{
			_playerVelocity.x -= _moveXvelocity;
		}
		else
		{
			_playerVelocity.x = 0;
		}
		if (Input.IsActionPressed("ui_right"))
		{
			_playerVelocity.x += _moveXvelocity;
		}
		else
		{
			_playerVelocity.x = 0;
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		_GetInput(delta);
	}



	public void _OnButtonPressed()
	{
		pressed = !pressed;
		if (pressed)
		{
			GetNode<Label>("../BallLabel2D/BallLabel").Text = "Hi, I am ball";
		}
		else
		{
			GetNode<Label>("../BallLabel2D/BallLabel").Text = "";
		}
	}
}
