/**

*--------------------------------------------------------------------

* File name: VideoGames.cs

* Project name: Lab 1 Review Lab

*--------------------------------------------------------------------

* Author’s name and email: Jericho McGowan || mcgowanj2@etsu.edu

* Course-Section: CSCI-2910-001

* Creation Date: 9/1/2023

* -------------------------------------------------------------------

*/
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Video_Games
{
    internal class VideoGames : IComparable<VideoGames>
    {
        //Name,Platform,Year,Genre,Publisher,NA_Sales,EU_Sales,JP_Sales,Other_Sales,Global_Sales
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NA_Sales { get; set; }
        public double EU_Sales { get; set; }
        public double JP_Sales { get; set; }
        public double Other_Sales { get; set; }
        public double Global_Sales { get; set; }

        public VideoGames()
        {
            this.Name = "N/A";
            this.Platform = "N/A";
            this.Year = 2000;
            this.Genre = "N/A";
            this.Publisher = "N/A";
            this.NA_Sales = 0;
            this.EU_Sales = 0;
            this.JP_Sales = 0;
            this.Other_Sales = 0;
            this.Global_Sales = 0;
        }
        public VideoGames(string name, string platform, int year, string genre, string publisher, double na_Sales, double eu_Sales, double jp_Sales, double other_Sales, double global_Sales)
        {
            Name = name;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NA_Sales = na_Sales;
            EU_Sales = eu_Sales;
            JP_Sales = jp_Sales;
            Other_Sales = other_Sales;
            Global_Sales = global_Sales;
        }

        public int CompareTo(VideoGames? other)
        {
            if (other == null) return 1;
            int compare = this.Name.CompareTo(other.Name);
            if(compare != 0) return compare;
            else //If compare is the same as other.Name then compare by Publisher
            {
                compare = this.Publisher.CompareTo(other.Publisher);
            }
            return compare;
        }

        public override string ToString()
        {
            return $"{this.Name} | {this.Platform} | {this.Year} | {this.Genre} | {this.Publisher} | {this.NA_Sales} | {this.EU_Sales} | {this.JP_Sales} | {this.Other_Sales} | {this.Global_Sales}\n";
        }
    }
}
