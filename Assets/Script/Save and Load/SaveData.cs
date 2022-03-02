using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData
{
  public static void SaveCheckPoint(Health current, CrystalText crystal, CheckPoint lastCheckPoint)
  {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/save.haha";
      FileStream stream = new FileStream(path, FileMode.Create);

      CheckPointData data = new CheckPointData(current, crystal, lastCheckPoint);

      formatter.Serialize(stream, data);
      stream.Close();
  }

  public static CheckPointData LoadCheckPoint()
  {
      string path = Application.persistentDataPath + "/save.haha";

      if(File.Exists(path))
      {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        CheckPointData data = formatter.Deserialize(stream) as CheckPointData;
        stream.Close();

        return data;
      }

      else
      {
          return null;
      }
  }

}
