using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcornGen : Generator{
    public Vector2 direction = Vector2.down;
    public float grav = 0f;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "Player"){
        GameObject clone = Instantiate(generate,transform.localPosition + offset,Quaternion.identity);
        clone.GetComponent<AcornMove>().grav = grav;
        clone.GetComponent<AcornMove>().speed = speed;
        clone.GetComponent<AcornMove>().direction = direction;
        if (die){
            Destroy(this.gameObject);
        }
    }
}
}
