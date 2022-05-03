using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Controller : MonoBehaviour
{
    public GameObject playercon;
    private Player_Controller player;
    public cube_spawner[] fallingcubes;

    public void Action()
    {
        player = playercon.GetComponent<Player_Controller>();
        player.loock = true;
        gameObject.SetActive(false);
        for (int i = 0; i < fallingcubes.Length; i++)
        {
            fallingcubes[i].startcount = true;
        }
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
