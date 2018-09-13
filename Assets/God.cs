using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God :  MonoBehaviour  {
  
  public Cycle[] cycles;

  public void OnEnable(){
    for( int i = 0; i < cycles.Length; i++ ){
      cycles[i].Create();
    }
  }

  public void Update(){
    for( int i = 0; i < cycles.Length; i++ ){
      if( cycles[i].created == true ){
        cycles[i].WhileBirthing(1);
      }
    }
  }

}



