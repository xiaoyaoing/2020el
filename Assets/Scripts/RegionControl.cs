using UnityEngine;

public class RegionControl : MonoBehaviour
{
    private string CurrentRegion;
    SpriteRenderer sr;//

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();//

        CurrentRegion = name;
        if (!GameStatus.GetRegionInfectionStatus(CurrentRegion))
            gameObject.SetActive(false);

        if (string.Compare(GameStatus.GetLastInfectedRegion(), CurrentRegion) == 0)//
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
            //Debug.Log("infected");
        }
    }
    

    private void FixedUpdate()
    {
        if (sr.color.a < 1)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + 0.01f);
        }
    }
}
