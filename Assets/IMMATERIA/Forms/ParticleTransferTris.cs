﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleTransferTris : IndexForm {

  public override void SetCount( Form parent ){
    toIndex = parent;
    count = (parent.count  /4 ) * 3 * 2;
  }

  public override void Embody(Form parent){

    int[] values = new int[count];
    int index = 0;

    // 1-0
    // |/|
    // 3-2
    for( int i = 0; i < count/6; i++ ){
        int bID = i * 4;
        values[ index ++ ] = bID + 0;
        values[ index ++ ] = bID + 1;
        values[ index ++ ] = bID + 3;
        values[ index ++ ] = bID + 2;
        values[ index ++ ] = bID + 3;
        values[ index ++ ] = bID + 0;
    }
    SetData(values);
  }

}

