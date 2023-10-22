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
        distanceText.text = "��ǥ �������� " + distance + "m";
    }
    public void PastTextSet(int i, float distance)
    {
        pastStr += "[" + i + "��° �õ�] �Ÿ� = " + distance + "m\n";
        pastText.text = pastStr;
    }
    public void OnClickReset()
    {
        carController.RestartGame();
    }
    
}
