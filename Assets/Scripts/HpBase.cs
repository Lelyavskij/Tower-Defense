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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemyBag"))
        {
            HP -= 10; 
            Destroy(other.gameObject);
            Destroy(other.GetComponent<MoveToWavePoints>().hp);
        }
    }
}
