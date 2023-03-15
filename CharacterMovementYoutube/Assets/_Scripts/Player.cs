using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] bool _canMove = false;
    [SerializeField] float _speed = 3f;
    [SerializeField] CharacterController _characterController;
    [SerializeField] Animator _animator;

    IInputReader _input;
    IMovementService _movementService;
    
    public IInputReader InputReader { get; private set; }
    public bool CanMove => _canMove;
    

    void OnValidate()
    {
        if (_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }

        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    void Awake()
    {
        InputReader = new NewInputReader();
        _movementService = new PlayerMovementManager(this);
    }

    void Update()
    {
        _movementService.Tick();
    }

    void FixedUpdate()
    {
        _movementService.FixedTick();
    }

    void LateUpdate()
    {
        _animator.SetFloat("speed", _movementService.MoveDirection.magnitude);
        
        Vector3 normalized = _movementService.MoveDirection.normalized;
        
        _animator.SetFloat("directionX",normalized.x,0.1f, Time.deltaTime);
        _animator.SetFloat("directionY", normalized.z, 0.1f, Time.deltaTime);
    }
}
