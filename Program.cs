/**

*--------------------------------------------------------------------

* File name: Program.cs

* Project name: Lab 1 Review Lab

*--------------------------------------------------------------------

* Author’s name and email: Jericho McGowan || mcgowanj2@etsu.edu

* Course-Section: CSCI-2910-001

* Creation Date: 9/1/2023

* -------------------------------------------------------------------

*/
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab_1_Video_Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gameCount = 0;
            List<VideoGames> games = new List<VideoGames>();
            using (StreamReader rdr = new StreamReader("../../../Video Game Data/videogames.csv"))
           {
                #region 1. Filling and Reading of Games List
                rdr.ReadLine(); //Allows the skipping of the first line
                Console.WriteLine("Name | Platform | Year | Genre | Publisher | NA_Sales | EU_Sales | JP_Sales | Other_Sales | Global_Sales");
                while (rdr.Peek() != -1) 
                {
                   
                    string line = rdr.ReadLine();
                    string[] info = line.Split(",");
                    int year = Convert.ToInt32(info[2]);
                    double na_Sales = Convert.ToDouble(info[5]);
                    double eu_Sales = Convert.ToDouble(info[6]);
                    double jp_Sales = Convert.ToDouble(info[7]);
                    double other_Sales = Convert.ToDouble(info[8]);
                    double global_Sales = Convert.ToDouble(info[9]);
                    // public VideoGames(string name, string platform, int year, string genre, string publisher, double na_Sales, double eu_Sales, double jp_Sales, double other_Sales, double global_Sales)
                    VideoGames game = new VideoGames(info[0], info[1], year, info[3], info[4], na_Sales, eu_Sales, jp_Sales, other_Sales, global_Sales);
                    games.Add(game);
                    gameCount++;
                    

                }
                #endregion


                #region 1. Display first 20 Games
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"#{i + 1} - {games[i].ToString()}");
                }
                #endregion


                #region 2. Sort by Title
                games.Sort();
                Console.WriteLine("\n\nSort by Title:\n");
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine($"#{i + 1} - {games[i].ToString()}");
                }
                #endregion


                #region 3. & 4. Nintendo Games Test

                
                //Create list for the publisher and for every instance that Nintendo is found as a publisher, add it to the new List
                List<VideoGames> publisherGames = new List<VideoGames>();
                for(int i = 0; i <games.Count; i++)
                {
                    if (games[i].Publisher == "Nintendo") 
                    {
                        publisherGames.Add(games[i]);
                    }
                }
                //Sorted list
                Console.WriteLine("Nintendo Games Sorted");
                publisherGames.Sort();
                for (int i = 0; i < publisherGames.Count; i++)
                {
                    Console.WriteLine($"#{i + 1} - {publisherGames[i]}");
                }
                //Percentage Calculated
                double totalGames = games.Count;
                double totalPublisher = publisherGames.Count;
                double percentagePublisher = Math.Round((totalPublisher / totalGames) * 100, 2);

                Console.WriteLine($"{percentagePublisher}%");
               

                #endregion

                


                #region 5. & 6. Genre Original Code

                List<VideoGames> genreGames = new List<VideoGames>();
                for (int i = 0; i < games.Count; i++)
                {
                    if (games[i].Genre == "Puzzle")
                    {
                        genreGames.Add(games[i]);
                    }
                }
                Console.WriteLine("Puzzle Games Sorted");
                publisherGames.Sort();
                for (int i = 0; i < genreGames.Count; i++)
                {
                    Console.WriteLine($"#{i + 1} - {genreGames[i]}");
                }
               
                double totalGenre = genreGames.Count;
                double percentageGenre = Math.Round((totalGenre / totalGames) * 100, 2);

                Console.WriteLine($"{percentageGenre}%");
               

                #endregion

            }
            #region 7. and 8. Execution

            PublisherData(games);
            GenreData(games);

            #endregion



        }
        static void PublisherData(List<VideoGames> games)
        {
            bool inputBool = false;
            List<VideoGames> publisherGames = new List<VideoGames>();
            while (inputBool == false)
            {
                Console.Write("What Publisher would you like to search for? ");
                string input = Console.ReadLine();
                try
                {
                    for (int i = 0; i < games.Count; i++)
                    {
                        if (games[i].Publisher == input)
                        {
                            publisherGames.Add(games[i]);
                        }
                    }
                    if (publisherGames != null)
                    {


                        Console.WriteLine($"{input} Sorted");
                        publisherGames.Sort();
                        for (int i = 0; i < publisherGames.Count; i++)
                        {
                            Console.WriteLine($"#{i + 1} - {publisherGames[i]}");
                        }
                        double totalGames = games.Count;
                        double totalPublisher = publisherGames.Count;
                        double percentagePublisher = Math.Round((totalPublisher / totalGames) * 100, 2);

                        Console.WriteLine($"{percentagePublisher}%");
                        inputBool = true;

                    }
                    else
                    {
                        Console.WriteLine($"No games under the publisher {input} were found.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to execute");
                }
            }
        }
        static void GenreData(List<VideoGames> games)
        {
            bool inputBool = false;
            List<VideoGames> genreGames = new List<VideoGames>();
            while (inputBool == false)
            {
                Console.Write("What genre would you like to search for? ");
                string input = Console.ReadLine();
                try
                {
                    for (int i = 0; i < games.Count; i++)
                    {
                        if (games[i].Genre == input)
                        {
                            genreGames.Add(games[i]);
                        }
                    }
                    if (genreGames != null)
                    {


                        Console.WriteLine($"{input} Sorted");
                        genreGames.Sort();
                        for (int i = 0; i < genreGames.Count; i++)
                        {
                            Console.WriteLine($"#{i + 1} - {genreGames[i]}");
                        }
                        double totalGames = games.Count;
                        double totalGenre = genreGames.Count;
                        double percentageGenre = Math.Round((totalGenre / totalGames) * 100, 2);

                        Console.WriteLine($"{percentageGenre}%");
                        inputBool = true;

                    }
                    else
                    {
                        Console.WriteLine($"No games under the genre {input} were found.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to execute");
                }
            }
        }
    }
}