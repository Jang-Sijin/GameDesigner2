using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class HonkaiImpact3rdDB : ScriptableObject
{
    public CharacterEntity[] characterSheet;
    public CharacterAttributeEntity[] attributeSheet;
    public CharacterAbilityEntity[] abilitySheet;
    public CharacterRankEntity[] rankSheet;
}