using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehave : MonoBehaviour
{
    public float speed = 1f;
    private Vector3 _targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        _targetPosition = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
