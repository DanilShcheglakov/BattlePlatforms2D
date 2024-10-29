using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerAnimationSettings : MonoBehaviour
{
	private const string Speed = nameof(Speed);
	private const string IsGrounded = nameof(IsGrounded);
	private const string Jump = nameof(Jump);

	[SerializeField] private GroundChecker _groundChecker;
	[SerializeField] private Mover _mover;

	private Transform _transform;
	private Animator _animator;

	private void OnEnable()
	{
		_mover.DirectionChanged += InvertDirection;
		_mover.Jumping += StartJump;

		_groundChecker.ConditionsChanged += SetAnimationCondidtionIsGrounded;
	}

	private void OnDisable()
	{
		_mover.DirectionChanged -= InvertDirection;
		_mover.Jumping -= StartJump;

		_groundChecker.ConditionsChanged -= SetAnimationCondidtionIsGrounded;
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

	private void SetAnimationCondidtionIsGrounded()
	{
		_animator.SetBool(IsGrounded, _groundChecker.IsGrounded);
	}

	private void StartJump()
	{
		_animator.SetTrigger(Jump);
	}
}
