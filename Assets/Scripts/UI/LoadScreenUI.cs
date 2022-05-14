using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadScreenUI : MonoBehaviour
{
    [SerializeField] private float fillTime = 1;
    [SerializeField] private Image barBack;
    [SerializeField] private Image barFill;
    public static LoadScreenUI Instance;
    LoadScreenUI()
    {
        Instance = this;
    }
    public void StartShow(Action doAfter)
    {
        gameObject.SetActive(true);
        StartCoroutine(C_Fill(doAfter));
    }
    public void SetBarSprite(Sprite sprite)
    {
        barBack.sprite = sprite;
        barFill.sprite = sprite;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    IEnumerator C_Fill(Action doAfter)
    {
        // fill
        float status = 0;
        barFill.fillAmount = status;
        while (status < 1)
        {
            yield return null;
            status += Time.deltaTime / fillTime;
            barFill.fillAmount = status;
        }
        // do after
        doAfter.Invoke();
    }
}
