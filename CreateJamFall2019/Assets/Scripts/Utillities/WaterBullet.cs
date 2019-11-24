using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : MonoBehaviour {
    [SerializeField] public float bulletSpeed = 10f;
    [SerializeField] private float lifespan = 5f;
    [HideInInspector] public bool flyLeft;

    private void Awake() {
        StartCoroutine(Lifespan());
    }

    void Update() {

        RaycastHit2D hit;

        if(flyLeft)
        {
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime);
            hit = Physics2D.Raycast(transform.position, transform.right, 0.1f);
        }
        else
        {
            transform.Translate(-Vector3.right * bulletSpeed * Time.deltaTime);
            hit = Physics2D.Raycast(transform.position, -transform.right, 0.1f);
        }
        
        if(hit.collider != null)
        {
            switch (hit.transform.tag)
            {
                case "Player":
                    Vector2 force = new Vector2();
                    PlayerController pCont = hit.transform.GetComponent<PlayerController>();
                    if (flyLeft) force = Vector3.right;
                    else force = -Vector3.right;
                    force *= bulletSpeed * 25;
                    pCont.rbody.velocity += force * Time.deltaTime;
                    break;
                case "Crate":
                    hit.transform.GetComponent<ObjectLife>().Damage();
                    break;
            }

            Destroy(gameObject);
        }
    }

    IEnumerator Lifespan() {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
}
