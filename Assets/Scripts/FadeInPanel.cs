using System.Collections;
using UnityEngine;

public class FadeInPanel : MonoBehaviour
{
    
    [SerializeField] private float fadeTime = 1f;

    private CanvasGroup fadePanel;

    void Start()
    {
        fadePanel = GetComponent<CanvasGroup>();
        fadePanel.alpha = 1;
        StartCoroutine(FadeCourutine());
    }


    IEnumerator FadeCourutine()
    {
        float timer = 0f;

        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, timer / fadeTime);
            fadePanel.alpha = alpha;
            yield return null;
        }

        fadePanel.alpha = 0;
        fadePanel.gameObject.SetActive(false);
    }
}
