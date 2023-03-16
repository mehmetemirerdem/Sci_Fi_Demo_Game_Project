using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_sc : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinPickup;

    public Player_sc player_sc;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Player_sc player_sc = other.GetComponent<Player_sc>();
            if (player_sc == null)
            {
                Debug.LogError("Player is null!");
            }
            else
            {
                player_sc.hasCoin = true;
                AudioSource.PlayClipAtPoint(coinPickup, transform.position, 1f);
                UIManager_sc uiManager_sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();
                if (uiManager_sc == null)
                {
                    Debug.LogError("UI Manager is NULL");
                }
                else
                {
                    uiManager_sc.CollectedCoin();
                }
                Destroy(this.gameObject);
            }
        }
    }
}
