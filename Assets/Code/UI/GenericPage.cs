using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GenericPage : MonoBehaviour
{
	public TextMeshProUGUI Title;
	public TextMeshProUGUI Text;
	public Button FlipBt;
    public Button SpinBt;
    public Button ExplodeBt;

    private float m_waitBeforeDestroyTime = 2f;
    
    void Start()
	{
        FlipBt.onClick.AddListener(NextPage);
        SpinBt.onClick.AddListener(NextPage);
        ExplodeBt.onClick.AddListener(NextPage);
    }

	public void Init(string title, string text)
	{
		Title.text = title;
		Text.text = text;
	}

    public void ShowPage()
    {
        this.transform.localPosition = new Vector3(1000f, 0f, 0f);
        this.gameObject.SetActive(true);
        this.transform.DOLocalMoveX(0f, 0.5f).SetEase(Ease.OutBack);
    }

    public void NextPage()
    {
        this.transform.DOLocalMoveX(-1000f, 0.5f).SetEase(Ease.OutBack);
        StartCoroutine(WaitAndDestroy(m_waitBeforeDestroyTime));
    }

    private IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}