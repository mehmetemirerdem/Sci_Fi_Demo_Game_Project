using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    [SerializeField]
    private float sensitivity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<pausemenu_sc>().flag)
        {
            float mouseX = Input.GetAxis("Mouse X");
            Vector3 newRotation = transform.localEulerAngles;
            newRotation.y += mouseX * sensitivity;
            transform.localEulerAngles = newRotation;
        }
        
    }
}
