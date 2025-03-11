using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Color randomSelectedColor = GetRandomColor();
        GetComponent<Renderer>().material.color = randomSelectedColor;
    }

    private Color GetRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
    }
}
