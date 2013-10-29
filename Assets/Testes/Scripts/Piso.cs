using UnityEngine;
using System.Collections;

public class Piso : MonoBehaviour {
	
	public Vector2 Tile;
	public bool Vazio = true;
	
	// Use this for initialization
	void Start () {
		Tile = new Vector2(transform.position.x, transform.position.z);
		renderer.material.color = Color.white;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public virtual void TurnUpdate () {
		// TEstes;
	}
	
	void OnMouseDown() {
		
		// Teste das coord e hit.
		//Mover.instance.TesteRaio(transform.position.x,transform.position.z);
		
		if(Mover.instance.AcaoEscolhida == 1)
		{
			if(renderer.material.color == Color.blue)
			{
				Mover.instance.ZerarPiso();
				Mover.instance.AcaoMoverPersonagem(transform.position);
			}
		}
		if(Mover.instance.AcaoEscolhida == 2)
		{
			if(renderer.material.color == Color.red)
			{
				Mover.instance.ZerarPiso();
				//Fazer Ação de dano
				Mover.instance.AcaoAtaquePersonagem(Tile);
			}
		}
	}
	
	
	#region Testes das cores.
	void OnMouseEnter()
	{
		//if(Mover.instance.AcaoEscolhida == 1)
		//{
			// Mostrar algo para poder mover.
		//}
	}
	
	void OnMouseExit()
	{
		//material.color = Color.white;
	}
	
	#endregion
}
