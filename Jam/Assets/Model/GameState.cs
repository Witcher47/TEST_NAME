﻿using System.Collections.Generic;
using System.Linq;
using Assets.Model.Maze.MazeObjects;
using Assets.Model.Maze.MazeObjects.Chest;

namespace Assets.Model
{
  public class GameState
  {
    public int Turn;
    public int MaxHitPoints;
    public Maze.Maze Maze;
    public List<Player> Players;
    public List<Hero> Heroes;
    public List<Chest> Chests;

    public Player CurrentPlayer
    {
      get { return Players[Turn%Players.Count]; }
    }

    public Hero CurrentHero
    {
      get { return Heroes.First(h => h.OwnerId == CurrentPlayer.Id); }
    }

    public bool TurnForMazeAction { get { return Turn % Players.Count(p => !p.IsDead) == 0; } }
  }

  public class Player
  {
    public int Id;
    public bool IsDead;
    public int ActionPoints;
    public List<Card> Cards;
    public ItemSlot Slot;

    public Card ActiveCard
    {
      get { return Cards.FirstOrDefault(c => c.IsActive); }
    }
  }

  public class ItemSlot
  {
    public Weapon Weapon;
    public Anh Anh;

    public ItemSlot(Weapon weapon)
    {
      Weapon = weapon;
    }

    public ItemSlot(Anh anh)
    {
      Anh = anh;
    }
  }

  public class Card
  {
    public CardType Type;
    public int Power;

    public Card()
    {
      
    }

    public Card(Card card)
    {
      Type = card.Type;
      Power = card.Power;
    }
    
    public bool IsActive { get; set; }
  }

  public enum CardType
  {
    Attack = 0,
    Defence = 1,
  }
}
