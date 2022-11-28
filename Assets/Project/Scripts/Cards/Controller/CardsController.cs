using Project.Cards.Model;
using Project.Cards.View;

namespace Project.Cards.Controller
{
    public class CardsController
    {
        private ICardsView _view;
        private ICardsModel _model;

        public CardsController(ICardsView view, ICardsModel model)
        {
            _view = view;
            _model = model;
        }

        public void Init()
        {
            _view.Init();
            Sub();
            _view.SetCount(_model.Count);
            _view.SetCardInfo(_model.Selected());
        }

        public void Deinit()
        {
            Unsub();
        }

        private void Sub()
        {
            _view.LeftClick += ShowPrevious ;
            _view.RightClick += ShowNext;
        }

        private void Unsub()
        {
            _view.LeftClick -= ShowPrevious;
            _view.RightClick -= ShowNext;
        }

        private void ShowNext()
        {
            _model.Next();
            _view.SetCardInfo(_model.Selected());
        }

        private void ShowPrevious()
        {
            _model.Previous();
            _view.SetCardInfo(_model.Selected());
        }
    }
}