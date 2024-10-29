using UnityEngine;

public class UserInut : MonoBehaviour
{
	private const string Horizontal = nameof(Horizontal);

	public float HorizontalAxisValue { get; private set; }
	public bool IsSpaceDown { get; private set; }

	private KeyCode _jump = KeyCode.Space;

	private void Update()
	{
		HorizontalAxisValue = ReadHorizontal();
		IsSpaceDown = CheckSpaceDon();
	}

	private float ReadHorizontal()
	{
		return Input.GetAxis(Horizontal);
	}

	private bool CheckSpaceDon()
	{
		return Input.GetKeyDown(_jump);
	}
}
