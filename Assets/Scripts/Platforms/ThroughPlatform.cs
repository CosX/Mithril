using UnityEngine;
using System.Collections;

public class ThroughPlatform : MonoBehaviour {

    private Transform _groundCheck;

    //void Start()
    //{
    //    _groundCheck = gameObject.transform.Find("groundcheck").transform;
    //}
    //void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.tag == "Platform")
    //    {
    //        coll.collider.isTrigger = true;
    //    }
    //}
    //void OnTriggerStay2D(Collider2D coll)
    //{
    //    if (coll.gameObject.tag == "Platform")
    //    {
    //        if (coll.bounds.max.y < _groundCheck.position.y)
    //        {
    //            coll.isTrigger = false;
    //        }
    //    }
    //}
}
