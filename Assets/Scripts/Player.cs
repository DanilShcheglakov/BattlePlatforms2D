using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	[SerializeField] private Mover _mover;
	[SerializeField] private UserInput _userInput;
	[SerializeField] private GroundChecker _groundChecker;
	[SerializeField] private Attack _attack;
	[SerializeField] private Health _health;
	[SerializeField] private Vampirism _vampirism;

	private Rigidbody2D _rigidbody;
	private Vector2 _startPosition;

	private float _currentDirection = 1f;

	public event Action DirectionChanged;
	public event Action Jumping;

	public float Direction { get; private set; }

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_startPosition = transform.position;
	}

	private void OnEnable()
	{
		_health.Die += Die;
	}

	private void OnDisable()
	{
		_health.Die -= Die;
	}

	private void Update()
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

		if (_userInput.IsAttack)
			_attack.GiveDamage();

		if (_userInput.IsVampirism)
			_vampirism.StartAbility();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<DangerZone>(out _))
			ResetPosition();
		else if (collision.gameObject.TryGetComponent(out EnemyAttak enemyAttak))
			enemyAttak.Hitting += GetDamage;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out EnemyAttak enemyAttak))
			enemyAttak.Hitting -= GetDamage;
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

	private void GetDamage(int damage)
	{
		_health.TakeDamage(damage);
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
