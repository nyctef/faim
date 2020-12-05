using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHittable : MonoBehaviour
{
    public delegate void OnHitFunc(int damage);
    public OnHitFunc OnHit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Hit(int damage)
    {
        this.OnHit?.Invoke(damage);
    }


}
