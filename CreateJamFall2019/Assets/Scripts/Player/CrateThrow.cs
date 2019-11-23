using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateThrow : MonoBehaviour
{
    [SerializeField] private Transform playerGraphics;
    [SerializeField] private float spawnCooldown = 0.5f;

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
        if (!swapper.isGun)
        {
            if ((Input.GetButtonDown("P1Shoot") || Input.GetAxisRaw("P1Trigger") == 1) && Time.time > nextSpawnTime)
            {
                Vector3 pos = transform.position;
                if (playerController.isTurnedLeft)
                    pos += playerGraphics.right * 0.5f;
                else
                    pos += playerGraphics.right * -0.5f;

                nextSpawnTime = Time.time + spawnCooldown;
                Instantiate(swapper.Crate.Prefab, pos, playerGraphics.rotation);
            }
        }
    }
}
