using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TestMonogame;

namespace Allied_Tion_Monogame_Test.MapNamespace
{
    public static class MapFactory
    {
        private static readonly List<string> Commands = new List<string>
        #region FillListWithCommands
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
        #endregion

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
                    if (Commands.Contains(currentLine))
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
            #region CheckCommandCase
            switch (command)
            {
                case "bug":
                    Map.AddCreature(new MapCreature(Content.Load<Texture2D>("CharacterTextures/bug"), point));
                    break;
                case "exception":
                    Map.AddCreature(new MapCreature(Content.Load<Texture2D>("CharacterTextures/exception"), point));
                    break;
                case "exam":
                    Map.AddCreature(new MapCreature(Content.Load<Texture2D>("CharacterTextures/exam"), point));
                    break;
                case "cpu":
                    Map.AddItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/cpu-x35"), point));
                    break;
                case "ram":
                    Map.AddItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/ram"), point));
                    break;
                case "hdd":
                    Map.AddItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/hdd"), point));
                    break;
                case "book":
                    Map.AddItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/book"), point));
                    break;
                case "rsharper":
                    Map.AddItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/RSharper"), point));
                    break;
                case "beer":
                    Map.AddItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/beerx32"), point));
                    break;
                case "redbull":
                    Map.AddItem(new MapItem(Content.Load<Texture2D>("ItemsTextures/redbull"), point));
                    break;
                case "big-rock":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/big-rock"), point));
                    break;
                case "large-rock":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/large-rock"), point));
                    break;
                case "rocks":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/rocks"), point));
                    break;
                case "skulls":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/skulls"), point));
                    break;
                case "stump":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/stump"), point));
                    break;
                case "bush2":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/bush2"), point));
                    break;
                case "tree":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/tree"), point));
                    break;
                case "double-bush":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/double-bush"), point));
                    break;
                case "bush":
                    Map.AddElement(new MapElement(Content.Load<Texture2D>("MapElementsTextures/bush"), point));
                    break;
            }
            #endregion
        }

        public static void LoadMapImage(Map map, Texture2D mapImage)
        {
            map.Image = mapImage;
        }

        public static void RemoveMapItemByHashCode(Map map, int hashCodeOfItemToRemove)
        {
            map.MapItems.Remove(map.MapItems.Single(el => el.GetHashCode() == hashCodeOfItemToRemove));
        }
    }
}
