using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField]
    private WeponSwupper swapper;

    [SerializeField]
    private float waterAmmo = 40;
    
    private void Update() {
        if(swapper.isGun) {
            if(Input.GetButtonDown("P1Shoot"))
            {

            }
        }
    }
}
