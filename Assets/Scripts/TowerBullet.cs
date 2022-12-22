using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    [SerializeField] protected float bulletspeed = 1.2f;  // ÃÑ¾Ë ½ºÇÇµå

    void Update()
    {
        Greatbullet();
    }

    void Greatbullet()
    {

        if (this.transform.position.y > 3)
        {
            Destroy(this.gameObject);
        }

        this.transform.Translate(Vector3.up * this.bulletspeed * Time.deltaTime);
    }
}
