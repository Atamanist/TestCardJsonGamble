using System;

namespace Project.Cards.View
{
    public interface ICardsView
    {
        public event Action LeftClick;
        public event Action RightClick;
        public void Init();
        public void SetCount(int count);
        public void SetCardInfo(CardInfo cardInfo);
    }
}