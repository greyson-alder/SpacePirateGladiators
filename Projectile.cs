using Godot;
using System;

public partial class Projectile : RigidBody2D
{

	[Export]
	int Speed = 400;

	private Vector2 _direction;
	private Element _element;
	private double _damage;

	private int _lifetime = 500;

	public void init(Vector2 direction, Element element, double damage) {
		_direction = direction;
		_element = element;
		_damage = damage;
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// GD.Print(this.ToString());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// GD.Print(Position);
	}

	public override void _PhysicsProcess(double delta) {
		// Position += Speed * _direction * (float)delta;
		
		// GD.Print("Speed: ", Speed);
		// GD.Print("Direction: ", _direction);
		// GD.Print(delta);

		var collisionInformation = MoveAndCollide(_direction * (float)(Speed*delta));
		if (collisionInformation != null) {
			clearProjectile();
		}

		_lifetime -= 1;
		
		if (_lifetime < 0) {
			clearProjectile();
		}
		// GD.Print(Position.ToString());
	}

	private void OnNoLongerVisible() {
		clearProjectile();
	}

	private void clearProjectile() => QueueFree();

	private void OnCollision() => clearProjectile();

	public override string ToString() {
		return $@"
			Heading Direction: {_direction.ToString()}, 
			Element: {_element.ToString()}, 
			Damage: {_damage.ToString()}
		";
	}

}

