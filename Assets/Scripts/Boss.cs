using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float moveSpeed = 7f;
    private float jumpForce = 15f;
    private float actionDuration = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float groundCheckRadius = 0.2f;
    public bool isActive = false;
    private bool isJump;
    private bool isWalk;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int actionCounter = 0;
    private string currentPhase = "jump";
    private int actionsCompleted = 0;
    private int direction = 1;
    private bool isPerformingAction = false;
    private Animator animator;
    

    public GameObject[] HPBar;
    private int HPLeft = 3;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Whip")){
            HPLeft--;
            HPBar[HPLeft].SetActive(false);
            if(HPLeft == 0){
                foreach (GameObject obj in GameManager.Instance.ElementsCanvaVictoria){
                obj.SetActive(true);
                }
                GameManager.Instance.HighScore = GameManager.Instance.numberScore;
                Destroy(gameObject);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PerdreVida();
        }
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MovementPattern());
        foreach (GameObject HP in HPBar)
        {
            HP.SetActive(false);
        }
    }

    void Update()
    {
        if(currentPhase == "jump"){
            isJump = true;
            isWalk = false;
        }
        else if (currentPhase == "move"){
            isJump = false;
            isWalk = true;
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        if (direction < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (direction > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        animator.SetBool("Jump", isJump);
        animator.SetBool("Walk", isWalk);
    }

    IEnumerator MovementPattern()
    {   
        yield return new WaitUntil(() => isActive);
        while (isActive) 
        {
            currentPhase = "jump";
            actionsCompleted = 0;
            
            while (actionsCompleted < 2)
            {
                yield return new WaitUntil(() => isGrounded && !isPerformingAction);
                
                direction = (actionCounter % 2 == 0) ? -1 : 1;
                actionCounter++;
                
                Jump();
                actionsCompleted++;
                
                yield return new WaitUntil(() => isGrounded);
                yield return new WaitForSeconds(0.5f); 
            }
            
            currentPhase = "move";
            actionsCompleted = 0;
            
            while (actionsCompleted < 2)
            {
                yield return new WaitUntil(() => isGrounded);
                
                direction = (actionCounter % 2 == 0) ? -1 : 1;
                actionCounter++;
                
                StartCoroutine(Move());
                actionsCompleted++;
                
                yield return new WaitUntil(() => !isPerformingAction);
                yield return new WaitForSeconds(0.5f); 
            }
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(moveSpeed * direction, jumpForce);
            isPerformingAction = true;
            StartCoroutine(ResetActionFlag());
        }
    }
    
    IEnumerator Move()
    {
        isPerformingAction = true;
        
        float timeElapsed = 0;
        while (timeElapsed < actionDuration)
        {
            rb.linearVelocity = new Vector2(moveSpeed * direction, rb.linearVelocity.y);
            
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);        
        isPerformingAction = false;
    }
    
    private IEnumerator ResetActionFlag()
    {
        yield return new WaitUntil(() => isGrounded);
        yield return new WaitForSeconds(0.1f); 
        isPerformingAction = false;
    }


} 

