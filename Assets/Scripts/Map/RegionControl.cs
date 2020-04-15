using UnityEngine;

public class RegionControl : MonoBehaviour
{
    private string CurrentRegion;
    private SpriteRenderer Renderer;
    private float FadeinTime = 3f;

    void Start()
    {
        CurrentRegion = name;
        Renderer = GetComponent<SpriteRenderer>();
        if (!GameStatus.GetRegionInfectionStatus(CurrentRegion))
            Renderer.enabled = false;
    }

    void Update()
    {
        if (GameStatus.GetRegionInfectionStatus(CurrentRegion) && Renderer.enabled == false)
        {
            Renderer.enabled = true;
            Renderer.color = new Color(Renderer.color.r, Renderer.color.g, Renderer.color.b, 0);
        }
        if (Renderer.color.a < 1)
            Renderer.color = new Color(Renderer.color.r, Renderer.color.g, Renderer.color.b, Renderer.color.a + 1 * Time.deltaTime / FadeinTime);
    }
}
