using UnityEngine;

public abstract class CollectableThing : MonoBehaviour
{
	public void Destroy()
	{
		Destroy(gameObject);
	}
}
