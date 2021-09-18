using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Camera MainCamera;

    void Start ()
    {
        Application.runInBackground = true;
        GameConfig.Instance.ParseConfig();
        SceneManager.LoadScene("PageScene");
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
