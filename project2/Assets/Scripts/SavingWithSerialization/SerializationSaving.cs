using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class SerializationSaving : MonoBehaviour
{

    // [SerializeField] GameObject player;
    [Tooltip("The transform of the player")]
    [SerializeField] Transform player;//getting the position of the player
    float x=0,y=0,z = 0;
    [Tooltip("The transform of slender1")]
    [SerializeField] Transform slender1;
    float xs1=0,ys1=0,zs1 = 0;
    [Tooltip("The transform of slende2")]
    [SerializeField] Transform slender2;
    float xs2=0,ys2=0,zs2 = 0;
    [Tooltip("The transform of slender2")]
    [SerializeField] Transform slender3;
    float xs3=0,ys3=0,zs3 = 0;
    [Tooltip("The transform of slender2")]
    [SerializeField] Transform slender4;
    float xs4=0,ys4=0,zs4 = 0;
    [Tooltip("Instructions canvas")]
    [SerializeField] GameObject InstructionsUI;
    SaveData data;


    float current_timer=0;
    [Tooltip("The timer scene 2 script in the timer canvas")]
    [SerializeField]
    Timer_Scene2 GetTime;

    int current_score=0;
    [Tooltip("The score of the pumpkin bar")]
    [SerializeField]
    pumkin_bar GetScore;

    int current_health=0;
    [Tooltip("The health of the player")]
    [SerializeField]
    health_bar GetHealth;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        x = player.position.x;//keep updating the position of the player
        y = player.position.y;
        z = player.position.z;
        current_timer = GetTime.getTimer();//update timer
        current_score = GetScore.getNumber_of_pumkins();//update pumpkins collected
        current_health = GetHealth.getNumber_of_health();//update health of player
        //slender1
        xs1=slender1.position.x;//update positions of all slenders
        ys1=slender1.position.y;
        zs1=slender1.position.z;
        //slender2
        xs2=slender2.position.x;
        ys2=slender2.position.y;
        zs2=slender2.position.z;
        //slender3
        xs3=slender3.position.x;
        ys3=slender3.position.y;
        zs3=slender3.position.z;
        //slender4
        xs4=slender4.position.x;
        ys4=slender4.position.y;
        zs4=slender4.position.z;        
        



    }
    public void SaveGame()//when the save button is pressed
    {
        Debug.Log("player position is: " + player.transform.position);
        BinaryFormatter bf = new BinaryFormatter();//display everything as binary
        FileStream file = File.Create(Application.persistentDataPath + "/MySavedData.dat");//create file
        SaveData data = new SaveData();//save data
        data.position[0] = x;//fill the array position with values of x y and z
        data.position[1] = y;
        data.position[2] = z;

        data.timer = current_timer;
        data.score = current_score;
        data.health = current_health;

        //slender1
        data.slender1[0]=xs1;
        data.slender1[1]=ys1;
        data.slender1[2]=zs1;
        //slender2
        data.slender2[0]=xs2;
        data.slender2[1]=ys2;
        data.slender2[2]=zs2;
        //slender3
        data.slender3[0]=xs3;
        data.slender3[1]=ys3;
        data.slender3[2]=zs3;
        //slender4
        data.slender4[0]=xs4;
        data.slender4[1]=ys4;
        data.slender4[2]=zs4;
    
        
        bf.Serialize(file, data);//add data to the file as binary
        file.Close();//close file
        Debug.Log("Saved Position of the player");


    }
    public void LoadGame()//when load game is pressed
    {
        if (File.Exists(Application.persistentDataPath + "/MySavedData.dat"))//if file exists, which means the player saved the game previously
        {
            InstructionsUI.SetActive(false);//disable instructions menu
            Time.timeScale = 1f;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySavedData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);

            GetTime.setTimer(data.timer);//change the current values to be equal to the saved ones previously stored
            GetScore.setAmountNumber(data.score);
            GetHealth.setAmountNumber(data.health);

            Vector3 current_position;
            current_position.x=data.position[0];
            current_position.y=data.position[1];
            current_position.z=data.position[2];
            player.position=new Vector3(current_position.x,current_position.y,current_position.z);



            //slender1
            Vector3 slender1_position;//set all the positions of the slenders as that saved for each
            slender1_position.x=data.slender1[0];
            slender1_position.y=data.slender1[1];
            slender1_position.z=data.slender1[2];
            slender1.position=new Vector3(slender1_position.x,slender1_position.y,slender1_position.z);

            //slender2
            Vector3 slender2_position;
            slender2_position.x=data.slender2[0];
            slender2_position.y=data.slender2[1];
            slender2_position.z=data.slender2[2];
            slender2.position=new Vector3(slender2_position.x,slender2_position.y,slender2_position.z);
            //slender3
            Vector3 slender3_position;
            slender3_position.x=data.slender3[0];
            slender3_position.y=data.slender3[1];
            slender3_position.z=data.slender3[2];
            slender3.position=new Vector3(slender3_position.x,slender3_position.y,slender3_position.z);
            //slender4
            Vector3 slender4_position;
            slender4_position.x=data.slender4[0];
            slender4_position.y=data.slender4[1];
            slender4_position.z=data.slender4[2];
            slender4.position=new Vector3(slender4_position.x,slender4_position.y,slender4_position.z);





           




        }
    }

}
