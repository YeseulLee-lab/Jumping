using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WWWGameManager : MonoBehaviour
{
    public static WWWGameManager instance;
    [SerializeField] Button StartButton;
    [SerializeField] Button ReStartButton;
    [SerializeField] TMP_Text countTxt;
    [SerializeField] JumperPlayer _own;
    private Coroutine countCor = null;
    private float current = 3;
    private float target = 0;
   
    private void OnEnable()
    {
        countTxt.text = "3";
        current = 3;
        target = 0;
    }

    //UnityEngine.SceneManagement.SceneManager.LoadScene (gameObject.scene.name);
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        StartButton.onClick.AddListener(StartGame);
        ReStartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene (gameObject.scene.name);
    }
    private void StartGame()
    {
        if(countCor != null)
        {
            StopCoroutine(countCor);
            countCor = null;
        }

        StartButton.gameObject.SetActive(false);
        countCor = StartCoroutine(StartCountCor());
    }

    IEnumerator StartCountCor()
    {
        float duration = 1.0f; // 카운팅에 걸리는 시간 설정. 

        float offset = (target - current) / duration;

        while (current > 0)
        {

            current -= Time.deltaTime;
            Debug.Log("current = " + Time.deltaTime);
            countTxt.text = ((int)current).ToString();

            yield return null;

        }

        current = target;

        this.gameObject.SetActive(false);
        countTxt.text = ((int)current).ToString();
        countTxt.gameObject.SetActive(false);
        _own.SetGravity();
    }

    public void ShowRestartGame()
    {
        this.gameObject.SetActive(true);
        ReStartButton.gameObject.SetActive(true);
    }
   
}
