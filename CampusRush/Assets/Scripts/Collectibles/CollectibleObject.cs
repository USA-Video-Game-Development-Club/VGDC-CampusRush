//Author: Rhiannon Strickland
//Date: April 4, 2023
//This is put onto the collectible prefab
//to allow for collectibles to be used in game.
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    [SerializeField]
    CollectibleSO item;
    public int score = 1;
    private GameObject[] uiEle = new GameObject[5];
    private GameObject canvas;

    public AnimationCurve floatCurve; //used to control the floating animation
    private float curvePosition; //the current position of the X on the float curve
    private Vector2 orgin; //the default location of the collectibles when starting a game


    private void Awake()
    {
        //gets player current location
        orgin = transform.position;

        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = item.icon;
        uiEle = GameObject.FindGameObjectsWithTag("UI");
        foreach (GameObject obj in uiEle){
            if (obj.name == "Canvas"){
                canvas = obj;
            }
        }
    }

    private void Update()
    {
        //keeps number between 0 and 1
        curvePosition += Time.deltaTime;
        curvePosition %= 2f;

        //animates pickup items to float in place
        transform.position = new Vector2(transform.position.x, orgin.y + floatCurve.Evaluate(curvePosition));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !collision.isTrigger)//Make sure the player has this tag, or the script won't work!
        {
            Debug.Log("Found the player!");
            SendPowerUpData(item.id, collision); //sends data about poweup to player
            canvas.GetComponent<ScoreTracker>().AddPoints(score);
            CollectibleInventory.instance.AddCollectible(item);
            Destroy(gameObject);
        }
    }

    //used to make changes to the player to when the player has been given a powerup
    private void SendPowerUpData(int id, Collider2D collision)
    {
        switch(id) //the id of the powerup
        {
            case 2: //double jump powerup
            {
                collision.gameObject.GetComponent<PlayerMovement>().canDoubleJump = true;
                break;
            }

        }
    }
}
