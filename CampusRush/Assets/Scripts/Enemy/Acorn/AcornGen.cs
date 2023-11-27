using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornGen : Generator{
    public Vector2 direction = Vector2.down;
    public float grav = 0f;
    public float speed = 4f;
    public int num = 1;
    private int counter = 0;

    public float delaySet = 0; //the delay set between each acorn dropped if not destroyed.
    private float delayActive = 0; //stores how long until the next acorn is dropped


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        //counts down the delayActive to set an acorn be dropped again
        if (delayActive > 0)
        {
            delayActive -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && delayActive <= 0){
            GameObject clone = Instantiate(generate, transform.localPosition + transform.parent.transform.position + offset, Quaternion.identity);
            clone.GetComponent<AcornMove>().grav = grav;
            clone.GetComponent<AcornMove>().speed = speed;
            clone.GetComponent<AcornMove>().direction = direction;

            //sets delayActive
            delayActive = delaySet;

            if (die){
                Destroy(this.gameObject);
            }
            counter++;
        }
        if (counter == num){Destroy(this.gameObject);}
    }
}
