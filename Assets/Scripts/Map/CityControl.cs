using UnityEngine;

public class CityControl : MonoBehaviour
{
    private Transform CityTr;

    // Information of the corresponding level
    [SerializeField] private string LevelSceneName;
    [SerializeField] private Sprite LevelImage;
    [SerializeField] private string LevelDescription;
    [SerializeField] private string LevelRegionName;

    // Control component of the level brief window
    private LevelBriefWindowControl BriefControl;

    void Start()
    {
        CityTr = GetComponent<Transform>();
        BriefControl = GameObject.Find("Canvas").transform.Find("Level Brief Window").gameObject.GetComponent<LevelBriefWindowControl>();
    }

    // When selected, focus camera on current city, and show level brief
    public void Select()
    {
        // Disabled city could not be selectecd
        if (!GameStatus.GetRegionEnableStatus(LevelRegionName))
            return;

        var GameCam = Camera.main.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>();
        GameCam.Follow = CityTr;
        BriefControl.DisplayLevel(new LevelInformation { SceneName = LevelSceneName, Image = LevelImage, Description = LevelDescription, RegionName = LevelRegionName });
    }
}
