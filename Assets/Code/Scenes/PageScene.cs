using UnityEngine;
using System.Collections;
using TMPro;

public class PageScene : MonoBehaviour
{
    public Transform PageContainer;
    public TextMeshProUGUI VersionNumber;

    void Start ()
	{
		Init();
	}

	public void Init()
	{
        AddPage();

        VersionNumber.text = "v "+ "??";
    }

    public void AddPage()
    {
        var prefabPath = "PageTextOnly";
        var pageResource = Resources.Load("Prefabs/" + prefabPath) as GameObject;
        var pageObj = GameObject.Instantiate(pageResource) as GameObject;
        pageObj.transform.SetParent(PageContainer.transform, false);
        pageObj.transform.localPosition = new Vector3(1000f, 0f, 0f);

        var page = pageObj.GetComponent<GenericPage>();

        page.ShowPage();
    }
}
