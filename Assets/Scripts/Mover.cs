using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
	private const string Horizontal = nameof(Horizontal);

	[SerializeField] private float _speed = 2f;
	[SerializeField] private float _jumpForce = 200f;
	[SerializeField] private GroundChecker _groundChecker;
	[SerializeField] private UserInut _userInput;

	private Rigidbody2D _rigidbody;

	private float _direction = 1f;
	private float _currentDirection = 1f;

	private bool _isGround = false;

	public float Direction => _direction;

	public event Action ChangedDirection;
	public event Action Jumping;

	private void OnEnable()
	{
		_groundChecker.Grounded += TouchDoun;
		_groundChecker.Fly += Fly;
	}

	private void OnDisable()
	{
		_groundChecker.Grounded -= TouchDoun;
		_groundChecker.Fly -= Fly;
	}

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		ChangeSpeed();

		if (_userInput.IsSpaceDown && _isGround)
			StartJump();
	}

	private void ChangeSpeed()
	{
		_direction = _userInput.HorizontalAxisValue;

		if (_direction > 0 && _currentDirection < 0)
		{
			_currentDirection = _direction;

			ChangedDirection?.Invoke();
		}

		if (_direction < 0f && _currentDirection > 0)
		{
			_currentDirection = _direction;

			ChangedDirection?.Invoke();
		}

		_rigidbody.velocity = new Vector2(_direction * _speed * Time.fixedDeltaTime, _rigidbody.velocity.y);
	}

	private void StartJump()
	{
		Jumping?.Invoke();

		_rigidbody.AddForce(Vector2.up * _jumpForce);
	}

	private void TouchDoun()
	{
		_isGround = true;
	}

	private void Fly()
	{
		_isGround = false;
	}
}
