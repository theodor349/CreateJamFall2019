using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {
    [SerializeField] private Transform playerGraphics;
    [SerializeField] private GameObject waterBulletPrefab;
    [SerializeField] private float rateOfFire = 0.25f;

    private float nextShootTime;
    private PlayerController playerController;
    private WeponSwupper swapper;

    private void Awake() {
        playerController = GetComponent<PlayerController>();
        swapper = GetComponent<WeponSwupper>();
    }

    private void Update() {
        if(swapper.currentItem == Item.Pistol) {
            if((Input.GetButtonDown("P1Shoot") || Input.GetAxisRaw("P1Trigger") == 1) && Time.time > nextShootTime) {
                Vector3 pos = transform.position;
                if (playerController.isTurnedLeft)
                    pos += playerGraphics.right * 0.4f;
                else
                    pos += playerGraphics.right * -0.4f;

                nextShootTime = Time.time + rateOfFire;
                GameObject bullet = Instantiate(waterBulletPrefab, pos, playerGraphics.rotation);
                WaterBullet bulletScript = bullet.GetComponent<WaterBullet>();
                bulletScript.flyLeft = playerController.isTurnedLeft;

                Vector2 force = new Vector2();
                if (playerController.isTurnedLeft)
                    force = -playerGraphics.right;
                else
                    force = playerGraphics.right;

                if(!playerController.isGrounded)
                    force *= bulletScript.bulletSpeed * 25;
                else
                    force *= bulletScript.bulletSpeed * 5;
                playerController.rbody.velocity += force * Time.deltaTime; 
            }
        }
    }
}
