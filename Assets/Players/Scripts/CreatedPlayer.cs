using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum Position {
    GOALIE, LEFTFORWARD, RIGHTFORWARD, MIDFIELDER, LEFTDEFENSE, RIGHTDEFENSE
};

[CreateAssetMenu(fileName = "CreatePlayer", menuName = "")]
public class CreatedPlayer : ScriptableObject
{
    #region Player Stats
    [SerializeField] private string pname;
    [SerializeField] private TeamID team;
    [SerializeField] private Position position;
    [SerializeField] private int number;
    [SerializeField] private int goals;
    [SerializeField] private int assists;
    [SerializeField] private int shots;
    [SerializeField] private int passes;
    [SerializeField] private int tackles;
    [SerializeField] private int saves;
    [SerializeField] private int interceptions;
    [SerializeField] private int hp;
    [SerializeField] private int mp;
    [SerializeField] private double xp;
    [SerializeField] private int level;
    [SerializeField] private int speed;
    [SerializeField] private int attack;
    [SerializeField] private int endurance;
    [SerializeField] private int pass;
    [SerializeField] private int shoot;
    [SerializeField] private int block;
    [SerializeField] private int catching;

    // current game stats
    [SerializeField] private int currentGoals;
    [SerializeField] private int currentAssists;
    [SerializeField] private int currentShots;
    [SerializeField] private int currentPasses;
    [SerializeField] private int currentTackles;
    [SerializeField] private int currentSaves;
    [SerializeField] private int currentInterceptions;
        
    #endregion
    #region Getters and Setters
    public string Name { get => pname; set => pname = value; }
    public TeamID Team { get => team; set => team = value; }
    public Position Position { get => position; set => position = value; }
    public int Number { 
        get => number; 
        set {
            Debug.Log("Trying to change player number...");
            if (PlayerManager.Instance.playerNumber.Contains(value))
            {
                Debug.Log("Number already taken");
            }
            else
            {
                number = value;
                PlayerManager.Instance.playerNumber.Add(value);
            }
        } 
    }
    public int Goals { get => goals; set => goals = value; }
    public int Assists { get => assists; set => assists = value; }
    public int Shots { get => shots; set => shots = value; }
    public int Passes { get => passes; set => passes = value; }
    public int Tackles { get => tackles; set => tackles = value; }
    public int Saves { get => saves; set => saves = value; }
    public int Interceptions { get => interceptions; set => interceptions = value; }
    public int Hp { 
        get => hp; 
        set {
            if(hp > 100)
            {
                hp = 100;
            }
            else if(hp < 0)
            {
                hp = 0;
            }
            else
            {
                hp = value;
            }
        }
    }
    public int Mp { 
        get => mp; 
        set {
            if(mp > 100)
            {
                mp = 100;
            }
            else if(mp < 0)
            {
                mp = 0;
            }
            else
            {
                mp = value;
            }
            
        }
    }
    public int Level { 
        get => level; 
        set {
            if(level > 99)
            {
                level = 99;
            }
            else if(level < 1)
            {
                level = 1;
            }
            else
            {
                level = value;
            }
        } 
    }
    public double Xp { get => xp; set => xp = value; }
    public int Speed { 
        get => speed; 
        set {
            if(speed > 99)
            {
                speed = 99;
            }
            else if(speed < 1)
            {
                speed = 1;
            }
            else
            {
                speed = value;
            }
        }
    }
    public int Attack { 
        get => attack; 
        set {
            if(attack > 99){
                attack = 99;
            }
            else if(attack < 1){
                attack = 1;
            }
            else{
                attack = value;
            }
        }
    }
    public int Endurance { 
        get => endurance; 
        set {
            if(endurance > 99){
                endurance = 99;
            }
            else if(endurance < 1){
                endurance = 1;
            }
            else{
                endurance = value;
            }
        } 
    }
    public int Pass { 
        get => pass; 
        set {
            if(pass > 99){
                pass = 99;
            }
            else if(pass < 1){
                pass = 1;
            }
            else{
                pass = value;
            }
        }  
    }
    public int Block { 
        get => block; 
        set {
            if(block > 99){
                block = 99;
            }
            else if(block < 1){
                block = 1;
            }
            else{
                block = value;
            }
        }
    }
    public int Shoot { 
        get => shoot; 
        set {
            if(shoot > 99){
                shoot = 99;
            }
            else if(shoot < 1){
                shoot = 1;
            }
            else{
                shoot = value;
            }
        }
    }
    public int Catch { 
        get => catching; 
        set {
            if(catching > 99){
                catching = 99;
            }
            else if(catching < 1){
                catching = 1;
            }
            else{
                catching = value;
            }
        } 
    }
    public int CurrentGoals { get => currentGoals; set => currentGoals = value; }
    public int CurrentAssists { get => currentAssists; set => currentAssists = value; }
    public int CurrentShots { get => currentShots; set => currentShots = value; }
    public int CurrentPasses { get => currentPasses; set => currentPasses = value; }
    public int CurrentTackles { get => currentTackles; set => currentTackles = value; }
    public int CurrentSaves { get => currentSaves; set => currentSaves = value; }
    public int CurrentInterceptions { get => currentInterceptions; set => currentInterceptions = value; }
    
    #endregion
    
    //public Ability ability1 { get; set; }
    //public Ability ability2 { get; set; }
    //public Ability ability3 { get; set; }

    //void AddAbility(Ability ability);
    //void RemoveAbility(Ability ability, int index);
    //void PrintAbilities();
    void PrintGameStats(){}
    void PrintCareerStats(){}

    void UpdateGoals(){
        goals++;
    }
    void UpdateAssists(){
        assists++;
    }
    void UpdateSaves(){
        saves++;
    }
    void UpdateTackles(){
        tackles++;
    }
    void UpdateInterceptions(){
        interceptions++;
    }
    void UpdatePasses(){
        passes++;
    }
    void UpdateShots(){
        shots++;
    }
    void UpdateHP(int amount){
        hp += amount;
    }
    void UpdateMP(int amount){
        mp += amount;
    }
    void UpdateXP(double amount){
        xp += amount;
    }
    void UpdateSpeed(int amount){
        speed += amount;
    }
    public void RandomizeStats(){
        hp = Random.Range(1, 100);
        mp = Random.Range(1, 100);
        xp = Random.Range(1, 100);
        speed = Random.Range(1, 10);
        attack = Random.Range(1, 10);
        endurance = Random.Range(1, 10);
        pass = Random.Range(1, 10);
        shoot = Random.Range(1, 10);
        block = Random.Range(1, 10);
        catching = Random.Range(1, 10);
    }
    public void RandomizeName(){
        pname = PlayerManager.Instance.playerNames[Random.Range(0, PlayerManager.Instance.playerNames.Length)];
    }
}

[CustomEditor(typeof(CreatedPlayer))]
public class CreatedPlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        CreatedPlayer player = (CreatedPlayer ) target;
        if(GUILayout.Button("RandomizeStats"))
        {
            player.RandomizeStats();
        }
        if(GUILayout.Button("RandomizeName"))
        {
            player.RandomizeName();
        }
    }
}