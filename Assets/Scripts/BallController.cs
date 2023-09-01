using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour
{
    [SerializeField] float health=10f;
    [SerializeField] float movementSpeed;
    [SerializeField] float timeAmount = 120f;

    float horizontalMovement, verticalMovement;

    Rigidbody rigidBody;

    [SerializeField] TextMeshProUGUI healtText;
    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] Canvas gameOverScene;
    [SerializeField] Canvas gameWinScene;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        timeAmount -= Time.deltaTime;

        healtText.text = "Health: "+health.ToString();
        timeText.text = "Time: "+timeAmount.ToString();
        gameOverScene.gameObject.SetActive(false);
        gameWinScene.gameObject.SetActive(false);
    }

    private void Update()
    {
        timeAmount -= Time.deltaTime;

        horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        rigidBody.AddForce(horizontalMovement, 0f, verticalMovement);



        healtText.text = "Health: " + health.ToString();
        timeText.text = "Time: " + (int)timeAmount;

       
            gameOverScene.gameObject.SetActive(true);
            movementSpeed = 0f; if (timeAmount <= 0 || health <= 0)
        {
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Duvar")
        {
            health--;
            
        }

        if (collision.gameObject.tag == "Finish")
        {
            gameWinScene.gameObject.SetActive(true);
        }
    }

    

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }






}
