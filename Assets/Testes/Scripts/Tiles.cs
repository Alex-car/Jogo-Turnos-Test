using UnityEngine;
using System.Collections;

public class Tiles : MonoBehaviour {
	
	public string tocou = "nada";
	string texto = "vazio";
	public GameObject Personagem;
	public GameObject alvo;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.touchCount > 0) {
    	   print(Input.touchCount);
   		}
	}
	
	void OnGUI () {
  
		GUI.TextArea(new Rect(10,50,100,100),texto);
		GUI.TextArea(new Rect(200,50,100,100),tocou);
		
   if (GUI.Button(new Rect(10,250,100,100),"toque")){
			tocou = "ok";
			//Personagem.GetComponent<NavMeshAgent>().SetDestination(alvo.transform.position);
   }
	  
	}
	
}
