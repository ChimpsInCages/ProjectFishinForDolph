using UnityEngine;
using Unity;
using UnityEngine.EventSystems;


public class scriptBoatControls : MonoBehaviour
{
    public GameObject playerBoat;
    public GameObject boatNet;
    public GameObject sceneManager;
    public scriptSceneManager scriptSceneManager;
    public Rigidbody2D boatRB;
    public Transform boatTransform;
    public Transform netTransform;
    public int boatSpeed;
    public float boatHorizontalinput;
    private bool canNet;
    private float netTimer;
    Vector2 moveDirection;
    Vector2 netMove;
    CircleCollider2D netCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerBoat == null)
        {
            playerBoat = GameObject.Find("Boat Parent");
            Debug.Log("Player has successfully been found");
        }
            boatRB = playerBoat.GetComponent<Rigidbody2D>();
            scriptSceneManager = sceneManager.GetComponent<scriptSceneManager>();
        netTransform = boatNet.transform;
        netMove = netTransform.localPosition;
        netCollider = playerBoat.GetComponent<CircleCollider2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        boatHorizontalinput = Input.GetAxisRaw("Horizontal");
        moveDirection = boatTransform.right * boatHorizontalinput; 
        boatRB.AddForce(moveDirection * boatSpeed * 5f, ForceMode2D.Force);
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            scriptSceneManager.resetAFKTimer();
        }
        if (Input.GetButtonDown("Submit"))
        {   
            if (scriptSceneManager.gameTimer < 178)
            {
                scriptSceneManager.resetGame();
            }
            else
            {
                scriptSceneManager.gameStart();
                scriptSceneManager.resetAFKTimer();
            }
            

        }
        if (Input.GetButtonDown("Jump"))
        {
            if(canNet)
            {
                netGrab();
                Debug.Log("Net");
                scriptSceneManager.resetAFKTimer();

            }
        }
    }
    private void FixedUpdate()
    {
        if (netTimer <= 0)
        {
            canNet = true;
            boatNet.SetActive(false);
            netCollider.enabled = false;
            
        }
        if (netTimer > 0)
        {      
            canNet = false;
            netTimer = netTimer - Time.deltaTime;
        }
    }
    void netGrab()
    {
        netTimer = 2;
        boatNet.SetActive(true);
        netCollider.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fish")
        {
            other.gameObject.SetActive(false);
            scriptSceneManager.addScore(100);
        }
    }
}
