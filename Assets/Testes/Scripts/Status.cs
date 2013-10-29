using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Status : MonoBehaviour {
	
	public float _Vida;
	public float _Mana;
	public float _Atk;
	public float _AtkEsp;
	public float _Def;
	public float _DefEsp;
	public float _Mira;
	
	public float _VidaAtual;
	public float _ManaAtual;
	public float _AtkAtual;
	public float _AtkEspAtual;
	public float _DefAtual;
	public float _DefEspAtual;
	public float _MiraAtual;
	
	public int _Movimento;
	public Vector2 _AreaAtk;
	
	public List<bool> Estado = new List<bool>(); // Buffs e Debuffs.
	
	
	public void CalcularDano(float AtkInimigo)
	{
		if((0.4f*_MiraAtual)+(1.5f*AtkInimigo)+(0.1f*_AtkEspAtual) - _DefAtual + 1 <=0)
		{
			_VidaAtual -=1;
		}
		else
		{
			_VidaAtual -= (0.4f*_MiraAtual)+(1.5f*AtkInimigo)+(0.1f*_AtkEspAtual) - _DefAtual + 1;
		}
	}
	
	
}
