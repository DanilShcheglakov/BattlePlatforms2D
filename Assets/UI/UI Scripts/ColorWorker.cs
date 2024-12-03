using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ColorWorker : MonoBehaviour
{
	private Image _image;

	private void Awake()
	{
		_image = GetComponent<Image>();
	}

	public void ChangeColor()
	{
		_image.color = new Color(Random.value, Random.value, Random.value);
	}
}
