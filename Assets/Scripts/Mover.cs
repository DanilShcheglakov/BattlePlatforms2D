using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
	[SerializeField] private float _speed = 2f;
	[SerializeField] private float _jumpForce = 200f;

	private Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	public void ChangeSpeed(float direction)
	{
		_rigidbody.velocity = new Vector2(direction * _speed * Time.fixedDeltaTime, _rigidbody.velocity.y);
	}

	public void StartJump()
	{
		_rigidbody.AddForce(Vector2.up * _jumpForce);
	}
}
