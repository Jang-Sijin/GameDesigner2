[System.Serializable]
public class CharacterRankEntity
{
    public RankCategory rankId;
    public string imageName;
}

public enum RankCategory
{
    B,
    A,
    S,
}
