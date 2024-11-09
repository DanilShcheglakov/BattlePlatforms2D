using UnityEngine;

public class UserInput : MonoBehaviour
{
	private const string Horizontal = nameof(Horizontal);

	public float HorizontalAxisValue { get; private set; }
	private bool _isSpaceDown;
	private bool _isAttakButtonDown;

	private KeyCode _jump = KeyCode.Space;
	private KeyCode _attack = KeyCode.F;

	public bool IsJump => GetBoolAsTrigger(ref _isSpaceDown);
	public bool IsAttack => GetBoolAsTrigger(ref _isAttakButtonDown);

	private void Update()
	{
		HorizontalAxisValue = ReadHorizontal();
		_isSpaceDown = CheckSpaceDown();
		_isAttakButtonDown = CheckAttackDown();
	}

	private float ReadHorizontal()
	{
		return Input.GetAxis(Horizontal);
	}

	private bool CheckSpaceDown()
	{
		return Input.GetKeyDown(_jump);
	}

	private bool CheckAttackDown()
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
