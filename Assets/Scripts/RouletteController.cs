using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class RouletteController : MonoBehaviour
{
    bool rotate = false;
    bool onResult = true;
    float rotSpeed = 0;
    [SerializeField]
    public List<string> rltList = new();
    [SerializeField]
    public bool needRotFix = false;
    public float rotationFix=0;
    public GameObject linePref;
    public GameObject textPref;
    private void Start()
    {
        DrawLine();
        DrawText();
    }
    private void Update()
    {
        transform.Rotate(0, 0, this.rotSpeed);
        if (!rotate)
        {
            rotSpeed *= 0.99f;
        }
        if (rotSpeed < 0.01 && rotate == false)
        {
            rotSpeed = 0;
        }
        if (rotSpeed == 0 && onResult == false)
        {
            onResult = true;
            Debug.Log(rltList[FindResult()]);
        }
    }
    void DrawLine()
    {
        float stAngle = 360 / rltList.Count;
        float fixLine = 360 / rltList.Count / 2;
        for (int i = 0; i < rltList.Count/2; i++)
        {
            GameObject rouletteLine = Instantiate(linePref, transform.position, Quaternion.Euler(0, 0, stAngle*i+fixLine),this.transform);
        }
    }
    void DrawText()
    {
        float stAngle = 360 / rltList.Count;
        for (int i = 0; i < rltList.Count; i++)
        {
            GameObject rouletteText =Instantiate(textPref,transform);
            rouletteText.transform.rotation = Quaternion.Euler(0, 0, -stAngle * i);
            rouletteText.GetComponentInChildren<TMP_Text>().text = rltList[i];
        }
    }
    void OnRotate(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
            rotate = true;
            rotSpeed = 10;
        }
        if (!inputValue.isPressed)
        {
            rotate = false;
            onResult = false;
        }
    }
    int FindResult()
    {
        if (needRotFix == true)
        {
            rotationFix = 360 / rltList.Count / 2;
        }
        else
        {
            rotationFix = 0;
        }
        float angle = transform.rotation.eulerAngles.z + rotationFix;
        if (angle < 0)
        {
            angle += 360;
        }
        float stAngle = 360 / rltList.Count;
        for (int i = 0; i < rltList.Count; i++)
        {
            if (angle > stAngle * i && angle < stAngle * (i + 1))
            {
                return i;
            }
        }
        return 0;
    }

}
