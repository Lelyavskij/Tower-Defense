using UnityEngine;
using UnityEngine.UI;

public class EnemyHpView : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private EnemyEntity _enemyEntity;

    public void SetTarget(EnemyEntity target)
    {
        _enemyEntity = target;
        _enemyEntity.HpChanged += OnHpChanged;
        _enemyEntity.Destroyed += OnDestroyed;
    }

	private void Update () 
    {
        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(_enemyEntity.transform.position);
	}

    private void OnHpChanged(int hp)
    {
        _text.text = hp.ToString();
    }

    private void OnDestroyed(EnemyEntity enemy)
    {
        Destroy(gameObject);
    }
}
