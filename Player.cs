using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
    public int Speed { get; set; } = 400;

	private bool readyToFire { get; set; } = true;
	// public Vector2 ScreenSize;

	// [Export]
    // public float RotationSpeed { get; set; } = 1.5f;

	private int _rotationDirection;

	private Vector2 _velocity = Vector2.Zero;

	[Export]
	public PackedScene ProjectileScene { get; set; }

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		// getVector is normalised
        _velocity = inputDirection * Speed;

		if (Input.IsActionPressed("fire_projectile") && readyToFire) {
			fireProjectile();
		}
    }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		handleMouseClick();
		ProjectileScene = GD.Load<PackedScene>("res://projectile.tscn");
		// ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
		GetInput();
		Position += _velocity * (float)delta;
		Position = new Vector2(
			x: Position.X,
			y: Position.Y
		);
		LookAt(GetGlobalMousePosition());
	}

	public void handleMouseClick() {
		// var myProjectile = GD.Load("res://projectile.tscn").GetScript();
		// projectileScript = GetNode<ScriptName>("Projectile.cs");
		// myProjectile.init(new Vector2(1,1), Element.Neutral, 100);
		// Projectile projectile = ProjectileScene.Instantiate<Projectile>().init(new Vector2(1,1), Element.Neutral, 100);
		// AddChild(projectile);
		// Console.WriteLine(projectile);
		// GetNode<Node2D>("Weapon").AddChild(myProjectile);
		var playerVariables = GetNode<Global>("/root/PlayerVariables");
		var test = playerVariables.testing.ToString();
		GD.Print(test);
	}

	public async void startFiringCooldown() {
		GD.Print("Timer starting");
		await ToSignal(GetTree().CreateTimer(3.0), "timeout");
		GD.Print("Timer ended!");
		readyToFire = true;
	}

	private void fireProjectile() {
		GD.Print("Hello");
		readyToFire = false;
		startFiringCooldown();

		Projectile projectile = ProjectileScene.Instantiate<Projectile>();
		projectile.init((new Vector2((float)Math.Cos(Rotation),(float)Math.Sin(Rotation))), Element.Neutral, 1);
		projectile.Position = Position;

		GetTree().Root.GetNode("Main").AddChild(projectile);

		GD.Print(RotationDegrees);
	}

}
