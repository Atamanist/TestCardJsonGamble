using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Cards.View
{
    public class CardsScrollView : MonoBehaviour, ICardsScrollView
    {
        [SerializeField] private CardView _cardPrefab;
        [SerializeField] private RectTransform _content;
        [SerializeField] private ScrollRect _scroll;
        [SerializeField] private RectTransform _visible;

        private List<CardView> _cards;
        private int _visibleCount;
        private int _start;
        private int _finish;

        private float _cardH;
        private float _visibleH;
        private float _borderUp;
        private float _borderDown;

        public void Init(CardInfo[] cardInfos)
        {
            _cards = new List<CardView>();
            for (int i = 0; i < cardInfos.Length; i++)
            {
                var card = Instantiate(_cardPrefab, _content);
                card.name = "N";
                card.SetInfo(cardInfos[i]);
                _cards.Add(card);
            }

            StartCoroutine(TakeRect());
            _scroll.onValueChanged.AddListener(Move);
        }

        private IEnumerator TakeRect()
        {
            yield return new WaitForEndOfFrame();
            _cardH = _cards[0].GetComponent<RectTransform>().rect.height;
            _visibleH = _visible.rect.height;
            _visibleCount = Mathf.CeilToInt(_visibleH / _cardH);
            _start = 0;
            _finish = 2 * _visibleCount;
            _borderUp = _cardH;
            _borderDown = -_cardH;
            ActiveCard();
            yield return null;
        }

        private void Move(Vector2 move)
        {
            if (_content.anchoredPosition.y > _borderUp)
            {
                TryActiveNext();
                _borderUp += _cardH;
                _borderDown += _cardH;
            }
            else if (_content.anchoredPosition.y < _borderDown)
            {
                TryActivePrevious();
                _borderUp -= _cardH;
                _borderDown -= _cardH;
            }
        }

        private void TryActiveNext()
        {
            if (_start > 2*_visibleCount)
            {
                _cards[_start - 2*_visibleCount].Canvas.enabled = false;
                _cards[_start - 2*_visibleCount].gameObject.name = "N";
            }

            if (_finish + 1 < _cards.Count)
            {
                _cards[_finish + 1].Canvas.enabled = true;
                _cards[_finish + 1].gameObject.name = "Vis";

                _finish++;
                _start++;
            }
        }

        private void TryActivePrevious()
        {
            if (_cards.Count - _finish > 2*_visibleCount)
            {
                _cards[_finish + 2*_visibleCount].Canvas.enabled = false;
                _cards[_finish + 2*_visibleCount].gameObject.name = "N";
            }

            if (_start - 2*_visibleCount > 0)
            {
                _cards[_start - 2*_visibleCount].Canvas.enabled = true;
                _cards[_start - 2*_visibleCount].gameObject.name = "Vis";

                _start--;
                _finish--;
            }
        }

        private void ActiveCard()
        {
            for (int i = _start; i <= _finish; i++)
            {
                _cards[i].Canvas.enabled = true;
                _cards[i].gameObject.name = "Vis";
            }
        }
    }
}