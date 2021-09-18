using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class PageScene : MonoBehaviour
{
    public Transform PageContainer;
    public TextMeshProUGUI VersionNumber;

    private List<DataPage> m_pages;
    private int m_currentPage;

    void Start ()
	{
		Init();
	}

	public void Init()
	{
        m_pages = GameConfig.Instance.Pages;

        AddPage();

        VersionNumber.text = "v " + GameConfig.Instance.GameVersion;
    }

    public void AddPage()
    {
        var image = m_pages[m_currentPage].Image;

        var prefabPath = "PageTextOnly";
        if(!string.IsNullOrEmpty(image))
        {
            prefabPath = "PageWithImage";
        }
        var pageResource = Resources.Load("Prefabs/" + prefabPath) as GameObject;
        var pageObj = GameObject.Instantiate(pageResource) as GameObject;
        pageObj.transform.SetParent(PageContainer.transform, false);
        pageObj.SetActive(false);

        GenericPage page = null;
        page = pageObj.GetComponent<GenericPage>();
        page.Init(m_pages[m_currentPage], AddPage);
        /*
        if (string.IsNullOrEmpty(image))
        {
            page = pageObj.GetComponent<GenericPage>();
            page.Init(m_pages[m_currentPage], AddPage);
        }
        else
        {
            page = pageObj.GetComponent<ImagePage>();
            page.Init(m_pages[m_currentPage], AddPage);
        }
        */
        page.ShowPage();

        m_currentPage++;
        if(m_currentPage >= m_pages.Count)
        {
            m_currentPage = 0;
        }
    }
}
