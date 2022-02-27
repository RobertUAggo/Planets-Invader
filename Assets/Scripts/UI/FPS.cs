using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    private TextMeshProUGUI textField;
    //
    private int frames=0;

    void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
        StartCoroutine(Timer(1));
    }
    void Update()
    {
        frames++;
    }
    IEnumerator Timer(float time)
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSecondsRealtime(time);
            textField.text = frames.ToString();
            frames = 0;
        }
    }
}
