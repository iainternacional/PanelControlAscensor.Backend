using ElevatorControl.Domain.Entitties;

namespace ElevatorControl.Application.Services;

public class ElevatorService
{
    private readonly ElevatorState _state = new();
    private readonly object _lock = new();

    public ElevatorState GetState() => _state;

    public void CallElevator(int floor)
    {
        lock (_lock)
            if (!_state.FloorQueue.Contains(floor))
                _state.FloorQueue.Enqueue(floor);
    }

    public void OpenDoors()
    {
        lock (_lock) { _state.DoorsOpen = true; }
    }

    public void CloseDoors()
    {
        lock (_lock) { _state.DoorsOpen = false; }
    }

    public void Start()
    {
        lock (_lock)
        {
            if (_state.FloorQueue.Any())
            {
                var next = _state.FloorQueue.Dequeue();
                _state.IsMoving = true;
                _state.DoorsOpen = false;
                // Simular desplazamiento síncrono (o disparar background task)
                _state.CurrentFloor = next;
                _state.IsMoving = false;
                _state.DoorsOpen = true;
            }
        }
    }

    public void Stop()
    {
        lock (_lock)
        {
            _state.IsMoving = false;
            _state.DoorsOpen = true;
        }
    }
}
