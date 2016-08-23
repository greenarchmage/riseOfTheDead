using UnityEngine;
using System.Collections;
using Assets.Scripts.Utility;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    //Test Stuff
    public GameObject EndTarget;
    public GameObject Canvas;
    public GameObject Spawner;
    private string scoreText = "Current losses:";
    private int score = 0;
    private Player p1;

    //NON test stuff
    public static GameController Instance;

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {

        //Test of players
        p1 = new Player("Simba");
        ChangeScore(0);
    }
	
	// Update is called once per frame
	void Update () {
        // Test of unit spawner
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawner.GetComponent<UnitSpawner>().AddUnit();
        }

        // Test select towers
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if(hit.collider != null)
            {
                if(hit.collider.GetComponent<Tower>() != null)
                {
                    hit.collider.GetComponent<Tower>().Owner = p1;
                }
                if(hit.collider.gameObject.GetComponent<TowerGround>() != null)
                {
                    Debug.Log("Created Tower");
                    Instantiate(Resources.Load("Prefabs/Tower"), hit.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
	}

    public void ChangeScore(int val)
    {
        score += val;
        // get the text child and update it
        Canvas.transform.GetChild(0).GetComponent<Text>().text = scoreText + " " + score;
    }
}
