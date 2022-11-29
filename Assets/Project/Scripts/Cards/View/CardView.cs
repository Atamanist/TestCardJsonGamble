using TMPro;
using UnityEngine;

namespace Project.Cards.View
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _id;
        [SerializeField] private TextMeshProUGUI _firstName;
        [SerializeField] private TextMeshProUGUI _lastName;
        [SerializeField] private TextMeshProUGUI _email;
        [SerializeField] private TextMeshProUGUI _gender;
        [SerializeField] private TextMeshProUGUI _ipAddress;
        [SerializeField] private TextMeshProUGUI _address;
        [field: SerializeField] public Canvas Canvas { get; private set; }

        public void SetInfo(CardInfo cardInfo)
        {
            _id.text = $"User id: \n{cardInfo.id.ToString()}";
            _firstName.text = $"User first name: \n{cardInfo.first_name}";
            _lastName.text = $"User last name: \n{cardInfo.last_name}";
            _email.text = $"User email: \n{cardInfo.email}";
            _gender.text = $"User gender: \n{cardInfo.gender}";
            _ipAddress.text = $"User ip: \n{cardInfo.ip_address}";
            _address.text = $"User address: \n{cardInfo.address}";
        }
    }
}