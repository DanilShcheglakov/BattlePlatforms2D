using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject _prefab;
	[SerializeField] private List<Transform> _spawnPositions;

	private void Awake()
	{
		FillTransformPositions();

		foreach (var spawnPoint in _spawnPositions)
			Instantiate(_prefab, spawnPoint);
	}

#if UNITY_EDITOR
	[ContextMenu("Refresh Spawn Points")]
	private void FillTransformPositions()
	{
		int pointCount = transform.childCount;
		_spawnPositions = new List<Transform>();

		for (int i = 0; i < pointCount; i++)
			_spawnPositions.Add(transform.GetChild(i));
	}
#endif
}