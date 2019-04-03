using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        class Song
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }

        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                var command = Console.ReadLine().Split("_");
                string typeList = command[0];
                string name = command[1];
                string time = command[2];

                Song songList = new Song();
                songList.TypeList = typeList;
                songList.Name = name;
                songList.Time = time;
                songs.Add(songList);
            }

            string listType = Console.ReadLine();
            if (listType == "all")
            {
                foreach (var item in songs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach (var item in songs.Where(x => x.TypeList == listType).Select(x => x.Name))
                {
                    Console.WriteLine(item);
                }

            }
        }
    }
}
