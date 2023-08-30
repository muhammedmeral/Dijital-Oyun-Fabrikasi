using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PuanYazdirma : MonoBehaviour
{
    public TextMeshProUGUI puan1, puan2, puan3, yPuan1, yPuan2, yPuan3, yBolge, yIsim;

    public Slider slider1, slider2, slider3;
    public TMP_InputField isimEkrani,sikayetEkrani;
    public TMP_Dropdown hizmetBolgesi;
    public Image _panel,saklama;
    public Toggle isaret;
    public Button sonButton;

   

    string isim,bolge,sikayet;
    float s1Val, s2Val, s3Val;

    bool bolgeGirdiMi,isaretGirdiMi;

    private void Start()
    {
        _panel.gameObject.SetActive(false);
        isaret.isOn=false;
        sikayetEkrani.gameObject.SetActive(false);
        saklama.gameObject.SetActive(false);
        sonButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        s1Val = slider1.value;
        s2Val = slider2.value;
        s3Val = slider3.value;
        isim = isimEkrani.text.ToUpper();
        sikayet = sikayetEkrani.text;
        

        if (hizmetBolgesi.value == 1)
        {
            bolge = "Beþiktaþ";
            bolgeGirdiMi = true;
        }
        else if (hizmetBolgesi.value == 2)
        {
            bolge = "Kadýköy";
            bolgeGirdiMi = true;
        }
        if (hizmetBolgesi.value == 3)
        {
            bolge = "Üsküdar";
            bolgeGirdiMi = true;
        }
        else if (hizmetBolgesi.value == 0)
        {
            bolgeGirdiMi = false;
        }

        if (isaret.isOn == true)
        {
            isaretGirdiMi = true;
            sikayetEkrani.gameObject.SetActive(true);
        }
        else
        {
            isaretGirdiMi = false;
            sikayetEkrani.gameObject.SetActive(false);
        }


        puan1.text = slider1.value.ToString();
        puan2.text = slider2.value.ToString();
        puan3.text = slider3.value.ToString();

        
    }


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
        if (bolgeGirdiMi&&isim!="")
        {
            _panel.gameObject.SetActive(true);
            yPuan1.text = s1Val.ToString();
            yPuan2.text = s2Val.ToString();
            yPuan3.text = s3Val.ToString();

            yBolge.text = bolge + " bölgesi";
            yIsim.text = "Sayýn " + isim + ", bizi deðerlendirmiþ olduðunuz için teþekkür ederiz.";
            saklama.gameObject.SetActive(true);
            sonButton.gameObject.SetActive(true);

        }
    }
}
