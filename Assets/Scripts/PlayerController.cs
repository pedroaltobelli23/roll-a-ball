using UnityEngine;
// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI lifeText;
	public GameObject timerText;
	public GameObject winTextObject;
	public GameObject loseTextObject;
	public GameObject restartButton;
	public GameObject exitButton;
	public float TimeLeft;
    public bool TimerOn = false;
	public TextMeshProUGUI TimerTxt;
    private float movementX;
    private float movementY;
	private Rigidbody rb;
	private int count;
	private Vector3 movement;
	private int life;
	private bool stop = false;
	// At the start of the game..
	void Start ()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		count = 0;
		life = 3;

		SetCountText();
		SetLifeText();
		TimerOn = true;
        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
		loseTextObject.SetActive(false);
		restartButton.SetActive(false);
		exitButton.SetActive(false);
		timerText.SetActive(true);

	}

	void FixedUpdate ()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		if (stop==false)
		{
			movement = new Vector3 (movementX, 0.0f, movementY);
		}else{
			movement = new Vector3(0.0f,0.0f,0.0f);
		}

		rb.AddForce (movement * speed);
	}

	void Update()
    {
        if(TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                loseTextObject.SetActive(true);
                restartButton.SetActive(true);
                exitButton.SetActive(true);
                timerText.SetActive(false);
                TimeLeft = 0;
                TimerOn = false;
				stop = true;
            }
        }
    }

	void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

	void OnTriggerEnter(Collider other) 
	{
		// ..and if the GameObject you intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			if(stop==false){
				count = count + 1;
			}
			

			// Run the 'SetCountText()' function (see below)
			SetCountText ();
		}

		if (other.gameObject.CompareTag ("Cone"))
		{
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			if(stop==false){
				life = life - 1;
			}
			

			// Run the 'SetCountText()' function (see below)
			SetLifeText ();
		}
	}

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetCountText()
    {
        countText.text = "Boxes: " + count.ToString();

        if (count >= 16)
        {
            // Set the text value of your 'winText'
			count = 16;
            winTextObject.SetActive(true);
			restartButton.SetActive(true);
			exitButton.SetActive(true);
			timerText.SetActive(false);
			stop = true;
        }
    }

	void SetLifeText()
    {
        lifeText.text = "Lifes: " + life.ToString();

        if (life <= 0) 
        {
            // Set the text value of your 'winText'
			life = 0;
            loseTextObject.SetActive(true);
			restartButton.SetActive(true);
			exitButton.SetActive(true);
			timerText.SetActive(false);
			stop = true;
        }
    }
}
