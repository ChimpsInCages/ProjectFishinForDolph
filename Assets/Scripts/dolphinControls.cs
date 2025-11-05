using UnityEngine;
using Unity;
using UnityEngine.EventSystems;


public class dolphinControls : MonoBehaviour
{
    public GameObject playerDolphin;
    public GameObject sceneManager;
    public Rigidbody2D dolphinRB;
    public Transform dolphinTransform;
    
    public int dolphinSpeed;
    public float dolphinHorizontalInput;
    public float dolphinVerticalInput;
    scriptSceneManager scriptSceneManager;
    
    Vector2 moveDirection;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerDolphin == null)
        {
            playerDolphin = GameObject.Find("Dolphin Parent");
            Debug.Log("Player has successfully been found");
        }
        dolphinRB = playerDolphin.GetComponent<Rigidbody2D>();
        scriptSceneManager = sceneManager.GetComponent<scriptSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dolphinHorizontalInput = Input.GetAxisRaw("Horizontal2");
        dolphinVerticalInput = Input.GetAxisRaw("Vertical2");
        moveDirection = dolphinTransform.right * dolphinHorizontalInput + dolphinTransform.up * dolphinVerticalInput;
        dolphinRB.AddForce(moveDirection * dolphinSpeed * 5f, ForceMode2D.Force);
       
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fish")
        {
            other.gameObject.SetActive(false);
            scriptSceneManager.addScore(100);
        }
    }
}