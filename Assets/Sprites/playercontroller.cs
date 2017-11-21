using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playercontroller : MonoBehaviour {

    // Use this for initialization
    public float maxSpeed;
    public float jumHeight;
    bool facingRight;
    private float jum;
    Rigidbody2D mybody;
    Animator myAnim;
    bool ground;
    public Transform gunTip;
    public GameObject bullet;
    private float fireRate = 0.4f;
    private float nextFire=1;
	void Start () {
        mybody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        mybody = GetComponent<Rigidbody2D>();
        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        mybody.velocity = new Vector2(move * maxSpeed, mybody.velocity.y);
        if(move > 0 && !facingRight)
        {
            flip();
        }
        else if(move <0 && facingRight)
        {
            flip();
            facingRight = false;
        }
        if (Input.GetKey (KeyCode.W))
        {
            if (ground)
            {
                ground = false;
                mybody.velocity = new Vector2(mybody.velocity.x, jumHeight);
                //myAnim.SetFloat("jum", 2);
            }
        }
      
        if(Input.GetAxisRaw("Fire1")>0)
        {
            fireBullet();
        }
	}
    //quay mat
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    //cham mat dat
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GR"|| collision.gameObject.tag == "Shootalbe")
        {
            ground = true;
        }
        else
            ground = false;
    }
    //chuc nang ban
    void fireBullet()
    {
        if (Time.time > nextFire)
        {
          
            nextFire = Time.time + fireRate;
            if(facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if(!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
          //  myAnim.SetBool("fire", false);
        }
    }
}
