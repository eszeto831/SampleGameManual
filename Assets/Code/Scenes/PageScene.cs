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
        VersionNumber.text = "v "+ "??";

    }
}
