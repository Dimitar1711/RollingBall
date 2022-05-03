using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    //public GameObject restart;

    public void RestartGame()
    {

        GameManager.Instance.lives = 1;
        Scene scene = SceneManager.GetActiveScene();
        string activescene = scene.name;
        SceneManager.LoadScene(activescene);
        //gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
