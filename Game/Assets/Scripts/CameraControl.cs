using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0F;
    [SerializeField]
    private Transform target;
    private void Awake()
    {
        if (!target) target = FindObjectOfType<Player>().transform ; 
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position - new Vector3(0,0,10.0F), speed *Time.deltaTime  );
    }
}
