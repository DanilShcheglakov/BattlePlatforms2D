using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
	[SerializeField] private float _enemySpeed;
	[SerializeField] private Enemy _enemy;

	private Player _target;
	private Rigidbody2D _rigidBody;

	private bool _isBorderFaced;

	public event Action DirectionChanged;

	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	private void OnEnable()
	{
		_enemy.BorderFaced += WriteBorderCollision;
	}

	private void OnDisable()
	{
		_enemy.BorderFaced -= WriteBorderCollision;
	}

	private void FixedUpdate()
	{
		if (_target != null)
			Follow();
		else
			Move();
	}

	public void SetTarget(Player target)
	{
		_target = target;
	}

	public void ChangeDirecton()
	{
		_enemySpeed *= -1;
		DirectionChanged?.Invoke();
	}

	private void WriteBorderCollision()
	{
		_isBorderFaced = true;
	}

	private void Move()
	{
		if (_isBorderFaced)
		{
			ChangeDirecton();
			_isBorderFaced = false;
		}

		_rigidBody.velocity = new Vector2(_enemySpeed * Time.fixedDeltaTime, _rigidBody.velocity.y);
	}

	private void Follow()
	{
		float direction = transform.position.x - _target.transform.position.x;

		Vector2 vector = new Vector2(direction, _rigidBody.velocity.y).normalized * _enemySpeed * Time.fixedDeltaTime;

		if (_isBorderFaced == false)
			_rigidBody.velocity = vector;
	}
}
