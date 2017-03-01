using UnityEngine;
using UnityEngine.UI;

public class HpBase : MonoBehaviour 
{
    public int HP = 100;
    public Text HPtext;

	private void Update ()
    {
        HPtext.text = HP.ToString();  
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemyBug"))
        {
            HP -= 10; 
            Destroy(other.gameObject);
            Destroy(other.GetComponent<MoveToWavePoints>().hp);
        }
    }
}
