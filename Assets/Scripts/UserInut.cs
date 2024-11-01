using UnityEngine;

public class UserInut : MonoBehaviour
{
	private const string Horizontal = nameof(Horizontal);

	public float HorizontalAxisValue { get; private set; }
	private bool _isSpaceDown;

	private KeyCode _jump = KeyCode.Space;

	public bool IsJump => GetBoolAsTrigger(ref _isSpaceDown);

	private void Update()
	{
		HorizontalAxisValue = ReadHorizontal();
		_isSpaceDown = CheckSpaceDown();
	}

	private float ReadHorizontal()
	{
		return Input.GetAxis(Horizontal);
	}

	private bool CheckSpaceDown()
	{
		return Input.GetKeyDown(_jump);
	}

	private bool GetBoolAsTrigger(ref bool value)
	{
		bool localValue = value;
		value = false;
		return localValue;
	}
}
