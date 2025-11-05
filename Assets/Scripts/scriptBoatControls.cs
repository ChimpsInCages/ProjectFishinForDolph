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
    public Rigidbody2D netRB;
    public Transform boatTransform;
    public Transform netTransform;
    public int boatSpeed;
    public int netSpeed = 2;
    public float boatHorizontalinput;
    public float netInput;
    private bool canNet;
    private float netTimer;
    CircleCollider2D netCollider;
    Vector2 moveDirection;
    //Vector2 netMove;
    Vector2 screenEdges;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerBoat == null)
        {
            playerBoat = GameObject.Find("Boat Parent");
            Debug.Log("Player has successfully been found");
        }
            boatRB = playerBoat.GetComponent<Rigidbody2D>();
            //netRB = boatNet.GetComponent<Rigidbody2D>();
            scriptSceneManager = sceneManager.GetComponent<scriptSceneManager>();
        netCollider = playerBoat.GetComponent<CircleCollider2D>();
        //netTransform = boatNet.transform;
        //netMove = netTransform.localPosition;
        screenEdges = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        boatNet.SetActive(false);
        canNet = true;
        netCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        boatHorizontalinput = Input.GetAxisRaw("Horizontal");
        moveDirection = boatTransform.right * boatHorizontalinput; 
        boatRB.AddForce(moveDirection * boatSpeed * 5f, ForceMode2D.Force);
        //netMove = netTransform.up * netInput;

        if (Input.GetButtonDown("Submit"))
        {
            
            scriptSceneManager.gameStart();
            
        }
        if (Input.GetButton("Jump"))
        {
            if(canNet)
            {
<<<<<<< Updated upstream
                netGrab();
=======
                //netInput = -1;
                scriptSceneManager.resetAFKTimer();
                netCast();
>>>>>>> Stashed changes

            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            netInput = 0;
            if (netTimer < 2)
            {
                netTimer = 1;   
            }
            
        }
    }
    private void FixedUpdate()
    {
        if (netTimer <= 0)
        {
            canNet = true;
            netTransform.localPosition = boatTransform.localPosition;
        }
        if (netTimer > 0)
        {
            canNet = false;
            netTimer = netTimer - Time.deltaTime;
            boatNet.SetActive(false);
            netCollider.enabled = false;
        }

    }
    void netCast()
    {
<<<<<<< Updated upstream
        netTimer = 2;
        netTransform.localPosition = new Vector2(netTransform.position.x, netTransform.position.y + 5);
=======
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
>>>>>>> Stashed changes
    }
}
