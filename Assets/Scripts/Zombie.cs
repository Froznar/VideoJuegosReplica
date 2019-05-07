using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    [SerializeField]
    public float speed;
    [SerializeField]
    public float patrolSpeed;
    [SerializeField]
    private float actiontime;
    [SerializeField]
    public bool chasing;
    public bool spawning = true;
    public bool isDead = false;
    public bool destroy = false;
    public float chase_timer;

    [SerializeField]
    private float timer;
    private Transform target;
    public Animator animator;
    private Vector3 RandomPoint;
    Chase chaseCollider;
    ZombieCollide zombCollider;


    // Use this for initialization
    void Start () {
        target = GameObject.FindWithTag("MainCharacter").transform;
        chase_timer = 0;
        chasing = false;
        chaseCollider = GetComponentInChildren<Chase>();
        zombCollider = GetComponentInChildren<ZombieCollide>();

    }
	
	// Update is called once per frame
	void Update () {
        if(zombCollider != null &&zombCollider.dead == true)
        {
            Die();
        }
        if (destroy == true)
        {
            Destroy(gameObject);
        }
        if (spawning == false && isDead == false)
        {
            animator.SetBool("EndSpawn", true);
            timer += Time.deltaTime;
            chasing = chaseCollider.contact;
            if (chasing == true && chase_timer < 1.5)
            {
                Chase();
                chase_timer += Time.deltaTime;
                timer = 0;
            }
            else { Patrol(); }
            if (timer > actiontime)
            {
                RandomPoint = new Vector3(Random.Range(10, 20) / 10.0f, Random.Range(10, 20) / 10.0f, 0.0f);
                timer = 0;
                chasing = false;
                chase_timer = 0;
            }
        }
        
        
                
	}

    

    void Chase()
    {        
        Vector2 towards = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        Vector2 distance = transform.position - target.position;
        //face = distance;

        animator.SetFloat("Horizontal", -distance.x);
        animator.SetFloat("Vertical", -distance.y);
        animator.SetFloat("Magnitude", towards.magnitude);

        transform.position = towards;
    }

    void Patrol()
    {
        
        
        if (Random.Range(5, 20) % 2 == 0)
        {
            RandomPoint = RandomPoint + transform.position;
        }
        else
        {
            RandomPoint = RandomPoint - transform.position;
        }
        
        Vector2 towards = Vector2.MoveTowards(transform.position, RandomPoint, patrolSpeed * Time.deltaTime);
        Vector2 distance = transform.position - RandomPoint;
        //face = distance;

        animator.SetFloat("Horizontal", -distance.x);
        animator.SetFloat("Vertical", -distance.y);
        animator.SetFloat("Magnitude", towards.magnitude);

        transform.position = towards;
    }

    public void Die()
    {        
        isDead = true;
        animator.SetBool("Dead", true);      
    }
    
}
