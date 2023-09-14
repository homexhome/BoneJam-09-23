using Godot;
using System;

public partial class DebugPanel : ItemList
{
	public Label PositionLabel;
    public Label TargetLabel;


    private CharacterController _characterController;

	private float _speed;
	private float _name;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        PositionLabel = GetNode("Position") as Label;
        TargetLabel = GetNode("Target") as Label;

        var _characterController = GetTree().GetNodesInGroup("Player")[0] as CharacterController;
        _characterController.OnPositionChanged += UpdatePositionLabel;
		UpdateTargetLabel("No target");
    }
    
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{

	}

	private void UpdatePositionLabel(Vector3 speed) {
		PositionLabel.Text = String.Join(' ', "Position: " ,speed.ToString());
	}
	public void UpdateTargetLabel(string name) {
		TargetLabel.Text = String.Join(' ', "Target: ", name);
	}
}
