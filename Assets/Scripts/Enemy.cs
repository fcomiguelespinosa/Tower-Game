using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	void Start(){
		gameObject.GetComponent<Animator>().SetBool("SuccessShoot",false);
	}
	
	void OnCollisionEnter2D(Collision2D collision)
    {
		gameObject.GetComponent<Animator>().SetBool("SuccessShoot",true);
    }
	
	void Update()
    {
		if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit"))
        {
        	Destroy(gameObject);
        }
    }
}
