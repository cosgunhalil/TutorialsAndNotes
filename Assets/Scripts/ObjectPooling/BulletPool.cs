using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour {
    public GameObject BulletPrefab;
    private List<Bullet> _bullets;

    public void Init()
    {
        _bullets = new List<Bullet>();
    }

    public void Init(int bulletCount)
    {
        _bullets = new List<Bullet>();
        for (int i = 0; i < bulletCount; i++)
        {
            AddBulletToPool(CreateBullet());
        }
    }

    public void AddBulletToPool(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bullets.Add(bullet);
    }

    private Bullet CreateBullet()
    {
        var bulletGo = Instantiate(BulletPrefab) as GameObject;
        bulletGo.transform.SetParent(transform);

        var bullet = bulletGo.GetComponent<Bullet>();
        bullet.Init();

        return bullet;
    }

    public Bullet GetBullet()
    {
        if (_bullets.Count < 1)
        {
            AddBulletToPool(CreateBullet());
        }

        var bullet = _bullets[_bullets.Count - 1];
        _bullets.Remove(bullet);

        bullet.gameObject.SetActive(true);

        return bullet;

    }
}
