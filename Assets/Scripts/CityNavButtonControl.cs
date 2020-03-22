using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CityNavButtonControl : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private GameObject City;
    private Transform CityPosition;

    // When clicked, select corresponding city
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(City.GetComponent<CityControl>().Select);
        CityPosition = City.GetComponent<Transform>();
    }

    // When mouse-on, focus camera on corresponding city
    public void OnPointerEnter(PointerEventData eventData)
    {
        Camera.main.GetComponentInChildren<Cinemachine.CinemachineVirtualCamera>().Follow = CityPosition;
    }
}
