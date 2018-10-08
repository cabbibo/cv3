using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MutatingTris : IndexForm {


  private int[] values;
  public override void SetCount( Form parent ){
    Mesh mesh = ((MutatingVerts)toIndex).mesh;
    values = mesh.triangles;
    count = values.Length;
  }

  public override void Embody(Form parent){
    SetData(values);
  }

}

