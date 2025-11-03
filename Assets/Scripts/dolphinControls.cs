using UnityEngine;
using Unity;
using UnityEngine.EventSystems;


public class dolphinControls : MonoBehaviour
{
    public GameObject playerDolphin;
    
    
    public Rigidbody2D dolphinRB;
    public Transform dolphinTransform;
    
    public int dolphinSpeed;
    public float dolphinHorizontalinput;
    
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
    }

    // Update is called once per frame
    void Update()
    {
        dolphinHorizontalinput = Input.GetAxisRaw("Horizontal");
        moveDirection = dolphinTransform.right * dolphinHorizontalinput;
        dolphinRB.AddForce(moveDirection * dolphinSpeed * 5f, ForceMode2D.Force);
       
        
    }
   
}