using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour {
    [SerializeField] public float bulletSpeed = 20f;
    [SerializeField] private float lifespan = 5f;
    [HideInInspector] public bool flyLeft;

    private void Awake() {
        StartCoroutine(Lifespan());
    }

    void Update() {
        if(flyLeft)
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
        else
            transform.Translate(-Vector3.right * bulletSpeed * Time.deltaTime);
    }

    IEnumerator Lifespan() {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
