using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 10;
    private float startspeed = 3.0F;
    private float acceleration = 400F;
    [SerializeField]
    private float adspeed = 0;
    private double sleepingtime = 0;

    private double Sleepingtime

    {
        get { return sleepingtime; }
        set { if (sleepingtime + value > 0) sleepingtime = value; else sleepingtime = 0; }
    }
    private float Speed
    {
        get { return adspeed + startspeed; }
        set { if (adspeed <= 10.0F) adspeed += value; }
    }
    private float jumpforce = 0.1F;
    //bool isGrounded = false;
    new private Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private Bullet bullet;
    private ParticleSystem emission;
    bool whichside = true;
    
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bullet = Resources.Load<Bullet>("Bullet");
        emission = GetComponentInChildren<ParticleSystem>(); 
    }
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetButton("Horizontal")) Move();
        if (Input.GetKey(KeyCode.S)) GetDown();
        if (Input.GetKey(KeyCode.W) /*&& isGrounded*/ ) Jump();
        if ((Input.GetKey(KeyCode.E) || Input.GetButtonDown("Fire1")) && Sleepingtime == 0) { Shoot(); Sleepingtime += 0.5; }
        Sleepingtime -= Time.deltaTime;
    }
    private void Move()
    {
        Vector3 direction_hor = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction_hor, Speed * Time.deltaTime);
        if (whichside != sprite.flipX)
        {
            float x = System.Math.Abs(emission.transform.position.x - transform.position.x);
            emission.transform.position = new Vector3(transform.position.x  +  (sprite.flipX ? 1: -1) * x, emission.transform.position.y, emission.transform.position.z);
            x = (emission.transform.position.x - transform.position.x < 0 && !whichside? 1 : -1);
            emission.transform.rotation = Quaternion.Euler( emission.transform.rotation.eulerAngles.x , emission.transform.rotation.eulerAngles.y, x * emission.transform.rotation.eulerAngles.z);
        
        }
        whichside = sprite.flipX;
        sprite.flipX = direction_hor.x < 0.0F;
        
        rigidbody.AddForce(direction_hor * acceleration * Time.deltaTime * Time.deltaTime / 2, ForceMode2D.Impulse);
    }
    private void GetDown()
    {
        rigidbody.AddForce(-Vector3.up * jumpforce/2, ForceMode2D.Impulse);
    }
    private void Jump()
    {
        
        rigidbody.AddForce(Vector3.up * jumpforce, ForceMode2D.Impulse );
    }
    private void Shoot() 
    {
        Vector3 position = transform.position;
        Bullet newbullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;
        newbullet.Direction = newbullet.transform.right * (sprite.flipX ? -1.0F : 1.0F) ;

    }
   
   
    //private void FixedUpdate()
    //{
    //    Groundcheck(); 
    //}
}
