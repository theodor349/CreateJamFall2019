using System;
using System.Collections;
using System.ComponentModel;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class Vulcano : MonoBehaviour
{
    public float CoolDown = 2f;
    public Transform EruptPoint;
    public GameObject FireBall;
    public float XSpread = 2f;
    public float YSpeed = 5f;
    public int MinErupt = 2;
    public int MaxErupt = 5;
    public float MinInterval = 0.2f;
    public float MaxInterval = 0.4f;
    public FadeInOut Lava;

    [Header("Colliders")] 
    public GameObject[] Masks;
    public Collider2D[] Colliders;
    private int leftInex = 0;
    private int rightIndex;
    private int damage = 0;
    
    private float coolDown;

    private void Start()
    {
        coolDown = CoolDown;
        rightIndex = Masks.Length - 1;

        foreach (var collider2D1 in Colliders)
        {
            collider2D1.enabled = true;
        }

        foreach (var mask in Masks)
        {
            mask.SetActive(false);
        }
    }

    void Update()
    {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0)
        {
            coolDown = CoolDown;
            StartCoroutine(MakeEruptions());
        }
    }

    IEnumerator MakeEruptions()
    {
        Lava.StartFade();
        for (int i = 0; i < Random.Range(MinErupt, MaxErupt); i++)
        {
            Erupt();
            yield return new WaitForSeconds(Random.Range(MinInterval, MaxInterval));
        }
        Lava.StopFade();
    }

    private void Erupt()
    {
        AudioController.Play(Sound.Vulcano);
        var go = Instantiate(FireBall, EruptPoint);
        go.transform.parent = transform;
        var rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(GetStartVelocity());
    }

    private Vector2 GetStartVelocity()
    {
        var v = new Vector2();
        v.x = Random.Range(-XSpread, XSpread);
        v.y = Random.Range(YSpeed * 0.25f, YSpeed);

        return v * 100f;
    }

    public void Damage(Vector3 point)
    {
        bool isLeftSide = transform.position.x - point.x > 0;
        if (isLeftSide)
        {
            Masks[leftInex].SetActive(true);
            Colliders[leftInex].enabled = false;
            leftInex++;
        }
        else
        {
            Masks[rightIndex].SetActive(true);
            Colliders[rightIndex].enabled = false;
            rightIndex--;
        }

        damage++;

        if (damage == Masks.Length)
            StartCoroutine(KillWait());
    }

    IEnumerator KillWait()
    {
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        gameObject.AddComponent<FallIntoGround>();
    }
}
