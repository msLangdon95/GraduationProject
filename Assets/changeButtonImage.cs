using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeButtonImage : MonoBehaviour {
	public Sprite OtherSprite;
	public GameObject originalImage;
	Image[] images;

	public void swapImage()
	{
		images = originalImage.gameObject.GetComponentsInChildren<Image>();
		foreach (Image image in images)
		{
			image.sprite = OtherSprite;
		}
	}

}
