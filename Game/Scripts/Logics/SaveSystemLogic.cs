using Godot;
using Godot.Collections;
using System;

public partial class SaveSystemLogic : Node
{
    public Dictionary playerData = new Dictionary();
    public static string savePath = @"C:\Highscore\";
    public static string CurrentPlayer = "Steve";
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void SaveData(string SaveFile) 
	{
        try
        {
            GD.Print("Start saving");
            if (!FileAccess.FileExists(savePath + SaveFile+ ".var"))
            {
                System.IO.Directory.CreateDirectory(savePath);
                var x = System.IO.File.Create(savePath + SaveFile + ".var");
                x.Close();

            }
            if (playerData == null)
            {
                playerData = DefaultGameState();
            }

            FileAccess file = FileAccess.Open(savePath + SaveFile + ".var", FileAccess.ModeFlags.Write);
            file.StoreVar(playerData);
            file.Close();
        }
        catch { }
        GD.Print("End saving");
    }
	public void LoadData(string SaveFile) 
    {
        if (FileAccess.FileExists(savePath + SaveFile + ".var"))
        {
            FileAccess file = FileAccess.Open(savePath + SaveFile + ".var", FileAccess.ModeFlags.Read);
            try
            {

                playerData = (Dictionary)file.GetVar();
                if (!playerData.ContainsKey("Score"))
                {
                    playerData = DefaultGameState();
                }
                file.Close();
            }
            catch
            {
                file.Close();
            }
        }
        else
        {
            playerData = DefaultGameState();
        }
    }

    public Dictionary DefaultGameState()
    {
        return new Dictionary
            {
                { "Score","Name,0"}
            };
    }



}
