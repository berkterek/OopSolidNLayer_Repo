using UnityEngine;

public class CharacterControllerMoveDal : IMoverDal
{
    readonly CharacterController _characterController;
    float _speed = 5f;

    public CharacterControllerMoveDal(Transform transform)
    {
        _characterController = transform.GetComponent<CharacterController>();
    }

    public void FixedTick(Vector3 moveDirection)
    {
        _characterController.Move(Time.deltaTime * _speed * moveDirection);
    }
}

public class TranslateMoveDal : IMoverDal
{
    readonly Transform _transform;
    float _speed = 5f;
    
    public TranslateMoveDal(Transform transform)
    {
        _transform = transform;
    }
    
    public void FixedTick(Vector3 moveDirection)
    {
        _transform.Translate(Time.deltaTime * _speed * moveDirection);
    }
}

public interface IMoverDal
{
    void FixedTick(Vector3 moveDirection);
}