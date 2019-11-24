using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

public class SpawnDelay : MonoBehaviour
{
    public float Delay = 2f;
    private float delayed = 0f;
    private bool startGame;
    private int menu = 0;
    
    public GameObject[] Spawn;
    public GameObject[] BeforeSpawn;
    public GameObject IntroScene;
    public CameraController Camera;
    public GameObject StartMenu;
    public GameObject SecondMenu;
    public GameObject ThridMenu;
    public EarthProperties EarthProperties;
    
    void Update()
    {
        if(Input.anyKeyDown)
            menu++;

        if (menu == 1)
        {
            StartMenu.SetActive(false);
            SecondMenu.SetActive(true);
        }
        
        if (menu == 2)
        {
            SecondMenu.SetActive(false);
            ThridMenu.SetActive(true);
        }

        if (menu == 3)
        {
            ThridMenu.SetActive(false);
            startGame = true;
            IntroScene.SetActive(true);
            foreach (var g in BeforeSpawn)
            {
                g.SetActive(true);
            }
        }
        
        if (startGame)
        {
            delayed += Time.deltaTime;
            if (delayed >= Delay)
            {
                Camera.enabled = true;

                foreach (var g in Spawn)
                {
                    g.SetActive(true);
                }
            }
        }
        EarthProperties.enabled = true;
    }
}
