using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public Camera MainCamera;

    void Start ()
    {
        Application.runInBackground = true;
        SceneManager.LoadScene("PageScene");
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
