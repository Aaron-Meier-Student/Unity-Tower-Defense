using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace TowerDefense
{
    [RequireComponent(typeof(Button))]
    public class TowerButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        Button button;
        Player player;

        public GameObject towerPrefab;

        public static TowerButton hoveredButton;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);

            player = FindObjectOfType<Player>();
        }

        private void OnClick()
        {
            player.towerPrefab = towerPrefab;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            hoveredButton = this;
            hoveredButton.gameObject.transform.localScale = new Vector3(1.2f,1.2f,1.2f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (hoveredButton == this)
            {
                hoveredButton.gameObject.transform.localScale = Vector3.one;
                hoveredButton = null;
            }
        }
    }
}
