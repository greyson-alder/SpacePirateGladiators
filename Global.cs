global using Godot;
global using System;

namespace SpacePirateGladiators;

public partial class Global : Node
{

	[Export]
	public int testing = 100;

	public double knockback = 1.0;
	public double damage = 1.0;
	public int projectileCount = 1;
	public double speed = 1.0;
	public double fireRate = 1.0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
