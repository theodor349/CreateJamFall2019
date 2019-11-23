using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {
    [SerializeField] private Transform playerGraphics;
    [SerializeField] private WeponSwupper swapper;
    [SerializeField] private GameObject waterBulletPrefab;
    [SerializeField] private float shootCooldown = 0.25f;
    [SerializeField] private float waterAmmo = 40;

    private float nextShootTime;
    private PlayerController playerController;

    private void Awake() {
        playerController = GetComponent<PlayerController>();
    }

    private void Update() {
        if(swapper.isGun) {
            if((Input.GetButtonDown("P1Shoot") || Input.GetAxisRaw("P1Trigger") == 1) && Time.time > nextShootTime) {
                Vector3 pos = transform.position;
                if (playerController.isTurnedLeft)
                    pos += playerGraphics.right * 0.1f;
                else
                    pos += playerGraphics.right * -0.1f;

                nextShootTime = Time.time + shootCooldown;
                GameObject bullet = Instantiate(waterBulletPrefab, pos, playerGraphics.rotation);
                bullet.GetComponent<WaterBullet>().flyLeft = playerController.isTurnedLeft;
            }
        }
    }
}
