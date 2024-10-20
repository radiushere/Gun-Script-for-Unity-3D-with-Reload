using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using TMPro;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
	//variable
	public Transform barrel;
	public float range = 100f;
	public ParticleSystem muzzleFlash;
	public float damage = 1f;
	public int bullets = 21;
	int totalbullets;
	public GameObject reloadPanel;
    public TextMeshProUGUI bulletCounter;
	public AudioSource gunshotsound;

	public GameObject enemyproj;

    private void Start()
    {
		enemyproj = GameObject.FindGameObjectWithTag("EnemyProjectile");
		totalbullets = bullets;
    }

    void Update()
    {
		if (Input.GetButtonDown("Fire1") && bullets > 0)
		{
			gunshotsound.Play();		
			shootFunc();
			muzzleFlash.Play();
			bullets--;
        }

        else if(Input.GetButtonDown("Fire1") && bullets <= 0) 
		{
			StartCoroutine("reloading");
		}

		bulletCounter.text = "Bullets: " + bullets;
    }
   
	public void shootFunc()
	{
        RaycastHit hit;
        Ray ray = new Ray(barrel.position, transform.forward);

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.tag == "Enemy")
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.health -= damage;
				Debug.Log("hit");
            }
        }

        Debug.DrawRay(barrel.position, transform.forward * range, Color.yellow);
    }

	//reloading method
	IEnumerator reloading()
	{
		reloadPanel.SetActive(true);
		yield return new WaitForSeconds(2);
		reloadPanel.SetActive(false);
		bullets = totalbullets;
	}
}
