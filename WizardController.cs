using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class WizardController : MonoBehaviour
{

    //Wizard Variables
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    public Sprite[] animations;
    private float direction = 3f;
    private float runSpeed = 10f;
    private float horizontal;
    private float vertical;
    private float moveLimiter = 0.7f;


    //Fireball Variables
    private float shootSpeed = 6f;
    private float newRotationZ;
    public GameObject fireball;
    private bool canShoot = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && canShoot == true) {
            ShootFireball();
            StartCoroutine(StartCoolDown());
        }
    
    }

    private void FixedUpdate() {

        if (horizontal != 0 && vertical != 0) {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);

        UpdateAnimation();


        
    }

    private void UpdateAnimation() {
        if (horizontal > 0) {
            //right
            sprite.sprite = animations[2];
            direction = 0;
        }
        else if (horizontal < 0) {
            //left
            sprite.sprite = animations[3];
            direction = 1;
        }
        else if (vertical > 0) {
            //up
            sprite.sprite = animations[0];
            direction = 2;
        }
        else if (vertical < 0) {
            //down
            sprite.sprite = animations[1];
            direction = 3;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Enemy") {
            //Game Over
            SceneManager.LoadScene("GameOver");
        }
    }

    private void ShootFireball() {
        canShoot = false;
        Vector3 spawnPosition = new Vector3(transform.position.x,transform.position.y + 1, transform.position.z);
        GameObject newFireBall = Instantiate(fireball, spawnPosition, transform.rotation);
        Rigidbody2D newFireBallRB = newFireBall.GetComponent<Rigidbody2D>();
        Transform newFireBallTransform = newFireBall.GetComponent<Transform>();
        switch(direction) {
            case 0:
                //right
                newRotationZ = -90;
                Quaternion newRotationRight = Quaternion.Euler(0,0, newRotationZ);
                newFireBall.transform.rotation = newRotationRight;
                newFireBallRB.AddForce(transform.right * shootSpeed, ForceMode2D.Impulse);
                break;
            case 1:
                //left
                newRotationZ = 90;
                Quaternion newRotationLeft = Quaternion.Euler(0,0, newRotationZ);
                newFireBall.transform.rotation = newRotationLeft;
                newFireBallRB.AddForce(transform.right * -shootSpeed, ForceMode2D.Impulse);
                
                break;
            case 2:
                //up
                newRotationZ = 0;
                Quaternion newRotationUp = Quaternion.Euler(0,0, newRotationZ);
                newFireBall.transform.rotation = newRotationUp;
                newFireBallRB.AddForce(transform.up * shootSpeed, ForceMode2D.Impulse);
                
                break;
            case 3:
                //down
                newRotationZ = -180;
                Quaternion newRotationDown = Quaternion.Euler(0,0, newRotationZ);
                newFireBall.transform.rotation = newRotationDown;
                newFireBallRB.AddForce(transform.up * -shootSpeed, ForceMode2D.Impulse);
                break;
        }
    }

    public IEnumerator StartCoolDown() {
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
