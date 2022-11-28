using Project.Cards.Controller;
using Project.Cards.Model;
using Project.Cards.View;
using UnityEngine;

namespace Project.Core
{
    public class Core : MonoBehaviour
    {
        [SerializeField] private CardsView _cardsView;
        private JsonReaderService<CardInfo> _cardJsonReaderService;
        private CardsModel _cardsModel;
        private CardsController _cardsController;
        
        private void Start()
        {
            InstallService();
            InstallModel();
            InstallController();
            Initialize();
        }

        private void InstallService()
        {
            _cardJsonReaderService = new JsonReaderService<CardInfo>();
        }

        private void InstallModel()
        {
            var cardsInfo = _cardJsonReaderService.LoadFile("test_data");
            _cardsModel = new CardsModel(cardsInfo);
        }

        private void InstallController()
        {
            _cardsController = new CardsController(_cardsView, _cardsModel);
        }
        
        private void Initialize()
        {
            _cardsController.Init();
        }
    }
}