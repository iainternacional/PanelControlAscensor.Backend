namespace ElevatorControl.Domain.Entitties;

public class ElevatorState
{
    public int CurrentFloor { get; set; }
    public bool DoorsOpen { get; set; }
    public bool IsMoving { get; set; }
    public Queue<int> FloorQueue { get; set; } = new();
}
