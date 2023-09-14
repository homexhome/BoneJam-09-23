using Godot;
using System;

public partial class ClickableObjectController : StaticBody3D
{
	[Export]
	public string ObjectName;

	private CollisionShape3D _collisionObject;

	[Signal]
	public delegate void ClickedTargetEventHandler(Vector3 clickLocation);
    [Signal]
    public delegate void ClickedNameEventHandler(Vector3 clickLocation);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		_collisionObject = GetNode<CollisionShape3D>("CollisionShape3D");

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}


    public override void _InputEvent(Camera3D camera, InputEvent @event, Vector3 position, Vector3 normal, int shapeIdx) {
        base._InputEvent(camera, @event, position, normal, shapeIdx);
        if (@event is InputEventMouseButton eventMouseButton
        && eventMouseButton.IsPressed()
        && eventMouseButton.ButtonIndex == MouseButton.Left) {
            EmitSignal(nameof(ClickedTarget), GlobalPosition);
            EmitSignal(nameof(ClickedName), ObjectName);
        }
    }
}