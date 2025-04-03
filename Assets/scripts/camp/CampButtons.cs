using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampButtons : MonoBehaviour
{
    public void goToSiege()
    {
        SceneManager.LoadScene("siege_map");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("menu scene");
    }
}
