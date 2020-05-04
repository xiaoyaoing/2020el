using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CityNavButtonControl : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject City;
    private Transform CityPosition;
    private Button CityButton;
    private CityControl cityControl;

    // When clicked, select corresponding city
    void Start()
    {
        CityButton = GetComponent<Button>();
        CityButton.onClick.AddListener(City.GetComponent<CityControl>().Select);
        CityPosition = City.GetComponent<Transform>();
        cityControl = City.GetComponent<CityControl>();
        CityButton.interactable = false;
    }

    void Update()
    {
        if (GameStatus.GetRegionEnableStatus(cityControl.GetRegionName()))
            CityButton.interactable = true;
    }

    // When mouse-on, focus camera on corresponding city
    public void OnPointerEnter(PointerEventData eventData)
    {
        Camera.main.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>().Follow = CityPosition;
    }
}
