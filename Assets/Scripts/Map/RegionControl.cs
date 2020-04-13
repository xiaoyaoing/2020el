using UnityEngine;

public class RegionControl : MonoBehaviour
{
    private string CurrentRegion;
    private SpriteRenderer Renderer;

    void Start()
    {
        CurrentRegion = name;
        Renderer = GetComponent<SpriteRenderer>();
        if (!GameStatus.GetRegionInfectionStatus(CurrentRegion))
            Renderer.enabled = false;
    }

    void Update()
    {
        if (GameStatus.GetRegionInfectionStatus(CurrentRegion))
            Renderer.enabled = true;
    }
}
