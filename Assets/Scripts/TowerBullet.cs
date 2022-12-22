using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    [SerializeField] protected float bulletspeed = 1.2f;  // ÃÑ¾Ë ½ºÇÇµå

    CapsuleCollider2D capsuleCollider = null;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Greatbullet();
    }

    void Greatbullet()
    {

        if (this.transform.position.y > 0.5f)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Mon")
        {
            Destroy(this.gameObject);
        }
    }
}
