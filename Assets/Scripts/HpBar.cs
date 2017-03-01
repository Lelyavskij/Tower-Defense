using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    public GameObject enemy;

  

    public int curHp = 30; 

	
	public void Dmg(int DMGcount)
    {

        curHp -= DMGcount;

	}
	

	void Update () {

        GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(enemy.transform.position);
        GetComponent<Text>().text = curHp.ToString();
	
	}
}
