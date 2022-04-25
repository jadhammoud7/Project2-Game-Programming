using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatsFactoryWithPooling : MonoBehaviour
{
    [SerializeField] Transform BatsParent;
    [SerializeField] GameObject batToInstantiate;
    [SerializeField] List<GameObject> myPool = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(BatsParent.transform.childCount);
        foreach(Transform obj in BatsParent){
            obj.gameObject.SetActive(false);
            myPool.Add(obj.gameObject);
            Debug.Log("Object added to Pool");
        }
    }

    public IEnumerator addToPool(GameObject obj){
        myPool.Add(obj);//adding object to pool list
        obj.transform.SetParent(BatsParent);//set object to be child of BatsParent
        Debug.Log("Object is now child of BatsParent");
        obj.transform.position = Vector3.zero;//set position of game object to  (0,0,0)
        obj.SetActive(false);//setting game object again to false 
        yield return new WaitForSeconds(1.0f);
    }

    void GenerateBats(){
        int random_index = Random.Range(0, myPool.Count);
        GameObject game_object = myPool[random_index];//choosing random game object from pool list
        myPool.Remove(game_object);//remove game object from list
        game_object.transform.SetParent(this.transform);//bats factory becomes parent for game object
        game_object.transform.position = this.transform.position;
        Debug.Log("Added object to be child of BatsParent");
        game_object.GetComponent<Rigidbody>().velocity = Vector3.up * 10;//velocity of game object upwards
        game_object.transform.rotation = Quaternion.identity;//setting no rotation for game object
        game_object.SetActive(true);//setting visibility true for game object
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player collided with me!");
            if(myPool.Count == 0){//if pool is empty
                GameObject obj = Instantiate(batToInstantiate, transform.position, transform.rotation) as GameObject;//instantiate game object batToInstantiate
                obj.transform.SetParent(this.transform);//set the instantiated object to be child of the BatsFactory(this)
                StartCoroutine("addToPool", obj);//start coroutine addToPool
                Debug.Log("Started coroutine");
            }
            else{//if pool is not empty
                GenerateBats();//generate bats
                Debug.Log("Generated bats");
            }
        }
    }
}
