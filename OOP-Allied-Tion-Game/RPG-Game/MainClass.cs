namespace RPG
{
    using System;
    using Items;
    using System.Linq;
    using System.Collections.Generic;
    using RPG.Characters;

    public class MainClass
    {
        private const string mapPath = "../../Maps/01.txt";
        private const string musicPath = "../../Sound/Bach-Air.mp3";

        public static void Main()
        {
            Sound file = new Sound(musicPath);
            file.Play(true);
            //Beer beer = new Beer(new Position(1, 1));
            //beer.
            //MapLoader.LoadMap(mapPath);
            //List<Item> allItems = MapLoader.ItemsOnMap.ToList();
            //List<Character> allCharacters = MapLoader.CharactersOnMap.ToList();
        }
    }
}
