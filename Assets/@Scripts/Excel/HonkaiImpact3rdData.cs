using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class HonkaiImpact3rdData : ScriptableObject
{
    public List<CharacterEntity> characterSheet;
    public List<CharacterAttributeEntity> attributeSheet;
    public List<CharacterAbilityEntity> abilitySheet;
    public List<CharacterRankEntity> rankSheet;
}