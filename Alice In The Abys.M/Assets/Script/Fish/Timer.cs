using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float time;
    public float TimerInterval = 15f;
    float tick;
    public GameObject PanelEnd;
   
    IEnumerator WaitOneFrame(float t) 
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Indice3");
    }

     IEnumerator WaitOneFrame2(float t) 
    {
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene("Lake");
    }

    void Awake() 
    {
        time = 0;
        tick = TimerInterval;
    }

    void Update()
    {
        GetComponent<Text>().text = "Time: " + string.Format("{0:0}:{1:00}",Mathf.Floor(time/60),time%60);
        time += Time.deltaTime;
        if(time >= 15f)
        {
            if(GameControl.score == 50)
            {
                PanelEnd.SetActive(true);
                PanelEnd.GetComponentInChildren<Text>().text = "Bravo ! Tu obtiens l'indice";
                StartCoroutine(WaitOneFrame(2f));
            }
            else
            {
                PanelEnd.SetActive(true);
                PanelEnd.GetComponentInChildren<Text>().text = "Dommage tu as echoué";
                StartCoroutine(WaitOneFrame2(2f));
            }
        }
    }
}
