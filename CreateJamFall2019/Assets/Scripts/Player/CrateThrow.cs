using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateThrow : MonoBehaviour
{
    [SerializeField] private Transform playerGraphics;
    [SerializeField] private float rateOfCrate = 0.5f;
    [SerializeField] private bool isPlayer;

    private float nextSpawnTime;
    private PlayerController playerController;
    private WeponSwupper swapper;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        swapper = GetComponent<WeponSwupper>();
    }

    private void Update()
    {
        if (swapper.currentItem == Item.Crate)
        {
            if (isPlayer)
            {
                if ((Input.GetButton("P1Shoot") || Input.GetAxisRaw("P1Trigger") == 1) && Time.time > nextSpawnTime)
                {
                    DoStuff();
                }
            }
            else
            {
                if ((Input.GetButton("P2Shoot") || Input.GetAxisRaw("P2Trigger") == 1) && Time.time > nextSpawnTime)
                {
                    DoStuff();
                }
            }
        }
    }

    private void DoStuff()
    {
        Vector3 pos = transform.position;
        if (playerController.isTurnedLeft)
            pos += playerGraphics.right * 0.5f;
        else
            pos += playerGraphics.right * -0.5f;

        nextSpawnTime = Time.time + rateOfCrate;
        Instantiate(swapper.crate.Prefab, pos, playerGraphics.rotation);
    }
}
