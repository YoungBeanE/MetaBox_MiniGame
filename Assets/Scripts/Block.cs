using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer = null;
    [SerializeField] Sprite road = null;

    public bool IsBlock { get; set; } = true;
    Vector2 myPos;

    private void Awake()
    {
        myPos = transform.position;
    }
    public void Select()
    {
        IsBlock = false;
        spriteRenderer.sprite = road;
    }
    
}
