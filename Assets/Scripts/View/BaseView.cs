using UnityEngine;
using UnityEngine.UI;

public class BaseView : MonoBehaviour 
{
    [SerializeField]
    private Text _hpText;

    [SerializeField]
    private Base _base;

    private void Update()
    {
        _hpText.text = _base.CurrentHp.ToString();
    }
}
