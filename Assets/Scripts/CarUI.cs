using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarUI : MonoBehaviour
{
    public TMPro.TMP_Text distanceText;
    public TMP_Text pastText;
    public string pastStr;
    public GameObject flag;
    public CarController carController;
    private void Start()
    {
        flag = GameObject.Find("flag");
        carController = GameObject.Find("car").GetComponent<CarController>();
    }
    public void DisTextSet(float distance)
    {
        distanceText.text = "목표 지점까지 " + distance + "m";
    }
    public void PastTextSet(int i, float distance)
    {
        pastStr += "[" + i + "번째 시도] 거리 = " + distance + "m\n";
        pastText.text = pastStr;
    }
    public void OnClickReset()
    {
        carController.RestartGame();
    }
    
}
