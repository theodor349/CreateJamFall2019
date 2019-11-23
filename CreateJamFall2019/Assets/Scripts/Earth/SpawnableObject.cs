using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Earth", menuName = "Spawnable")]
public class SpawnableObject : ScriptableObject
{
    public string Name = "Temp";
    public float CoolDown = 2f;
    public bool SpawnOnPlanet = false;
    public GameObject Prefab;
    public Image Icon;
}
