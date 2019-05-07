using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour {

    
    //NEW
    public Vector2 movementDirection;
    public float movementSpeed;
    public float speed = 1.0f;
    public float shootingSpeed = 1.0f;
    public float aimingPenlaty = 1.0f;

    private Rigidbody2D body;
    public Animator animator;

    public bool endOfAiming;
    public bool isAiming;

    public GameObject bullet;
    public GameObject door;

    private Vector2 shootDirection;

    public int Vida = 9;
    public int Balas = 100;
    public int Llaves = 00;
    public int neighbours = 10;
    public int neighboursGet = 0;
    public float iframes = 1.5f;
    public float timeIframe = 0.0f;
    public bool doonce = false;
    //UI
    public life[] lifes;
    public TextMeshProUGUI municion;
    public TextMeshProUGUI item;
    public Data data;
    

    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();        
        municion.text = Balas.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        timeIframe += Time.deltaTime;
        ProcessInputs();
        Move();
        Animate();
        Shoot();
        if(neighbours <= 0 && doonce == false)
        {
            doonce = true;
            Instantiate(door, transform.position + new Vector3(1,0,0), Quaternion.identity);
            data.neighbours = neighboursGet;            
        }

	}


    void ProcessInputs()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        endOfAiming = Input.GetKeyUp(KeyCode.Z);
        isAiming = Input.GetKey(KeyCode.Z);
        if (isAiming)
        {
            movementSpeed *= aimingPenlaty;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            RecoverLife();
        }
    }
    void Move()
    {
        body.velocity = movementDirection * movementSpeed * speed;
    }
    void Animate()
    {
        if(movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }        
        animator.SetFloat("Speed", movementSpeed);
        if (isAiming) {
            animator.SetFloat("AimingState", 0.5f);
        }
        else {
            animator.SetFloat("AimingState", 0.0f);
        }
    }
    void Shoot()
    {
        
        if (movementDirection != Vector2.zero)
        {
            if(movementDirection.x > 0) { shootDirection.x = Mathf.Ceil(movementDirection.x) * 1.0f; }
            else { shootDirection.x = Mathf.Floor(movementDirection.x) * 1.0f; }
            if (movementDirection.y > 0) { shootDirection.y = Mathf.Ceil(movementDirection.y) * 1.0f; }
            else { shootDirection.y = Mathf.Floor(movementDirection.y) * 1.0f; }
            
        }
        shootDirection.Normalize();

        if (endOfAiming)
        {
            GameObject proy = Instantiate(bullet, transform.position, Quaternion.identity);
            proy.GetComponent<Rigidbody2D>().velocity = shootDirection * shootingSpeed;
            proy.transform.Rotate(0, 0, Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg);
            Destroy(proy, 0.6f);
            Tshoot();
        }
    }
    public void HideSprite()
    {
        SpriteRenderer a = GetComponent<SpriteRenderer>();
        a.enabled = false;
    }
    public void Hit()
    {
        if(Vida>=0 && timeIframe > iframes)
        {
            lifes[Vida].Nofull();
            Vida--;
            timeIframe = 0;
        }
        
    }
    public void RecoverLife()
    {
        for(int i = 0; i< lifes.Length; i++)
        {
            lifes[i].Restore();
        }
        Vida = 9;
    }
    public void Tshoot()
    {
        Balas--;
        municion.text = Balas.ToString();
    }
}



