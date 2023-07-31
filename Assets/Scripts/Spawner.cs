using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;

    [SerializeField] bool _spawnInTime = true;
    float _timeSpent;

	private void FixedUpdate()
	{
		if (GameManager.Single.GameActive)
		{
			if (_spawnInTime)
			{
				_timeSpent += Time.deltaTime;
				if (_timeSpent > GameManager.Single.Interval)
				{
					_timeSpent = 0;

					Spawn();
				}
			}
		}
	}

	private void Spawn()
	{
		var newGO = Instantiate(prefabs[Random.Range(0, prefabs.Length)], SetPosition(), Quaternion.identity);
		newGO.transform.SetParent(transform, true);
	}

	private Vector3 SetPosition()
	{
		return new Vector3(Random.Range(-GameManager.Single.RightUpperCorner.x + 1, GameManager.Single.RightUpperCorner.x - 1), -GameManager.Single.RightUpperCorner.y - 1, 0);
	}
}
