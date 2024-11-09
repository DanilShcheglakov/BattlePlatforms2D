using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public class PlayerAnimationSettings : MonoBehaviour
{
	private const string Speed = nameof(Speed);
	private const string IsGrounded = nameof(IsGrounded);
	private const string Jump = nameof(Jump);

	[SerializeField] private GroundChecker _groundChecker;
	[SerializeField] private Player _player;

	private Transform _transform;
	private Animator _animator;

	private void Awake()
	{
		_animator = GetComponent<Animator>();
		_transform = GetComponent<Transform>();
	}

	private void OnEnable()
	{
		_player.DirectionChanged += InvertDirection;
		_player.Jumping += StartJump;

		_groundChecker.ConditionsChanged += SetAnimationCondidtionIsGrounded;
	}

	private void OnDisable()
	{
		_player.DirectionChanged -= InvertDirection;
		_player.Jumping -= StartJump;

		_groundChecker.ConditionsChanged -= SetAnimationCondidtionIsGrounded;
	}

	private void Update()
	{
		_animator.SetFloat(Speed, Mathf.Abs(_player.Direction));
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
