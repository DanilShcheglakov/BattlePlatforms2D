using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
	[SerializeField] private float _enemySpeed;

	private Rigidbody2D _rigidBody;

	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		ChangeSpeed();
	}

	public void ChangeDirecton()
	{
		_enemySpeed *= -1;
	}

	private void ChangeSpeed()
	{
		_rigidBody.velocity = new Vector2(_enemySpeed * Time.fixedDeltaTime, _rigidBody.velocity.y);
	}
}
