using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	void Start(){
		gameObject.GetComponent<Animator>().SetBool("SuccessShoot",false);
	}
	
	void OnTriggerEnter2D(Collider2D collider)
    {
		gameObject.GetComponent<Animator>().SetBool("SuccessShoot",true);
		Destroy(gameObject.GetComponent<Collider2D>(), 0.3f);
		Destroy(collider.gameObject);
    }
	
	void Update()
    {
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit"))
        {
        	Destroy(gameObject);
        }
    }
}
