using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject Bullet;
	public GameObject Emiter;
	public float force_bullet;
	private float acumulateTime;
	private float waitShootTime;
	
    // Start is called before the first frame update
    void Start()
    {
    	gameObject.GetComponent<Animator>().SetBool("shooting",false);
    	acumulateTime = 0;
    	waitShootTime = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {	
        if (Input.GetMouseButtonDown(0)){
    		gameObject.GetComponent<Animator>().SetBool("shooting",true);
    		acumulateTime = waitShootTime;
        }
    	
    	if(gameObject.GetComponent<Animator>().GetBool("shooting")){

    		var playerPos = transform.parent.position;    		
			var diffPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerPos;
			var angle = Quaternion.Euler(0, 0, (-1)*(Mathf.Atan2(diffPos.x, diffPos.y) * Mathf.Rad2Deg));
			transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, angle, 1.0f);
			
			acumulateTime += Time.deltaTime;
			if(acumulateTime > waitShootTime){
				acumulateTime = 0;
				
				GameObject bullet_temp;
    			bullet_temp = Instantiate(Bullet,Emiter.transform.position,Emiter.transform.rotation) as GameObject;
    		
    			Rigidbody2D Temp_RigidBody;
    			Temp_RigidBody = bullet_temp.GetComponent<Rigidbody2D>();
    			Temp_RigidBody.AddForce(transform.up * force_bullet);
    			Destroy(bullet_temp, 3.0f);
			}
		}
    	
        if (Input.GetMouseButtonUp(0)){
    		gameObject.GetComponent<Animator>().SetBool("shooting",false);
        }
    }
}