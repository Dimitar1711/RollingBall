using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Player_Controller : MonoBehaviour
{
    public float speed = 1;
    public TextMeshProUGUI CounterText;
    public GameObject PickupHolder;
    public TextMeshProUGUI CounterLivesText;

    private bool isWinning = false;
    private Rigidbody rb;
    private float moveX;
    private float moveY;

    private int count = 0;

    private float boost = 0;
    public int boost_speed = 10;
    private float temp_speed;
    public GameObject victoryscreen;
    public GameObject pickups;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject restartbt;
    public GameObject GameOver;
    public GameObject NextLevel;




    public bool loock;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        restartbt.SetActive(false);
        if (NextLevel != null)
        {
            NextLevel.SetActive(false);
        }
        loock = false;
        victoryscreen.SetActive(false);
        rb = GetComponent<Rigidbody>();
        temp_speed = speed;
        if (enemy1 != null)
        {
            enemy1.SetActive(false);
        }
        if (enemy2 != null)
        {
            enemy2.SetActive(false);
        }
        if (enemy3 != null)
        {
            enemy3.SetActive(false);
        }
        CounterText.text = "Count: " + count.ToString();
        CounterLivesText.text = "Lives " + GameManager.Instance.lives.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, y: 0, z: moveY);
        rb.AddForce(movement * temp_speed);

    }

    private void Update()
    {
        if (boost <= 0)
        {
            temp_speed = speed;
            boost = 0;
        }
        else
        {
            temp_speed = boost_speed;
            boost = boost - Time.deltaTime;
        }
        if (count == pickups.transform.childCount)
        {
            victoryscreen.SetActive(true);
            if (enemy1 != null)
            {
                enemy1.SetActive(false);
            }
            if (enemy2 != null)
            {
                enemy2.SetActive(false);
            }
            if (enemy3 != null)
            {
                enemy3.SetActive(false);
            }
            restartbt.SetActive(true);
            Time.timeScale = 0;

        }
        if (count == 1)
        {
            if (enemy1 != null)
            {
                enemy1.SetActive(true);
                Rigidbody enemyrb = enemy1.GetComponent<Rigidbody>();
                Vector3 movement = new Vector3(x: UnityEngine.Random.Range(5, 10), y: 0, z: UnityEngine.Random.Range(5, 10));
                enemyrb.AddForce(movement);
            }
        }

        if (count == 5)
        {
            if (enemy2 != null)
            {
                enemy2.SetActive(true);
                Rigidbody enemyrb = enemy2.GetComponent<Rigidbody>();
                Vector3 movement = new Vector3(x: UnityEngine.Random.Range(5, 10), y: 0, z: UnityEngine.Random.Range(5, 10));
                enemyrb.AddForce(movement);
            }
        }

        if (count == 9)
        {
            if (enemy3 != null)
            {
                enemy3.SetActive(true);
                Rigidbody enemyrb = enemy3.GetComponent<Rigidbody>();
                Vector3 movement = new Vector3(x: UnityEngine.Random.Range(5, 10), y: 0, z: UnityEngine.Random.Range(5, 10));
                enemyrb.AddForce(movement);
            }
            
        }


    }

    void OnMove(InputValue movement)
    {
        if (loock)
        {
            Vector2 movementVector = movement.Get<Vector2>();
            moveX = movementVector.x;
            moveY = movementVector.y;
        }

    }

    void OnJump()
    {
        Boost();
    }

    private void Boost()
    {
        boost = 1;
        temp_speed = temp_speed + boost_speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Transform[] allChildrens = PickupHolder.transform.GetComponentsInChildren<Transform>();
        if (other.gameObject.CompareTag("pickup"))
        {
            //other.gameObject.SetActive(false);
            for (int i = 0; i < allChildrens.Length; i++)
            {
                if (allChildrens[i].gameObject == other.gameObject)
                {
                    allChildrens[i].gameObject.SetActive(false);
                }
            }
                count++;

            if (count == 7)
            {
                GameManager.Instance.LivesIncr();
            }
            if (count == 13)
            {
                GameManager.Instance.LivesIncr();
            }



            bool shouldWin = false;
            for (int i = 0; i < allChildrens.Length; i++)
            {
                Debug.Log("name " + allChildrens[i].name);
            }

            for (int i = 0; i < allChildrens.Length; i++)
            {
                if (allChildrens[i].gameObject != PickupHolder)
                {
                    shouldWin = shouldWin || allChildrens[i].gameObject.activeSelf;
                }
                
                // shouldWin = false;

                Debug.Log(allChildrens[i].gameObject.activeSelf);
            }
            Debug.Log("isWin" + shouldWin.ToString());
            isWinning = !shouldWin;
            Debug.Log("count" +allChildrens.Length);
            SetPlayerResult();

        }
        
    }
    void SetPlayerResult()
    {

        if (isWinning)
        {
            CounterText.text = "Winner";
            loock = false;
            NextLevel.SetActive(true);

        }
        CounterText.text = "Count: " + count.ToString();
        CounterLivesText.text = "Lives " + GameManager.Instance.lives.ToString();

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            GameManager.Instance.lives -= 1;
            if (GameManager.Instance.lives == 0)
            {
                gameObject.SetActive(false);
                GameOver.SetActive(true);
                restartbt.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("enemywall"))
        {
            GameManager.Instance.lives -= 1;
            if (GameManager.Instance.lives == 0)
            {
                gameObject.SetActive(false);
                GameOver.SetActive(true);
                restartbt.SetActive(true);
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {

    }


    void GameRestart()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}

