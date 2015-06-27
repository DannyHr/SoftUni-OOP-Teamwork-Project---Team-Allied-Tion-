using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TestMonogame;

namespace Allied_Tion_Monogame_Test.MapNamespace
{
    public static class MapFactory
    {
        private static List<string> commands = new List<string>()
        {
            "bug",
            "exception",
            "exam",
            "cpu",
            "ram",
            "hdd",
            "book",
            "rsharper",
            "beer",
            "redbull",
            "big-rock",
            "large-rock",
            "rocks",
            "skulls",
            "stump",
            "bush2",
            "tree",
            "double-bush",
            "bush"
        };
        private static ContentManager Content;
        private static Map Map;

        public static void LoadMapObjectsFromTextFile(Map map, string mapTextFilePath, ContentManager content)
        {
            Map = map;
            Content = content;
            using (var sr = new StreamReader(mapTextFilePath))
            {
                string currentLine = sr.ReadLine();
                string command = "";

                while (!sr.EndOfStream)
                {
                    if (commands.Contains(currentLine))
                    {
                        command = currentLine;
                        currentLine = sr.ReadLine();
                    }
                    int x = int.Parse(currentLine.Split(' ')[0]);
                    int y = int.Parse(currentLine.Split(' ')[1]);
                    Point point = new Point(x, y);

                    Execute(command, point);

                    currentLine = sr.ReadLine();
                }
            }
        }

        private static void Execute(string command, Point point)
        {
            

            switch (command)
            {
                case "bug":
                    Map.AddMapCreature(new MapCreature(Content.Load<Texture2D>("CharacterTextures/bug"), point));
                    break;
                case "exception":
                    Map.AddMapCreature(new MapCreature(Content.Load<Texture2D>("CharacterTextures/exception"), point));
                    break;
                case "exam":
                    Map.AddMapCreature(new MapCreature(Content.Load<Texture2D>("CharacterTextures/exam"), point));
                    break;
                case "cpu":
                    Map.AddMapItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/cpu-x35"), point));
                    break;
                case "ram":
                    Map.AddMapItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/ram"), point));
                    break;
                case "hdd":
                    Map.AddMapItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/hdd"), point));
                    break;
                case "book":
                    Map.AddMapItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/book"), point));
                    break;
                case "rsharper":
                    Map.AddMapItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/RSharper"), point));
                    break;
                case "beer":
                    Map.AddMapItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/beerx32"), point));
                    break;
                case "redbull":
                    Map.AddMapItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/redbull"), point));
                    break;
                case "big-rock":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/big-rock"), point));
                    break;
                case "large-rock":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/large-rock"), point));
                    break;
                case "rocks":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/rocks"), point));
                    break;
                case "skulls":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/skulls"), point));
                    break;
                case "stump":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/stump"), point));
                    break;
                case "bush2":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/bush2"), point));
                    break;
                case "tree":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/tree"), point));
                    break;
                case "double-bush":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/double-bush"), point));
                    break;
                case "bush":
                    Map.AddMapElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/bush"), point));
                    break;
            }
        }
    }
}
