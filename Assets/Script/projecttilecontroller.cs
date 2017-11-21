using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projecttilecontroller : MonoBehaviour {
    public float bulletSpeed;
    Rigidbody2D mybody;
    Animator myAnim;
    //  public GameObject bullerExplosion;
    // Use this for initialization
    void Start () {
        mybody = GetComponent<Rigidbody2D>();
        //myAnim = GetComponent<Animator>();
        //myAnim.SetBool("fire", true);
        if (transform.localRotation.z == 0)
        {
            mybody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
        else
            mybody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
    //    myAnim.SetBool("fire", false);
    }
	
	// Update is called once per frame
	void Update () {
		if(transform.localPosition.y<-30)
        {
            removeForce();
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GR"|| collision.gameObject.tag == "Shootalbe")
        {
            removeForce();
          //  Instantiate(bullerExplosion, transform.position, transform.rotation);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
                if (collision.gameObject.tag == "GR")
        {
            removeForce();
          //  Instantiate(bullerExplosion, transform.position, transform.rotation);
            
        }
      else  if (collision.gameObject.tag == "Shootalbe")
        {
            removeForce();
            Destroy(gameObject);
          //  Instantiate(bullerExplosion, transform.position, transform.rotation);
            
        }
    }
    public void removeForce()
    {
        mybody.velocity = new Vector2(0, 0);
        
    }
}
