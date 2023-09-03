using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BoxDetective : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject goldKey;
    [SerializeField] GameObject silverKey;

    [SerializeField] GameObject AllEnemys;
    
    [SerializeField] ParticleSystem BoxPartical;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyBox")
        {
            //StartCoroutine(BoxBehavior(collision, Enemy));
            boxBehavior(collision, Enemy);
        }
        else
        if(collision.gameObject.tag == "SelverKeyBox")
        {
            //StartCoroutine(BoxBehavior(collision, silverKey));
            boxBehavior(collision, silverKey);
        }
        else
        if (collision.gameObject.tag == "GoldKeyBox")
        {
            //StartCoroutine(BoxBehavior( collision,goldKey));
            boxBehavior(collision, goldKey);
        }
    }


    IEnumerator  BoxBehavior(Collision collision,GameObject obj)
    {
        GameObject ParticalTemp =
        Instantiate(BoxPartical.gameObject, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        yield return new WaitForSeconds(0.6f);
        Destroy(collision.gameObject);
        GameObject temp = Instantiate(obj, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        temp.SetActive(false);
        temp.SetActive(true);
        Destroy(ParticalTemp);

        if (obj.tag == "Enemy" )
        {
            temp.transform.parent = AllEnemys.transform;
        }
    }
    void boxBehavior(Collision collision, GameObject obj)
    {
        GameObject ParticalTemp =
        Instantiate(BoxPartical.gameObject, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        //yield return new WaitForSeconds(0.6f);
        Destroy(collision.gameObject);
        GameObject temp = Instantiate(obj, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        temp.SetActive(false);
        StartCoroutine(waitForSeconds(0.4f,ParticalTemp,temp));
       // Destroy(ParticalTemp);

        if (obj.tag == "Enemy")
        {
            temp.transform.parent = AllEnemys.transform;
        }
    }
    IEnumerator waitForSeconds(float seconds,GameObject particalS,GameObject tempItem)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(particalS);
        tempItem.SetActive(true);
    }
}
