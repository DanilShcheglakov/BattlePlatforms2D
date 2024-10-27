using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
	private const string Speed = nameof(Speed);
	private const string IsGrounded = nameof(IsGrounded);
	private const string Jump = nameof(Jump);

	[SerializeField] private GroundChecker _groundChecker;
	[SerializeField] private Mover _mover;

	private Transform _transform;
	private Animator _animator;

	private bool _isGrounded = false;

	private void OnEnable()
	{
		_mover.ChangedDirection += InvertDirection;
		_mover.Jumping += StartJump;

		_groundChecker.Grounded += TouchDown;
		_groundChecker.Fly += Fly;
	}

	private void OnDisable()
	{
		_mover.ChangedDirection -= InvertDirection;
		_mover.Jumping -= StartJump;

		_groundChecker.Grounded -= TouchDown;
		_groundChecker.Fly -= Fly;
	}

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_transform = GetComponent<Transform>();
	}

	private void Update()
	{
		_animator.SetFloat(Speed, math.abs(_mover.Direction));
	}

	private void InvertDirection()
	{
		float tiltAngle = 180;
		Vector3 rotate = new Vector3(0, tiltAngle);

		_transform.Rotate(rotate);
	}

	private void TouchDown()
	{
		_isGrounded = true;

		_animator.SetBool(IsGrounded, _isGrounded);
	}

	private void Fly()
	{
		_isGrounded = false;

		_animator.SetBool(IsGrounded, _isGrounded);
	}

	private void StartJump()
	{
		_animator.SetTrigger(Jump);
	}
}
