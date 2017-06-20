using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public BulletPool BulletPool;

    private Transform _transform;
    private List<Bullet> _firedBullets;
    private float _bulletXLimit;

    void Start()
    {
        _transform = GetComponent<Transform>();
        _firedBullets = new List<Bullet>();
        _bulletXLimit = 11;
        BulletPool.Init(10);

        StartCoroutine("AutoShot", .1f);
    }

    void Update()
    {
        MoveBullets();
        CheckBulletLifeTimes();
    }

    private void MoveBullets()
    {
        for (int i = 0; i < _firedBullets.Count; i++)
        {
            _firedBullets[i].Move();
        }
    }

    private void CheckBulletLifeTimes()
    {
        for (int i = 0; i < _firedBullets.Count; i++)
        {
            if (_firedBullets[i].GetPosition().x > _bulletXLimit)
            {
                BulletPool.AddBulletToPool(_firedBullets[i]);
                _firedBullets.Remove(_firedBullets[i]);
            }
           
        }
    }

    private IEnumerator AutoShot(float fireRate)
    {
        while (true)
        {
            var bullet = BulletPool.GetBullet();
            bullet.SetPosition(_transform.position);
            _firedBullets.Add(bullet);
            yield return new WaitForSeconds(fireRate);
        }
    }

}
