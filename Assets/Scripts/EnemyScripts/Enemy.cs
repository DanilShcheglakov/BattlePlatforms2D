using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
	[SerializeField] private EnemyAnimationSettings _animationManager;
	private EnemyMover _mover;

	private void Awake()
	{
		_mover = GetComponent<EnemyMover>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent<Border>(out _))
			ChangeDirection();
	}

	private void ChangeDirection()
	{
		_mover.ChangeDirecton();
		_animationManager.ChangeDirection();
	}
}
