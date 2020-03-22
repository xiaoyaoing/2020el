using UnityEngine;

public class RegionControl : MonoBehaviour
{
    private string CurrentRegion;

    void Start()
    {
        CurrentRegion = name;
        if (!GameStatus.GetRegionInfectionStatus(CurrentRegion))
            gameObject.SetActive(false);
    }
}
