using Godot;
using System;

public partial class Projectile : Area2D
{

	[Export]
	int Speed = 400;

	private Vector2 _direction;
	private Element _element;
	private int _damage;

	public void init(Vector2 direction, Element element, int damage) {
		_direction = direction;
		_element = element;
		_damage = damage;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += Speed * _direction * (float)delta;
	}
}

