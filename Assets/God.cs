using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class God :  MonoBehaviour  {
  
  public Cycle[] cycles;

  public void OnEnable(){
    for( int i = 0; i < cycles.Length; i++ ){
      cycles[i].Create();
    }

    for( int i = 0; i < cycles.Length; i++ ){
      cycles[i].OnGestate();
    }

     for( int i = 0; i < cycles.Length; i++ ){
      cycles[i].OnBirth();
    }



  }
 
  public void OnRenderObject(){
    for( int i = 0; i < cycles.Length; i++ ){
      if( cycles[i].created == true ){
        cycles[i].WhileAlive(1);
      }
    }
  }

  public void Update(){
    for( int i = 0; i < cycles.Length; i++ ){
      if( cycles[i].created == true ){
        cycles[i].WhileAlive(1);
      }
    }
  }

}



