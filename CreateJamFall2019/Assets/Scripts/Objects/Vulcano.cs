using System;
using System.Collections;
using System.ComponentModel;
using UnityEditor;
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
    public GameObject Lava;
    
    private float coolDown;

    private void Start()
    {
        coolDown = CoolDown;
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
        Lava.SetActive(true);
        for (int i = 0; i < Random.Range(MinErupt, MaxErupt); i++)
        {
            Erupt();
            yield return new WaitForSeconds(Random.Range(MinInterval, MaxInterval));
        }
        Lava.SetActive(false);
    }

    private void Erupt()
    {
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

    private Vector2 RotateVector(Vector2 v, float angle)
    {
        var result = new Vector2(); 
        result.x = (float)(v.x * Math.Cos(angle) - v.y * Math.Sin(angle));
        result.x = (float)(v.x * Math.Sin(angle) + v.y * Math.Cos(angle));
        return result;
    }
}
