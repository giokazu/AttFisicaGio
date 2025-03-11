using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        { 
            Color randomSelectedColorWithAlpha = GetRandomColorWithAlpha();
        GetComponent<Renderer>().material.color = randomSelectedColorWithAlpha;
        }
    }

    private Color GetRandomColorWithAlpha()
    {
        return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 0.25f));
    }


}
