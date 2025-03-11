using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalFlip : MonoBehaviour
{
    //esse foi o que o prof passou
    [SerializeField] private float _inclinationSpeed = 5f;

    //fiz outro para o eixo X
    [SerializeField] private float _inclinationOtherSpeed = -5f;

    void Start()
    {
       
    }

    void Update()
    {
        float horizontal = -Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, horizontal * Time.deltaTime * _inclinationSpeed);

        //.right para que ele mexa para frente e trás
        float vertical = -Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right, vertical * Time.deltaTime * _inclinationOtherSpeed);
    }
}
