using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	private Rigidbody2D _rigidbody;
	private Vector2 _startPosition;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_startPosition = transform.position;
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
}
