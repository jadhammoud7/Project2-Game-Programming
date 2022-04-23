using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SerializationSaving : MonoBehaviour
{

    [SerializeField] GameObject player;
    float x=0;
    float y=0;
    float z=0;
    [SerializeField] GameObject InstructionsUI;
    SaveData data;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        x=player.transform.position.x;
        y=player.transform.position.y;
        z=player.transform.position.z;
        
    }
    public void SaveGame(){
        Debug.Log("player position is: " +player.transform.position);
        BinaryFormatter bf=new BinaryFormatter();
        FileStream file=File.Create(Application.persistentDataPath + "/MySavedData.dat");
        SaveData data=new SaveData();
        data.x=x;
        data.y=y;
        data.z=z;
        bf.Serialize(file,data);
        file.Close();
        Debug.Log("Saved Position of the player");


    }
    public void LoadGame(){
        if(File.Exists(Application.persistentDataPath + "/MySavedData.dat")){
            InstructionsUI.SetActive(false);
            Time.timeScale=1f;
            BinaryFormatter bf=new BinaryFormatter();
            FileStream file=File.Open(Application.persistentDataPath + "/MySavedData.dat",FileMode.Open);
            SaveData data =(SaveData)bf.Deserialize(file);
            Debug.Log("x is: "+data.x+" y is: "+data.y+" z is: "+data.z);
            player.transform.position= new Vector3(data.x,data.y,data.z);
        }
    }
    // public void QuitGame(){
    //     data.x=-9.3f;
    //     data.y=-0.02f;
    //     data.z=0;
    // }
}
