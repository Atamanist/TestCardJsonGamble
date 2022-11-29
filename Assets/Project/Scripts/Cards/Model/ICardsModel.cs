
namespace Project.Cards.Model
{
    public interface ICardsModel
    {
        public int Count { get; }
        public void Previous();
        public void Next();
        public CardInfo Selected();

        public CardInfo[] Cards { get; }
    }
}