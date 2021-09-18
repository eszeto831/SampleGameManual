using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class GenericPage : MonoBehaviour
{
	public TextMeshProUGUI Title;
	public TextMeshProUGUI Text;
	public Button FlipBt;
    public Button SpinBt;
    public Button ExplodeBt;

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
        this.transform.DOLocalMoveX(0f, 0.5f).SetEase(Ease.OutBack);
    }

    public void NextPage()
	{
	}
}