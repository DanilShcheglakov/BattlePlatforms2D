using UnityEngine;

public class AidKit : MonoBehaviour
{
	[field: SerializeField] public int HealPoints { get; private set; }

	public void Destroy()
	{
		Destroy(gameObject);
	}
}
