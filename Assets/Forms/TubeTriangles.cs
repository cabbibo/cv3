using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TubeTriangles : Form {

  [ HideInInspector ] public int width;
  [ HideInInspector ] public int length;
  [ HideInInspector ] public int numTubes;
  public TubeVerts verts;


  public override void SetBufferType(){  intBuffer = true; }

  public override void SetStructSize( Form parent ){ structSize = 1; }

  public override void SetCount( Form parent ){
    numTubes = verts.numTubes;
    width = verts.width;
    length = verts.length;
    count = numTubes * width * (length-1) * 3 * 2;
  }

  public override void Embody(Form parent){

    int[] values = new int[count];
    int index = 0;
    for( int i = 0; i < numTubes; i++ ){
      for( int j = 0; j < width; j++ ){
        index ++;
      }
    }
    SetData(values);
  }

}

