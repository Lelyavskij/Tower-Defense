using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBase : MonoBehaviour {

    public int HP = 100;
    public Text HPtext;

	
	void Update ()
    {

        HPtext.text = HP.ToString();  
	
	}


    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemyBag"))
        {
            Debug.Log("hello");

            
            HP -= 10; 
            Destroy(other.gameObject);
            Destroy(other.GetComponent<MoveToWavePoints>().hp);
        }
    }
}
