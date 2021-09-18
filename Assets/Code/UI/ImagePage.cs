using System;
using UnityEngine.UI;

public class ImageDialog : GenericPage
{
	public Image Image;
    
	public void Init(string title, string text, string image, Action onNextPage)
	{
        base.Init(title, text, onNextPage);
	}

	public void Close()
	{
	}
}