using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {
    [SerializeField] private Transform playerGraphics;
    [SerializeField] private GameObject waterBulletPrefab;
    [SerializeField] private float rateOfFire = 0.25f;
    [SerializeField] private float ammo = 10f;
    [SerializeField] private RectTransform waterLevel;

    private float ammoMax = 10f;
    private float waterLevelYMin = -173.4f;
    private float waterLevelYMax = -3.1f;

    private float nextShootTime;
    private PlayerController playerController;
    private WeponSwupper swapper;

    private float lerpSpeed = 3f;


    private void Awake() {
        InvokeRepeating("RegainWater", 0, 1f);
        playerController = GetComponent<PlayerController>();
        swapper = GetComponent<WeponSwupper>();
    }

    private void Update() {

        if (swapper.currentItem == Item.Pistol) {
            if((Input.GetButtonDown("P1Shoot") || Input.GetAxisRaw("P1Trigger") == 1) && Time.time > nextShootTime && ammo > 0) {
                Vector3 pos = transform.position;
                if (playerController.isTurnedLeft)
                    pos += playerGraphics.right * 0.4f;
                else
                    pos += playerGraphics.right * -0.4f;

                ammo--;
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

        UpdateWaterTank();
    }

    void RegainWater()
    {
        ammo += 1;
        if (ammo > ammoMax)
            ammo = ammoMax;
    }

    void UpdateWaterTank()
    {
        float percent = ammo / ammoMax;
        Vector3 pos = waterLevel.localPosition;
        pos.y = waterLevelYMin * (1-percent);
        pos.y = Mathf.Clamp(pos.y, waterLevelYMin, waterLevelYMax);
        waterLevel.localPosition =  Vector3.Lerp(waterLevel.localPosition, pos, lerpSpeed * Time.deltaTime);
    }
}
