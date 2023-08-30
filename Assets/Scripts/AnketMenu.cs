using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AnketMenu : MonoBehaviour
{
    public void OncekiMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void CikisMenu()
    {
        Application.Quit();
        print("Anket menüden çýkýldý");
    }
    public void BitirmeMenu()
    {

    }
}
