using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour
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
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 newRotation = transform.localEulerAngles;
            newRotation.x += mouseY * sensitivity;
            transform.localEulerAngles = newRotation;
        }
        
    }
}
