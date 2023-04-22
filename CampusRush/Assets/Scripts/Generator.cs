using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] protected GameObject generate;
    [SerializeField] protected Vector3 offset = Vector3.zero;
    [SerializeField] protected bool die = true;
    protected Vector3 pos;
    // Start is called before the first frame update
    void Start(){
        pos = new Vector3{};
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player"){
            GameObject clone = Instantiate(generate,transform.localPosition + offset,Quaternion.identity);
            if (die){
                Destroy(this.gameObject);
            }
        }
    }
}
