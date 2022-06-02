using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader1 : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI progressText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("MarieChangeScene");

        while (!operation.isDone)
        {
            float progress = (Mathf.Clamp01(operation.progress / 0.9f));
            slider.value = progress;

            progressText.text = (int)(progress * 100) + "%";

            yield return null;
        }
    }
}
