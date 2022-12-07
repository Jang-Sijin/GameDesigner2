using System;
using UnityEngine;

public class DataManager
{
     public HonkaiImpact3rdExcelData ExcelData;

     public void Init()
     {
          if (ExcelData == null)
               ExcelData = Resources.Load<HonkaiImpact3rdExcelData>(DefinePath.ExcelHonkaiDB);
     }

     public bool IsLoaded()
     {
          if (ExcelData == null)
               return false;

          return true;
     }
}
