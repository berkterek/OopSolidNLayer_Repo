using UnityEngine;

public class PlayerMovementManager : IMovementService
{
    readonly IMoverDal _moverDal;
    readonly Player _player;
    
    public Vector3 MoveDirection { get; private set; }

    public PlayerMovementManager(Player player)
    {
        _moverDal = new CharacterControllerMoveDal(player.transform);
        _player = player;
    }

    public void Tick()
    {
        MoveDirection = _player.InputReader.MoveDirection;
    }

    public void FixedTick()
    {
        if (!_player.CanMove) return;
        
        _moverDal.FixedTick(MoveDirection);
    }
}

public interface IMovementService
{
    void Tick();
    void FixedTick();
    Vector3 MoveDirection { get; }
}