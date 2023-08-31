using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    float yatayHareket;
    float dikeyHareket;
    [SerializeField] float hareketHizi;
    [SerializeField] float rotSpeed;
    Camera cam;
    Rigidbody rigidBody;
    bool isJumped;

    Animator anim;

    [SerializeField] Vector3 cameraOffset;

    bool isFall = false;
    int fallLimit = 0;


    float score;
    [SerializeField] TextMeshProUGUI scoreText;
    float startPoint;
    float currentPoint;

    [SerializeField] Canvas overCanvas;
    [SerializeField] TextMeshProUGUI endScore;


    //[SerializeField] GameObject road1;
    //[SerializeField] GameObject road2;

    //Vector3 roadOffset = new Vector3(0f, 0f, 160f);
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        rigidBody = GetComponent<Rigidbody>();
        CameraFollow();

        isJumped = false;
        startPoint = this.transform.position.z;
        overCanvas.gameObject.SetActive(false);
       
    }




    private void Update()
    {
        currentPoint = this.transform.position.z;
        score = Mathf.CeilToInt(currentPoint - startPoint);
        CameraFollow();

        yatayHareket = Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed;
        dikeyHareket = Input.GetAxis("Vertical") * Time.deltaTime * hareketHizi;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            anim.SetTrigger("jump");
            rigidBody.AddForce(0f, 225f, 0f);
            
        }

      

        if (dikeyHareket > 0)
        {
            anim.SetBool("isRun", true);
            transform.Translate(0f, 0f, dikeyHareket);

            if (yatayHareket != 0)
            {
                transform.Translate(yatayHareket, 0f, 0f);
            }
        }
        else
        {
            anim.SetBool("isRun", false);
        }



        if (isFall&&fallLimit==0)
        {
            
            anim.SetTrigger("fall");
            hareketHizi = 0f;
            overCanvas.gameObject.SetActive(true);
            endScore.text = "Score: "+score.ToString();
            scoreText.gameObject.SetActive(false);
            fallLimit++;
        }


        scoreText.text ="Score: "+score.ToString();

    }


    void CameraFollow()
    {
        cam.transform.position = this.transform.position - cameraOffset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Duvar")
        {
            
            isFall = true;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "road1")
    //    {
    //        road1.transform.position += road1.transform.position + roadOffset;
    //    }

    //    else if (other.gameObject.tag == "road1")
    //    {
    //        road2.transform.position += road1.transform.position + roadOffset;
    //    }
            
    //}


    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
