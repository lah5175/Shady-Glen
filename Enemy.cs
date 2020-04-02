using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "NPC/Monster")]
public class Enemy : ScriptableObject
{
    new public string name = "New Enemy";
    public float startingHP = 10f;
    public float damage = 10f;
}
