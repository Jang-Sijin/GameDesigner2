using System;
using UnityEngine;

public class DataManager
{
     public HonkaiImpact3rdData ExcelData;

     public void Init()
     {
          if (ExcelData == null)
               ExcelData = Resources.Load<HonkaiImpact3rdData>(DefinePath.ExcelHonkaiDB);
     }

     public bool IsLoaded()
     {
          if (ExcelData == null)
               return false;

          return true;
     }
     
     public int GetCharacterSheetAbilityId(int id, int abilityCount)
     {
          int returnValue = 0;
        
          switch (abilityCount)
          {
               case 1:
                    returnValue = Managers.DataManager.ExcelData.characterSheet[id].abilityId1;
                    break;
               case 2:
                    returnValue = Managers.DataManager.ExcelData.characterSheet[id].abilityId2;
                    break;
               case 3:
                    returnValue = Managers.DataManager.ExcelData.characterSheet[id].abilityId3;
                    break;
               case 4:
                    returnValue = Managers.DataManager.ExcelData.characterSheet[id].abilityId4;
                    break;
               case 5:
                    returnValue = Managers.DataManager.ExcelData.characterSheet[id].abilityId5;
                    break;
               case 6:
                    returnValue = Managers.DataManager.ExcelData.characterSheet[id].abilityId6;
                    break;
          }

          return returnValue;
     }
}
