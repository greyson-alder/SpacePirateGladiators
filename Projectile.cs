using Godot;
using System;

public partial class Projectile : Area2D
{

	[Export]
	int Speed = 400;

	private Vector2 _direction;
	private Element _element;
	private double _damage;

	public void init(Vector2 direction, Element element, double damage) {
		_direction = direction;
		_element = element;
		_damage = damage;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(this.ToString());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += Speed * _direction * (float)delta;
		// GD.Print(Position.ToString());
	}

	public override string ToString() {
		return $@"
			Heading Direction: {_direction.ToString()}, 
			Element: {_element.ToString()}, 
			Damage: {_damage.ToString()}
		";
	}

	private void OnNoLongerVisible() {
		QueueFree();
	}


}

