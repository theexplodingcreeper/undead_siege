using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startbuttton()
    {
        SceneManager.LoadScene("camp");
    }

    public void exitbutton()
    {
        Application.Quit();
    }

    public void credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void menu()
    {
        SceneManager.LoadScene("menu scene");
    }

}

