using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager_sc : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text ammoText;

    [SerializeField]
    private GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAmmo(int count)
    {
        ammoText.text = "Ammo: " + count;
    }

    public void CollectedCoin()
    {
        coin.SetActive(true);
    }

    public void RemoveCoin()
    {
        coin.SetActive(false);
    }
}
