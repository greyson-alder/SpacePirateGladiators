using Godot;
using System;

public partial class PlayerCamera : Godot.Camera2D{
	private CharacterBody2D _player;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_player = GetTree().Root.GetNode<CharacterBody2D>("Main/Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = _player.Position;
	}
}
