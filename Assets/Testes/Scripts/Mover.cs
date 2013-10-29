using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mover : MonoBehaviour {
	
	//Referente aos personagens.
	public List<Personagem> Player = new List<Personagem>();
	int currentPlayer = 0;
	int contadorPlayer = 0;
	
	//Referente ao Terreno.
	public List<Piso> Terreno = new List<Piso>();
	int contadorTerreno = 0;
	
	public int AcaoEscolhida = 0;
	//public GameObject PersonagemTeste; // Teste para mover o personagem.
	
	public static Mover instance; 
	
	public Camera cameraP;
	public Ray raio;
	public RaycastHit hit;
	// Use this for initialization
	
	void Awake() {
		instance = this;
		object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
		#region Contagem Inicial
		foreach(GameObject o in obj)
		{
			if(o.tag == "Player")
			{
				Player.Add(o.GetComponent<Personagem>());
				//Player.RemoveAt(Numero do personagem); (Para remover da lista 'usar na morte')
				contadorPlayer += 1;
				print(contadorPlayer);
			}
			else
			{
				if(o.tag == "Terreno")
				{
					Terreno.Add(o.GetComponent<Piso>());
				}
			}
		}
		
		
		
		
		
		#endregion
	}
	
	void Start () {
		
		cameraP = Camera.main;
		raio = cameraP.ScreenPointToRay(Input.mousePosition);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//Criar turnos
		Player[currentPlayer].TurnUpdate();
		
		raio = cameraP.ScreenPointToRay(Input.mousePosition);
		//if(Physics.Raycast(raio,Mathf.Infinity))
		//{
		//	
		//}
	}
	#region Ações que podem ser feitas pelas escolhas do jogador
	public void AcaoMoverPersonagem(Vector3 PosF)
	{
		Player[currentPlayer].SetPosDestino(PosF);
	}
	public void AcaoAtaquePersonagem(Vector2 PosPiso)
	{
		foreach(Personagem Alvo in Player)
		{
			if(Alvo.Tile == PosPiso)
			{
				Player[currentPlayer].SelecAtk = false;
				Alvo.CalcularDano(Player[currentPlayer]._AtkAtual);
				print(Alvo.name + " tem " + Alvo._VidaAtual + " pontos de vida.");
			}
		}
	}
	
	public void AcaoPassarTurno()
	{
		Player[currentPlayer].Ativar();
		if(Player.Count == currentPlayer + 1)
		{
			currentPlayer = 0;
		}
		else
		{
			currentPlayer +=1;
		}
		if(Player[currentPlayer] == null)
		{
			if(Player.Count == currentPlayer + 1)
			{
				currentPlayer = 0;
			}
			else
			{
				currentPlayer +=1;
			}
		}
	}
	
	//Mover
	public void contarPisoAndar()
	{
		if(Player[currentPlayer].SelecMover == true)
		{
			foreach(Piso o in Terreno)
			{
				
				for(int i = 0; i<Player[currentPlayer]._Movimento;i++)
				{
					int movi = 0;
					if(o.Tile.x >= Player[currentPlayer].PosAtual.x - Player[currentPlayer]._Movimento)
					{
						if(o.Tile.x <= Player[currentPlayer].PosAtual.x + Player[currentPlayer]._Movimento)
						{
							movi = (int)(o.Tile.x -Player[currentPlayer].PosAtual.x);
							if(movi <0)
							{
								movi *=-1;
							}
							if(o.Tile.y >= Player[currentPlayer].PosAtual.z - Player[currentPlayer]._Movimento + movi)
							{
								if(o.Tile.y <= Player[currentPlayer].PosAtual.z + Player[currentPlayer]._Movimento - movi)
								{
									if(o.Vazio == true)
									{
										o.renderer.material.color = Color.blue;
									}
								}
							}
						}
					}
				}
			}
		}
	}
	
	//Ataque
	public void contarPisoAtk()
	{
		if(Player[currentPlayer].SelecAtk == true)
		{
			foreach(Piso o in Terreno)
			{
				for(int i = 0; i<Player[currentPlayer]._AreaAtk.y;i++)
				{
					int movi = 0;
					if(o.Tile.x >= Player[currentPlayer].PosAtual.x - Player[currentPlayer]._AreaAtk.y)
					{
						if(o.Tile.x <= Player[currentPlayer].PosAtual.x + Player[currentPlayer]._AreaAtk.y)
						{
							movi = (int)(o.Tile.x -Player[currentPlayer].PosAtual.x);
							if(movi <0)
							{
								movi *=-1;
							}
							if(o.Tile.y >= Player[currentPlayer].PosAtual.z - Player[currentPlayer]._AreaAtk.y + movi)
							{
								if(o.Tile.y <= Player[currentPlayer].PosAtual.z + Player[currentPlayer]._AreaAtk.y - movi)
								{
									o.renderer.material.color = Color.red;
								}
							}
						}
					}
				}
			}
		}
	}
	
	#endregion
	
	#region Testes
	public void TesteRaio(float posX, float posZ)
	{
		print("d");
		if(Physics.Raycast(raio,out hit, Mathf.Infinity))
		{
			print("r");
			if(hit.point.x >= posX - 0.5f && hit.point.x <= posX + 0.5f)
			{
				print("X: " + posX + " Z: " + posZ);
			}
		}
	}
	
	public void ZerarPiso()
	{
		foreach(Piso o in Terreno)
		{
			o.renderer.material.color = Color.white;
		}
	}
	#endregion
	
	
	#region GUI para o personagem.
	
	void OnGUI()
	{
		if(AcaoEscolhida == 0)
		{
			if(GUI.Button(new Rect(0.01f*Screen.width,0.01f*Screen.height,0.2f*Screen.width,0.1f*Screen.height),"Mover"))
			{
				contarPisoAndar();
				AcaoEscolhida = 1;
			}
			if(GUI.Button(new Rect(0.01f*Screen.width,0.12f*Screen.height,0.2f*Screen.width,0.1f*Screen.height),"Atacar"))
			{
				contarPisoAtk();
				AcaoEscolhida = 2;
			}
			if(GUI.Button(new Rect(0.01f*Screen.width,0.23f*Screen.height,0.2f*Screen.width,0.1f*Screen.height),"Magia"))
			{
				AcaoEscolhida = 3;
			}
			if(GUI.Button(new Rect(0.01f*Screen.width,0.34f*Screen.height,0.2f*Screen.width,0.1f*Screen.height),"Item"))
			{
				AcaoEscolhida = 4;
			}
			if(GUI.Button(new Rect(0.01f*Screen.width,0.89f*Screen.height,0.2f*Screen.width,0.1f*Screen.height),"Terminar"))
			{
				AcaoEscolhida = 5;
			}
		}
		if(AcaoEscolhida == 1) // Mover
		{
			
			// Voltar para o Menu de escolha Principal
			if(GUI.Button(new Rect(0.01f*Screen.width,0.89f*Screen.height,0.2f*Screen.width,0.1f*Screen.height), "Voltar"))
			{
				ZerarPiso();
				AcaoEscolhida = 0;
			}
		}
		if(AcaoEscolhida == 2) // Ataque
		{
			
			// Voltar para o Menu de escolha Principal
			if(GUI.Button(new Rect(0.01f*Screen.width,0.89f*Screen.height,0.2f*Screen.width,0.1f*Screen.height), "Voltar"))
			{
				ZerarPiso();
				AcaoEscolhida = 0;
			}
		}
		if(AcaoEscolhida == 3) // Magia
		{
			
			// Voltar para o Menu de escolha Principal
			if(GUI.Button(new Rect(0.01f*Screen.width,0.89f*Screen.height,0.2f*Screen.width,0.1f*Screen.height), "Voltar"))
			{
				AcaoEscolhida = 0;
			}
		}
		if(AcaoEscolhida == 4) // Item
		{
			
			// Voltar para o Menu de escolha Principal
			if(GUI.Button(new Rect(0.01f*Screen.width,0.89f*Screen.height,0.2f*Screen.width,0.1f*Screen.height), "Voltar"))
			{
				AcaoEscolhida = 0;
			}
		}
		if(AcaoEscolhida == 5) //Terminar
		{
			
			if(GUI.Button(new Rect(0.01f*Screen.width,0.01f*Screen.height,0.2f*Screen.width,0.1f*Screen.height),"Aceitar"))
			{
				AcaoPassarTurno();
				AcaoEscolhida = 0;
			}
			
			// Voltar para o Menu de escolha Principal
			if(GUI.Button(new Rect(0.01f*Screen.width,0.89f*Screen.height,0.2f*Screen.width,0.1f*Screen.height), "Voltar"))
			{
				AcaoEscolhida = 0;
			}
		}
	}
	
	#endregion
	
	//void OnMouseDown() {
	//	
	//	print("1");
	//	
	//	if(Physics.Raycast(raio,Mathf.Infinity))
	//	{
	//		print("Test");
	//	}
	//	
	//}
	
	public void PisosOcupados()
	{
		
	}
	
}
