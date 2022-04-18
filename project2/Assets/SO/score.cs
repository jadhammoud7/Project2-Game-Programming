using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Score Container",menuName ="overall score",order =1)]
public class score : ScriptableObject
{
    // Start is called before the first frame update
public int Overllscore=0;
public int getScore(){
    return Overllscore;
}
}
