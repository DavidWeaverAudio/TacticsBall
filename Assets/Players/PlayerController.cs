using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum CarrierAction {
    Idle, Pass, Shoot, Dribble
};
public class PlayerController : MonoBehaviour
{
    public CreatedPlayer playerInfo;
    public bool playerControlled;
    public CarrierAction currentAction;
    public Directions Dir;

    private void Start()
    {
        Debug.Log($"Adding {playerInfo.name} to the playermanager");
        PlayerManager.Instance.AddPlayer(playerInfo);
    }
}

[CustomEditor(typeof(PlayerController))]
public class PlayerControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerController playerController = (PlayerController)target;
        GUILayout.Label("Stats", EditorStyles.boldLabel);
        playerController.playerInfo.Level = EditorGUILayout.IntField("Level", playerController.playerInfo.Level);
        playerController.playerInfo.Hp = EditorGUILayout.IntField("HP", playerController.playerInfo.Hp);
        playerController.playerInfo.Mp = EditorGUILayout.IntField("MP", playerController.playerInfo.Mp);
        playerController.playerInfo.Xp = EditorGUILayout.DoubleField("XP", playerController.playerInfo.Xp);
        playerController.playerInfo.Speed = EditorGUILayout.IntField("Speed", playerController.playerInfo.Speed);
        playerController.playerInfo.Attack = EditorGUILayout.IntField("Attack", playerController.playerInfo.Attack);
        playerController.playerInfo.Endurance = EditorGUILayout.IntField("Endurance", playerController.playerInfo.Endurance);
        playerController.playerInfo.Pass = EditorGUILayout.IntField("Pass", playerController.playerInfo.Pass);
        playerController.playerInfo.Shoot = EditorGUILayout.IntField("Shoot", playerController.playerInfo.Shoot);
        playerController.playerInfo.Block = EditorGUILayout.IntField("Block", playerController.playerInfo.Block);
        playerController.playerInfo.Catch = EditorGUILayout.IntField("Catching", playerController.playerInfo.Catch);
        
        GUILayout.Space(5);
        GUILayout.Label("----------------------");
        GUILayout.Space(5);
        
        GUILayout.Label("GameLogic", EditorStyles.boldLabel);
        playerController.playerInfo.Team = (TeamID)EditorGUILayout.EnumPopup("Team", playerController.playerInfo.Team);
        playerController.playerInfo.Position = (Position)EditorGUILayout.EnumPopup("Position", playerController.playerInfo.Position);
        playerController.playerControlled = EditorGUILayout.Toggle("Player Controlled", playerController.playerControlled);
        playerController.currentAction = (CarrierAction)EditorGUILayout.EnumPopup("Current Action", playerController.currentAction);

        GUILayout.Space(5);
        GUILayout.Label("----------------------");
        GUILayout.Space(5);

        GUILayout.Label("Current Game Stats", EditorStyles.boldLabel);
        playerController.playerInfo.CurrentGoals = EditorGUILayout.IntField("Goals", playerController.playerInfo.CurrentGoals);
        playerController.playerInfo.CurrentSaves = EditorGUILayout.IntField("Saves", playerController.playerInfo.CurrentSaves);
        playerController.playerInfo.CurrentTackles = EditorGUILayout.IntField("Tackles", playerController.playerInfo.CurrentTackles);
        playerController.playerInfo.CurrentInterceptions = EditorGUILayout.IntField("Interceptions", playerController.playerInfo.CurrentInterceptions);
        playerController.playerInfo.CurrentAssists = EditorGUILayout.IntField("Assists", playerController.playerInfo.CurrentAssists);
        playerController.playerInfo.CurrentShots = EditorGUILayout.IntField("Shots", playerController.playerInfo.CurrentShots);
        playerController.playerInfo.CurrentPasses = EditorGUILayout.IntField("Passes", playerController.playerInfo.CurrentPasses);

    }
}

