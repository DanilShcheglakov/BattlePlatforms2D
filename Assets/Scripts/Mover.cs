using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
	[SerializeField] private float _speed = 2f;
	[SerializeField] private float _jumpForce = 200f;
	[SerializeField] private GroundChecker _groundChecker;
	[SerializeField] private UserInut _userInput;

	private Rigidbody2D _rigidbody;

	private float _direction = 1f;
	private float _currentDirection = 1f;

	public event Action DirectionChanged;
	public event Action Jumping;

	public float Direction => _direction;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		ChangeSpeed();

		if (_userInput.IsSpaceDown && _groundChecker.IsGrounded)
			StartJump();
	}

	private void ChangeSpeed()
	{
		_direction = _userInput.HorizontalAxisValue;

		if (_direction > 0 && _currentDirection < 0)
		{
			_currentDirection = _direction;

			DirectionChanged?.Invoke();
		}

		if (_direction < 0f && _currentDirection > 0)
		{
			_currentDirection = _direction;

			DirectionChanged?.Invoke();
		}

		_rigidbody.velocity = new Vector2(_direction * _speed * Time.fixedDeltaTime, _rigidbody.velocity.y);
	}

	private void StartJump()
	{
		Jumping?.Invoke();

		_rigidbody.AddForce(Vector2.up * _jumpForce);
	}
}
