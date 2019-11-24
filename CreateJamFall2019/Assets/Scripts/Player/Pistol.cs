using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {
    [SerializeField] private Transform playerGraphics;
    [SerializeField] private GameObject waterBulletPrefab;
    [SerializeField] private float rateOfFire = 0.25f;
    [SerializeField] private float ammo = 10f;
    [SerializeField] private RectTransform waterLevel1;
    [SerializeField] private RectTransform waterLevel2;
    [SerializeField] private bool isPlayer1;

    private float ammoMax = 10f;
    private float waterLevel1Min = -173.4f;
    private float waterLevel1Max = -3.1f;
    private float waterLevel2Min = -170f;
    private float waterLevel2Max = -10.4f;

    private float nextShootTime;
    private PlayerController playerController;
    private WeponSwupper swapper;

    private float lerpSpeed = 1f;


    private void Awake() {
        InvokeRepeating("RegainWater", 0, 1f);
        playerController = GetComponent<PlayerController>();
        swapper = GetComponent<WeponSwupper>();
    }

    private void Update() {
        if (swapper.currentItem == Item.Pistol) {
            if (isPlayer1)
            {
                if((Input.GetButtonDown("P1Shoot") || Input.GetAxisRaw("P1Trigger") == 1) && Time.time > nextShootTime && ammo > 0) {
                    DoStuff();
                }
            }
            else
            {
                if((Input.GetButtonDown("P2Shoot") || Input.GetAxisRaw("P2Trigger") == 1) && Time.time > nextShootTime && ammo > 0) {
                    DoStuff();
                }
            }
        }

        UpdateWaterTank();
    }

    private void DoStuff()
    {
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

    void RegainWater()
    {
        ammo += 1;
        if (ammo > ammoMax)
            ammo = ammoMax;
    }

    void UpdateWaterTank()
    {
        float percent = ammo / ammoMax;
        if(isPlayer1)
        {
            Vector3 pos = waterLevel1.localPosition;
            pos.y = waterLevel1Min * (1 - percent);
            pos.y = Mathf.Clamp(pos.y, waterLevel1Min, waterLevel1Max);
            waterLevel1.localPosition = Vector3.Lerp(waterLevel1.localPosition, pos, lerpSpeed * Time.deltaTime);

        }
        else
        {
            Vector3 pos = waterLevel2.localPosition;
            pos.y = waterLevel2Min * (1 - percent);
            pos.y = Mathf.Clamp(pos.y, waterLevel2Min, waterLevel2Max);
            waterLevel2.localPosition = Vector3.Lerp(waterLevel2.localPosition, pos, lerpSpeed * Time.deltaTime);
        }
    }
}
