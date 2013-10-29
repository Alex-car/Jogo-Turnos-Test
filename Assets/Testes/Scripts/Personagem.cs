using UnityEngine;
using System.Collections;

public class Personagem : Status {
	
	public Vector2 Tile;
	public Vector3 PosAtual;
	public Vector3 PosDestino;
	public float VelMov;
	
	public bool PodeAtacar = false;
	public bool PodeMover = false;
	
	public bool SelecMover = true;
	public bool SelecAtk = true;
	
	// Use this for initialization
	
	void Start () {
		Tile = new Vector2(transform.position.x, transform.position.z);
		PosAtual = PosDestino;
		PosAtual = new Vector3(Tile.x,0,Tile.y);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public virtual void TurnUpdate () {
		
		
		//Fazer item de escolha antes de tudo (possivelmente GUI) no 'Mover.CS' .
		if(PodeMover == true && SelecMover == true)
		{
			Movimento();
		}
		
		
		//Criar acabar turno
		//chamar instancia personagem<i+1>
	}
	
	public void Ativar()
	{
		SelecMover = true;
		SelecAtk = true;
		// Ativar tudo que pode ser usado no turno. PodeAtacat, PodeAndar .. . . 
	}
	
	
	public void Movimento()
	{
		if(Vector3.Distance(transform.position,PosDestino) > 0.1f)
		{
			transform.position += (PosDestino - transform.position).normalized * VelMov * Time.deltaTime;
			if(Vector3.Distance(transform.position,PosDestino) <= 0.1f)
			{
				transform.position = PosDestino;
				PosAtual = PosDestino;
				Tile = new Vector2(PosAtual.x,PosAtual.z);
				PodeMover = false;
				SelecMover = false;
				
				// Falso passar de turno para testes.
				//Mover.instance.AcaoPassarTurno();
			}
		}
	}
	
	public void Ataque()
	{
		// Fazer
	}
	
	public void SetPosDestino(Vector3 Destino)
	{
		PosDestino = Destino;
		PodeMover = true;
	}
	
	#region Get dos Status
	
	
	
	#endregion
}
