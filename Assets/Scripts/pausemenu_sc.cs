using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu_sc : MonoBehaviour
{
    public GameObject canvas;

    public bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (flag)
            {
                Resume();
            }
            else
            {
                canvas.SetActive(true);
                Time.timeScale = 0f;
                flag = true;
            }
        }
    }

    public void Resume()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        flag = false;
    }

    public void Restart()
    {
        //restart in the same scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Application.LoadLevel(1);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
