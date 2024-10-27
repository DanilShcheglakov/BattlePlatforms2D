using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	[SerializeField] DangerZone _dangerZone;

	private Rigidbody2D _rigidbody;
	private Vector2 _startPosition;

	private void OnEnable()
	{
		_dangerZone.Entered += ResetPosition;
	}

	private void OnDisable()
	{
		_dangerZone.Entered -= ResetPosition;
	}

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_startPosition = transform.position;
	}

	private void ResetPosition()
	{
		_rigidbody.velocity = Vector2.zero;
		transform.position = _startPosition; 
	}
}
