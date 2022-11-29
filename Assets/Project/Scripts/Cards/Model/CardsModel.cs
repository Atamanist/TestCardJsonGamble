
namespace Project.Cards.Model
{
    public class CardsModel : ICardsModel
    {
        private CardInfo[] _cards;
        private int _index;
        public int Count => _cards.Length;
        public CardInfo[] Cards => _cards;

        public CardsModel(CardInfo[] cardInfos)
        {
            _cards = cardInfos;
            _index = 0;
        }

        public void Next()
        {
            _index = _index == _cards.Length - 1 ? 0 : _index + 1;
        }

        public CardInfo Selected()
        {
            return _cards[_index];
        }

        public void Previous()
        {
            _index = _index == 0 ? _cards.Length - 1 : _index - 1;
        }
    }
}