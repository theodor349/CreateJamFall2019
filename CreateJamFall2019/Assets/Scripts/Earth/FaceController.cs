using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    public Transform Player1;
    public Transform Player2;
    public float Speed = 10f;
    public Sprite[] Faces;
    public SpriteRenderer Renderer;

    private int index;

    private void Start()
    {
        EarthProperties.RegistreLevelUpAction(LevelUp);
    }

    private void LevelUp(int level)
    {
        ChangeSprite();
    }

    private void ChangeSprite()
    {
        index++;
        if(!(index >= Faces.Length))
            Renderer.sprite = Faces[Faces.Length - 1 - index];
    }

    private void Update()
    {
        var target = GetTargetPos();
        Move(target);
    }

    private void Move(Vector3 target)
    {
        var dir = target - transform.position;
        dir *= Time.deltaTime * Speed;
        transform.Translate(dir, Space.World);
    }

    private Vector3 GetTargetPos()
    {
        var pos = (Player1.position + Player2.position) * 0.5f;

        pos = pos.normalized * (EarthProperties.Instance.Radius * 0.85f);

        return pos;
    }
}
