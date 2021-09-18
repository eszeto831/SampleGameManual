using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;

public class GenericPage : MonoBehaviour
{
    public GameObject Container;
	public TextMeshProUGUI Title;
	public TextMeshProUGUI Text;
	public Button FlipBt;
    public Button SpinBt;
    public Button ExplodeBt;
    public AudioSource ExplosionSFX;

    private float m_waitBeforeDestroyTime = 2f;
    private Action m_onNextPage;


    void Start()
	{
        FlipBt.onClick.AddListener(NextPageSlide);
        SpinBt.onClick.AddListener(NextPageSpin);
        ExplodeBt.onClick.AddListener(NextPageExplode);
    }

	virtual public void Init(DataPage data, Action onNextPage)
	{
		Title.text = data.Title;
		Text.text = data.Text;
        m_onNextPage = onNextPage;

    }

    public void ShowPage()
    {
        this.transform.localPosition = new Vector3(1000f, 0f, 0f);
        this.gameObject.SetActive(true);
        this.transform.DOLocalMoveX(0f, 0.5f).SetEase(Ease.OutBack);
    }

    public void NextPageSlide()
    {
        StartCoroutine(NextPageSlideAnim());
    }

    private IEnumerator NextPageSlideAnim()
    {
        this.transform.DOLocalMoveX(-1000f, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.3f);
        NextPage();
    }

    public void NextPageSpin()
    {
        StartCoroutine(NextPageSpinAnim());
    }

    private IEnumerator NextPageSpinAnim()
    { 
        this.transform.DOLocalMoveX(-1000f, 2.5f).SetEase(Ease.OutBack);
        this.transform.DOLocalMoveY(-1000f, 2.5f).SetEase(Ease.OutCirc);
        Container.transform.DOLocalRotate(new Vector3(0f, 0f, 10f), 0.01f).SetLoops(-1, LoopType.Incremental).SetRelative().SetEase(Ease.Linear);
        yield return new WaitForSeconds(0.3f);
        NextPage();
    }

    public void NextPageExplode()
    {
        StartCoroutine(NextPageExplodeAnim());
    }

    private IEnumerator NextPageExplodeAnim()
    {
        Container.SetActive(false);
        var explosion = GameObject.Instantiate(Resources.Load("VFX/Explosion")) as GameObject;
        explosion.transform.localPosition = Vector3.zero;
        ExplosionSFX.Play();
        yield return new WaitForSeconds(0.3f);
        NextPage();
    }

    public void NextPage()
    {
        if (m_onNextPage != null)
        {
            m_onNextPage();
        }

        StartCoroutine(WaitAndDestroy(m_waitBeforeDestroyTime));
    }

    private IEnumerator WaitAndDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject.Destroy(this.gameObject);
    }
}