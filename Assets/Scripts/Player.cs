using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	[SerializeField] private Mover _mover;
	[SerializeField] private UserInut _userInput;
	[SerializeField] private GroundChecker _groundChecker;

	private Rigidbody2D _rigidbody;
	private Vector2 _startPosition;

	private float _currentDirection = 1f;

	public event Action DirectionChanged;
	public event Action Jumping;

	public float Direction;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_startPosition = transform.position;
	}

	private void FixedUpdate()
	{
		Direction = _userInput.HorizontalAxisValue;

		if (Direction != 0)
		{
			_mover.ChangeSpeed(Direction);

			ChangeDirection();
		}

		if (_userInput.IsJump && _groundChecker.IsGrounded)
		{
			_mover.StartJump();

			Jumping?.Invoke();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<DangerZone>(out _))
			ResetPosition();
	}

	private void ResetPosition()
	{
		_rigidbody.velocity = Vector2.zero;
		transform.position = _startPosition;
	}

	private void ChangeDirection()
	{
		if (Direction > 0 && _currentDirection < 0)
		{
			_currentDirection = Direction;

			DirectionChanged?.Invoke();
		}

		if (Direction < 0f && _currentDirection > 0)
		{
			_currentDirection = Direction;

			DirectionChanged?.Invoke();
		}
	}
}
