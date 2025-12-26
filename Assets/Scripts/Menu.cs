using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button loadSceneButton;
    [SerializeField] private CanvasGroup fadePanel;
    [SerializeField] private float fadeTime = 1f;
    [SerializeField] string sceneName = "Game";

    bool isFading = false;

    

    void Start()
    {
        loadSceneButton.onClick.AddListener(LoadScene);
    }


    void LoadScene()
    {
        if (isFading) return;
        loadSceneButton.interactable = false;
        isFading = true;
        StartCoroutine(fadeCour(sceneName)); 
    }


    IEnumerator fadeCour(string sceneName)
    {
        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timer / fadeTime);
            fadePanel.alpha = alpha;
            yield return null;

        }

        fadePanel.alpha = 1;
        SceneManager.LoadScene(sceneName);
    }
}