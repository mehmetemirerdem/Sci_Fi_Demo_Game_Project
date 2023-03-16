using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible_sc : MonoBehaviour
{
    [SerializeField]
    private GameObject crateDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyCrate()
    {
        Instantiate(crateDestroyed, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
