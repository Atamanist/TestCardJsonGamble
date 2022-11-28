using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Cards.View
{
    public class CardsView : MonoBehaviour, ICardsView
    {
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private Button _left;
        [SerializeField] private Button _right;

        public event Action LeftClick;
        public event Action RightClick;

        public void Init()
        {
            _left.onClick.AddListener(() => LeftClick?.Invoke());
            _right.onClick.AddListener(() => RightClick?.Invoke());
        }

        public void SetCount(int count)
        {
            _count.text = $"Count: {count}";
        }

        public void SetCardInfo(CardInfo cardInfo)
        {
            _cardPrefab.SetInfo(cardInfo);
        }
    }
}