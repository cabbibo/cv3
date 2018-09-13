using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hair: Form {

  public int length;
  [HideInInspector] public int numHairs;

  public override void SetStructSize( Form parent ){ structSize = 16; }

  public override void SetCount( Form parent ){
    numHairs = parent.count;
    count = numHairs * length;
  }

}

