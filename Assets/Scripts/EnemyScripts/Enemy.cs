using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private EnemyAnimationSettings _animationManager;
	[SerializeField] private EnemyMover _mover;
	[SerializeField] private Health _health;
	[SerializeField] private EnemyVision _vision;

	public event Action BorderFaced;
	public event Action Died;

	private void OnEnable()
	{
		_health.Die += Die;
		_mover.DirectionChanged += ChangeDirection;

		_vision.PlayerDetected += SetTarget;
		_vision.PlayerUnDetected += SetTarget;
	}

	private void OnDisable()
	{
		_health.Die -= Die;
		_mover.DirectionChanged -= ChangeDirection;

		_vision.PlayerDetected -= SetTarget;
		_vision.PlayerUnDetected -= SetTarget;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<Border>(out _))
			BorderFaced?.Invoke();

		if (collision.gameObject.TryGetComponent(out Attack playerAttack))
			playerAttack.Hitting += TakeDamage;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Attack playerAttack))
			playerAttack.Hitting -= TakeDamage;
	}

	public void TakeDamage(int damage)
	{
		_health.TakeDamage(damage);
	}

	private void ChangeDirection()
	{
		_animationManager.ChangeDirection();
	}

	private void Die()
	{
		Died?.Invoke();
	}

	private void SetTarget(Player target)
	{
		_mover.SetTarget(target);
	}

	private void SetTarget()
	{
		_mover.SetTarget(null);
	}
}
