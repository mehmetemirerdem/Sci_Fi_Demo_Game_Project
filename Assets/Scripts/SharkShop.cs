using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Player_sc player_sc = other.GetComponent<Player_sc>();
                if(player_sc == null)
                {
                    Debug.LogError("Player is NULL");
                }
                else
                {
                    if (player_sc.hasCoin == true)
                    {
                        player_sc.hasCoin = false;
                        UIManager_sc uiManager_sc = GameObject.Find("Canvas").GetComponent<UIManager_sc>();
                        if(uiManager_sc == null)
                        {
                            Debug.LogError("UI Manager is NULL");
                        }
                        else
                        {
                            uiManager_sc.RemoveCoin();
                        }
                        AudioSource audio = GetComponent<AudioSource>();
                        if (audio == null)
                        {
                            Debug.LogError("Audio Source is NULL");
                        }
                        else
                        {
                            player_sc.EnableWeapon();
                            audio.Play();
                        }
                    }
                    else
                    {
                        Debug.Log("Get out of here!");
                    }
                }
            }
        }
    }

}
