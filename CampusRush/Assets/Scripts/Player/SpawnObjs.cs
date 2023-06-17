using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjs : MonoBehaviour{
    private List<GameObject> children;
    private GameObject player = null;
    // Start is called before the first frame update
    void Start(){
        if (children == null){
            children = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        }
        if (player == null){
            player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame


    void LateUpdate(){
        GameObject enemy;
        for (int i=0;i<children.Count;i++){
            enemy = children[i];
            if(enemy){
                if (Mathf.Sqrt(
                ((enemy.transform.localPosition.x-player.transform.localPosition.x)*(enemy.transform.localPosition.x-player.transform.localPosition.x))
                -((enemy.transform.localPosition.y-player.transform.localPosition.y)*(enemy.transform.localPosition.y-player.transform.localPosition.y))
                ) >= 10.5){
                    enemy.SetActive(false);
                }else{
                    enemy.SetActive(true);
                }
            }else{
                children.Remove(enemy);
                i--;
            }
        }
    }

    public void removeChild(GameObject child){
        children.Remove(child);
    }
}
