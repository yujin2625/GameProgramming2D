using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CatUIController: MonoBehaviour
{
    public TMP_Text timerText;
    float time = 0;
    string s_time;
    private void Awake()
    {
        GameObject[] canvas = GameObject.FindGameObjectsWithTag("Canvas");
        if (canvas.Length > 1)
        {
            Destroy(canvas[0]);
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        s_time = time.ToString();
        timerText.text = "Time : " + s_time.Substring(0, s_time.Length > 5 ? 5 : s_time.Length);
    }
    public void GameOver()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("CatJumpGameOver");
    }


}
