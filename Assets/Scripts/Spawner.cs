using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private GameObject _prefab;
	[SerializeField] private Transform _spawnPosition;

	private List<Transform> _spawnPositions = new List<Transform>();
	private int _currentPositionIndex = 1;

	private void Awake()
	{
		FillTransformPositions();

		while (TryGetSpawnPoint(out Transform spawnPoint))
			Instantiate(_prefab, spawnPoint);
	}

	private bool TryGetSpawnPoint(out Transform spawnPoint)
	{
		spawnPoint = null;

		if (_currentPositionIndex == _spawnPositions.Count)
			return false;

		spawnPoint = _spawnPositions[_currentPositionIndex];
		_currentPositionIndex++;
		return true;
	}

	private void FillTransformPositions()
	{
		foreach (Transform spawnPoint in _spawnPosition.GetComponentsInChildren<Transform>())
			_spawnPositions.Add(spawnPoint);
	}
}