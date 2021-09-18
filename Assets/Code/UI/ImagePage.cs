using System;
using UnityEngine;
using UnityEngine.UI;

public class ImagePage : GenericPage
{
	public Image Image;

    override public void Init(DataPage data, Action onNextPage)
	{
        base.Init(data, onNextPage);
        Image.sprite = Resources.Load<Sprite>(data.Image);

    }
}