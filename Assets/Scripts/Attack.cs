using System;
using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
	[SerializeField] private int _damage;
	[SerializeField] private float _rechargeTime;
	private bool _isEnemyInAttackArea;
	private bool _isRecharged = true;

	WaitForSeconds _delay;

	public event Action<int> Hitting;

	private void Awake()
	{
		_delay = new WaitForSeconds(_rechargeTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Enemy enemy))
			_isEnemyInAttackArea = true;
	}

	public void GiveDamage()
	{
		if (_isEnemyInAttackArea && _isRecharged)
		{
			Hitting?.Invoke(_damage);

			_isRecharged = false;

			Debug.Log("Attack");

			StartCoroutine(Recharge());
			StopCoroutine(Recharge());
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Enemy enemy))
			_isEnemyInAttackArea = false;
	}

	private IEnumerator Recharge()
	{
		yield return _delay;

		_isRecharged = true;
	}
}
