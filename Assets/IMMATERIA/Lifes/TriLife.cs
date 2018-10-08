using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriLife : CalcLife {
  
 public virtual void GetNumGroups(){
    numGroups = ((primaryForm.count/3)+((int)numThreads-1))/(int)numThreads;
  }

}
