using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    [SerializeField] protected float bulletspeed = 1.2f;  // ÃÑ¾Ë ½ºÇÇµå
    Vector2 myPos;
    CapsuleCollider2D capsuleCollider = null;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        myPos = transform.position;
    }

    void Update()
    {
        Greatbullet();
    }

    void Greatbullet()
    {

        if(this.transform.position.y - myPos.y > 1f)
        {
            Destroy(this.gameObject);
        }

        this.transform.Translate(Vector3.up * this.bulletspeed * Time.deltaTime);
    }

    public void SetTrue()
    {
        this.gameObject.GetComponent<TowerBullet>().enabled = true;
    }

    public void Setfalse()
    {
        this.gameObject.GetComponent<TowerBullet>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mon")
        {
            collision.transform.GetComponent<Monster>().Die();
            Destroy(this.gameObject);
        }
    }
    
}
