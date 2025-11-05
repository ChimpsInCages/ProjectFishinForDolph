using UnityEngine;

public class scriptFishController : MonoBehaviour
{
    public float fishSpeedMin = 3;
    public float fishSpeedMax = 10;
    private Rigidbody2D fishRB;
    private Vector2 screenEdges;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fishRB = this.GetComponent<Rigidbody2D>();
        fishRB.linearVelocity = new Vector2 (Random.Range(fishSpeedMin, fishSpeedMax), 0);
        screenEdges = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenEdges.x * 1.5) 
        {
            Destroy(this.gameObject);
        }
    }
}
