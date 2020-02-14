using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{
    private int hp = 10;

    public void Recievedmg() 
    {  
        if (hp >=1 )hp--;
        if (hp == 0) Destroy(gameObject); 
    }

}
