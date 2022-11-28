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

        public void SetInfo(CardInfo cardInfo)
        {
            _id.text = $"User id: {cardInfo.id.ToString()}";
            _firstName.text = $"User first name: {cardInfo.first_name}";
            _lastName.text = $"User last name: {cardInfo.last_name}";
            _email.text = $"User email: {cardInfo.email}";
            _gender.text = $"User gender: {cardInfo.gender}";
            _ipAddress.text = $"User ip: {cardInfo.ip_address}";
            _address.text = $"User address: {cardInfo.address}";
        }
    }
}