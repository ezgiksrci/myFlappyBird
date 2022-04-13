using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position = transform.position + new Vector3(-Time.deltaTime/2, 0, 0);
    }
}
