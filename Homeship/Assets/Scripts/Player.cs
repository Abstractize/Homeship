using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool[] Memories = {false,false,false,false};
    public float speed = 1;
    public float jumpVelocity = 6;
    private bool jump = true;
    Rigidbody rb;
    static int level = 1;

    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    #region Sigleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<Player>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }
    //Animaciones
    Animator anim;
    int moveHash = Animator.StringToHash("Movement");
    //Bullets
    public GameObject BulletSpawner;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        Animation();
        AxisInput();
        Win();
        Die();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Enemy")){
            this.TakeDamage(1f);
        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            anim.SetInteger("Movement", 0);
            jump = true;
        }
        if (collision.gameObject.tag.Equals("Memory"))
        {
            Destroy(collision.gameObject);
            for(int i = 0; i<Memories.Length; i++)
            {
                if (Memories[i] == false)
                {
                    Memories[i] = true;
                    break;
                }                    
            }
        }
    }

    //Animations
    void Animation()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        //Forward
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            anim.SetInteger("Movement", 1);
        //Back
        if (Input.GetKeyDown(KeyCode.S))
            anim.SetInteger("Movement", 2);
        //Jump
        if (Input.GetKey(KeyCode.Space) && jump)
        {
            anim.SetInteger("Movement", 3);
        }           
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S))
            anim.SetInteger("Movement", 0);
        //Throw
        if (Input.GetKey(KeyCode.E))
        {
            anim.SetInteger("Movement", 4);
        }
        
    }
    //Teclado
    //Otra Manera de Hacerlo
    void AxisInput()
    {
        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + transform.forward * speed);
        }
        //Back
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position - transform.forward * speed);
        }
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0f, -30, 0f) * Time.deltaTime));
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0f, 30, 0f) * Time.deltaTime));
        }
        //Jump
        if (Input.GetKey(KeyCode.Space) && jump)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
            jump = false;
        }
        //throw
        if (Input.GetKeyDown(KeyCode.E))
        {
            BulletSpawner.GetComponent<BulletSpawner>().Throw();
        }
    }
    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        ClampHealth();
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }
    void Die()
    {
        if (Health == 0)
            Destroy(this);
        //Change Scene
    }
    void Win()
    {
        if (Memories[0] && Memories[1] && Memories[2] && Memories[3])
            SceneManager.LoadScene(level++);       
    }
}
