using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AnaMenu : MonoBehaviour
{
    public Image resim1, resim2, infoImage;
    bool calistiMi;
    bool infoTikladiMi;
    public Button but1,but3,but1Sahte, but3Sahte;
    
   
    

    int deger;
    private void Start()
    {
        resim1.gameObject.SetActive(false);
        resim2.gameObject.SetActive(false);
        deger = 0;
        infoImage.gameObject.SetActive(false);

        but1Sahte.gameObject.SetActive(false);
        but3Sahte.gameObject.SetActive(false);
        but1.gameObject.SetActive(true);
        but3.gameObject.SetActive(true);

    }
    private void Update()
    {
        if (calistiMi == true)
        {
            StartCoroutine(AnimasyonCoroutine());
        }
        if (deger == 0)
        {
            StartCoroutine(AnimasyonCoroutine());
            deger++;
        }

        if (infoTikladiMi)
        {
            but1Sahte.gameObject.SetActive(true);
            but3Sahte.gameObject.SetActive(true);
            but1.gameObject.SetActive(false);
            but3.gameObject.SetActive(false);
        }
        else
        {
            but1Sahte.gameObject.SetActive(false);
            but3Sahte.gameObject.SetActive(false);
            but1.gameObject.SetActive(true);
            but3.gameObject.SetActive(true);
        }
        
    }




    public void Cikis()
    {
        if (infoTikladiMi == false)
        {
            Application.Quit();
            print("Çýktý");
        }
        
    }

    public void AnketMenu()
    {
        
        if (infoTikladiMi == false)
        {
            SceneManager.LoadScene(1);

        }
    }

    public void InfoImageFunc()
    {
        if (infoTikladiMi == false)
        {
            infoImage.gameObject.SetActive(true);
            infoTikladiMi = true;
        }
        else
        {
            infoImage.gameObject.SetActive(false);
            infoTikladiMi=false;

        }
           
    }

    IEnumerator AnimasyonCoroutine()
    {
        calistiMi = false;
        yield return new WaitForSeconds(0.7f);
        resim1.gameObject.SetActive(true);
        resim2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        resim1.gameObject.SetActive(false);
        resim2.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        calistiMi = true;
    }

   
        
}
