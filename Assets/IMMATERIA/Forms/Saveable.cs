using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Saveable : MonoBehaviour {

  public Form form;
  public string fileName;



  public void Save( string name ){

    BinaryFormatter bf = new BinaryFormatter();
    FileStream stream = new FileStream(Application.dataPath + "/"+name+".dna",FileMode.Create);

    if( form.intBuffer ){
      int[] data = form.GetIntDNA();
      bf.Serialize(stream,data);
    }else{
      float[] data = form.GetDNA();
      bf.Serialize(stream,data);
    }

    stream.Close();
  }
  public void Load(string name){
    if( File.Exists(Application.dataPath + "/"+name+".dna")){
      
      BinaryFormatter bf = new BinaryFormatter();
      FileStream stream = new FileStream(Application.dataPath + "/"+name+".dna",FileMode.Open);

      if( form.intBuffer ){
        int[] data = bf.Deserialize(stream) as int[];
        form.SetDNA(data);
      }else{
        float[] data = bf.Deserialize(stream) as float[];
        form.SetDNA(data);
      }

      stream.Close();
    }else{
      print("Why would you load something that doesn't exist?!??!?");
    }
  }




}
