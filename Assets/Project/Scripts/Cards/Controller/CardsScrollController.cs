using Project.Cards.Model;
using Project.Cards.View;

namespace Project.Cards.Controller
{
    public class CardsScrollController
    {
        private ICardsScrollView _view;
        private ICardsModel _model;

        public CardsScrollController(ICardsScrollView view, ICardsModel model)
        {
            _view = view;
            _model = model;
        }

        public void Init()
        {
            _view.Init(_model.Cards);
        }
    }
}