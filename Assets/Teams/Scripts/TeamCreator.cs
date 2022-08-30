using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeamID {
    BesaidAurochs, KilikaBeasts, LucaGiants, MacalaniaWolves, MiRhenHunters, ThunderPlainsRaptors, ZanarkandAbes, FreeAgent
}
[CreateAssetMenu(fileName = "CreateTeam", menuName = "")]
public class TeamCreator : ScriptableObject
{
    int wins;
    int losses;
    int draws;
    int goalsFor;
    int goalsAgainst;
    int points;
    int gamesPlayed;
    int gamesRemaining;
    TeamID teamID;
    
    public List<CreatedPlayer> players = new List<CreatedPlayer>();
    public CreatedPlayer goalie;
    public CreatedPlayer leftForward;
    public CreatedPlayer rightForward;
    public CreatedPlayer leftDefense;
    public CreatedPlayer rightDefense;
    public CreatedPlayer midfielder;

    [SerializeField] private int Wins { get => wins; set => wins = value; }
    [SerializeField] private int Losses { get => losses; set => losses = value; }
    [SerializeField] private int Draws { get => draws; set => draws = value; }
    [SerializeField] private int GoalsFor { get => goalsFor; set => goalsFor = value; }
    [SerializeField] private int GoalsAgainst { get => goalsAgainst; set => goalsAgainst = value; }
    [SerializeField] private int Points { get => points; set => points = value; }
    [SerializeField] private int GamesPlayed { get => gamesPlayed; set => gamesPlayed = value; }
    [SerializeField] private int GamesRemaining { get => gamesRemaining; set => gamesRemaining = value; }
    [SerializeField] private TeamID TeamID { get => teamID; set => teamID = value; }

}
