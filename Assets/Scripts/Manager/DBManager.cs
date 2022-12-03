using UnityEngine;

public class DBManager : MonoBehaviour
{
    public static DBManager Instance;
    public HonkaiImpact3rdDB DB;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != null)
            Destroy(this.gameObject);
    }
}
