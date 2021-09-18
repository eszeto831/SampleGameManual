using UnityEngine.UI;

public class ImageDialog : GenericPage
{
	public Image Image;
    
	public void Init(string title, string text, string image)
	{
        base.Init(title, text);
	}

	public void Close()
	{
	}
}