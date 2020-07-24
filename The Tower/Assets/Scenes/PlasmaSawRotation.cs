using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaSawRotation : MonoBehaviour
{
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0f, 0f, rotationSpeed, Space.Self);
    }
}
