using System.Collections.Generic;

public class Tags
{
    public enum tags
    {
        Respawn,
        Finish,
        MainCamera,
        Player,
        GameController,
        PickUpTag,
        Planeta,
        sat,
        Trees,
        tope,
        BreakableObject,
        WallCol,
        enemy,
        NotPauseTag,
        MenuHorizontal
    };

    public enum PickUpType
    {
        Common = 100,
        Rare = 250,
        Epic = 500
    }

    public enum ScenesEnum
    {
        MainMenu,
        Level01,
        WinScreen,
        DeadScreen,
        Credits
    };

    public static Dictionary<ScenesEnum,Level> Scenes = new Dictionary<ScenesEnum, Level>()
    {
       // {ScenesEnum.MainMenu, new Level(Name:"MainMenu", MaxPickups:0, Order:0)},
        {ScenesEnum.Level01, new Level(Name:"Level 01", MaxPickups:81, Order:1)},
       // {ScenesEnum.WinScreen, new Level(Name:"WinScreen", MaxPickups:0, Order:-1)},
       // {ScenesEnum.DeadScreen, new Level(Name:"DeadScreen", MaxPickups:0, Order:-2)},
    };
}

public class Level
{
    public string Name {get;set;}
    public int MaxPickups{get;set;}
    public int Order{get;set;}

    public Level(string Name, int MaxPickups, int Order)
    {
        this.Name = Name;
        this.MaxPickups = MaxPickups;
        this.Order = Order;
    }
}
