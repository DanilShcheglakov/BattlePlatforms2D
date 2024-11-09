using UnityEngine;

public class UserInput : MonoBehaviour
{
	private const string Horizontal = nameof(Horizontal);

	private bool _isSpaceDown;
	private bool _isAttakButtonDown;

	private KeyCode _jump = KeyCode.Space;
	private KeyCode _attack = KeyCode.F;

	public bool IsJump => GetBoolAsTrigger(ref _isSpaceDown);
	public bool IsAttack => GetBoolAsTrigger(ref _isAttakButtonDown);

	public float HorizontalAxisValue { get; private set; }

	private void Update()
	{
		HorizontalAxisValue = ReadHorizontal();
		_isSpaceDown = IsSpaceDown();
		_isAttakButtonDown = IsAttackDown();
	}

	private float ReadHorizontal()
	{
		return Input.GetAxis(Horizontal);
	}

	private bool IsSpaceDown()
	{
		return Input.GetKeyDown(_jump);
	}

	private bool IsAttackDown()
	{
		return Input.GetKeyDown(_attack);
	}

	private bool GetBoolAsTrigger(ref bool value)
	{
		bool localValue = value;
		value = false;
		return localValue;
	}
}
