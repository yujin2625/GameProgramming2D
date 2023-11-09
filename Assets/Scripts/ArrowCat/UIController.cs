using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public TMP_Text hpText;
    public Image hpGauge;
    public GameObject gameOver;

    void Start()
    {
        hpText.text = "HP : 10";
    }

    // Update is called once per frame
    void Update()
    {
        hpGauge.fillAmount = (float)PlayerState.hp / PlayerState.maxHP;
        hpText.text = "HP : " + PlayerState.hp;
        if (PlayerState.hp <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
