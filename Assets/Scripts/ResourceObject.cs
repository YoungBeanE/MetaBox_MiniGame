using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MonsterData
{
    public byte id;
    public int hp;
    public float speed;
    public int gold;
    public int damage;
    public Sprite image;
    public AudioClip myClip;
    public ParticleSystem fx;
}

[CreateAssetMenu(fileName = "New ResourceData", menuName = "ScriptableObjects/ResourceData", order = 5)]
public class ResourceObject : ScriptableObject
{
    public MonsterData[] monsterDatas;
}
