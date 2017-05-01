using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sabr.Models;

namespace Sabr.HelperFunctions
{
    public class GetSabrMetrics
    {
        public static int GetSabrMetric(PerGameStatLine stat, int position)
        {
            try
            {
                if (position == 1 || position == 2)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 15;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 12;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) > 8)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) > 4)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.Assists) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 8)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 4)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) > 4)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) >= 2)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }
                    if (sabrMetric > 100)
                    {
                        return 100;
                    }
                    else
                    {
                        return sabrMetric;
                    }
                    
                }
                else if (position == 3)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 13;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 11;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 8)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) > 5)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.Assists) > 4)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.Assists) >= 1)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 8)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 4)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) >= 4)
                    {
                        sabrMetric -= 5;
                    }
                    else if (decimal.Parse(stat.Turnovers) * 10 >= 35)
                    {
                        sabrMetric -= 4;
                    }
                    else if (decimal.Parse(stat.Turnovers) >= 2)
                    {
                        sabrMetric -= 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 <= 29 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 1)
                    {
                        sabrMetric -= 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) * 10 >= 15)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }
                    if (sabrMetric > 100)
                    {
                        return 100;
                    }
                    else
                    {
                        return sabrMetric;
                    }
                }
                else if (position == 4 || position == 5)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 6;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Points) > 4)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 7)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) >= 5)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Assists) >= 4)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) >= 3)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Assists) >= 1)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) >= 12)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 10)
                    {
                        sabrMetric += 9;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 8)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 6)
                    {
                        sabrMetric += 6;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 4)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) > 4)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 67 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 50 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 <= 40 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) >= 2)
                    {
                        sabrMetric += 5;
                    }
                    if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        sabrMetric += 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }
                    if (sabrMetric > 100)
                    {
                        return 100;
                    }
                    else
                    {
                        return sabrMetric;
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int GetHistoricalSabrMetric(HistoricalPerGameStatLine stat, int position)
        {
            try
            {
                if (position == 1 || position == 2)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 15;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 12;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) > 8)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) > 4)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.Assists) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 8)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 4)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) > 4)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) >= 2)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }
                    if (sabrMetric > 100)
                    {
                        return 100;
                    }
                    else
                    {
                        return sabrMetric;
                    }
                }
                else if (position == 3)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 13;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 11;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 8)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) > 5)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.Assists) > 4)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.Assists) >= 1)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) > 10)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 8)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 4)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) > 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) >= 4)
                    {
                        sabrMetric -= 5;
                    }
                    else if (decimal.Parse(stat.Turnovers) * 10 >= 35)
                    {
                        sabrMetric -= 4;
                    }
                    else if (decimal.Parse(stat.Turnovers) >= 2)
                    {
                        sabrMetric -= 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 <= 29 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 1)
                    {
                        sabrMetric -= 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) * 10 >= 15)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }
                    if (sabrMetric > 100)
                    {
                        return 100;
                    }
                    else
                    {
                        return sabrMetric;
                    }
                }
                else if (position == 4 || position == 5)
                {
                    int sabrMetric = 65;

                    //POINTS
                    if (decimal.Parse(stat.Points) > 30)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Points) > 25)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.Points) > 20)
                    {
                        sabrMetric += 6;
                    }
                    else if (decimal.Parse(stat.Points) > 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Points) >= 10)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Points) > 4)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //ASSISTS
                    if (decimal.Parse(stat.Assists) > 7)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.Assists) >= 5)
                    {
                        sabrMetric += 7;
                    }
                    else if (decimal.Parse(stat.Assists) >= 4)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Assists) >= 3)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Assists) >= 1)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //REBOUNDS
                    if (decimal.Parse(stat.TotalRebounds) >= 12)
                    {
                        sabrMetric += 10;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 10)
                    {
                        sabrMetric += 9;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 8)
                    {
                        sabrMetric += 8;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 6)
                    {
                        sabrMetric += 6;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 4)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 2)
                    {
                        sabrMetric += 0;
                    }
                    else
                    {
                        sabrMetric -= 5;
                    }

                    //TURNOVERS
                    if (decimal.Parse(stat.Turnovers) < 3 && decimal.Parse(stat.Assists) > 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Turnovers) < 1 && decimal.Parse(stat.MinutesPlayed) > 15)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.Turnovers) > 4)
                    {
                        sabrMetric -= 4;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //FREE THROWS
                    if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 90 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 85 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 80 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 70 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 2;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 67 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric += 0;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 60 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 1;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 < 50 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.FreeThrowPercentage) * 100 <= 40 &&
                             decimal.Parse(stat.FreeThrowsAttempted) > 1)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //3 POINT %
                    if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 &&
                        decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 33 &&
                             decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        sabrMetric += 1;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //2 POINT %
                    if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 60 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 5;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 55 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 46 &&
                        decimal.Parse(stat.TwoPointersAttempted) >= 6)
                    {
                        sabrMetric += 1;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 40)
                    {
                        sabrMetric -= 3;
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 < 35)
                    {
                        sabrMetric -= 5;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //BLOCKS
                    if (decimal.Parse(stat.Blocks) >= 2)
                    {
                        sabrMetric += 5;
                    }
                    if (decimal.Parse(stat.Blocks) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }

                    //STEALS
                    if (decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        sabrMetric += 4;
                    }
                    else if (decimal.Parse(stat.Steals) >= 1)
                    {
                        sabrMetric += 3;
                    }
                    else if (decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        sabrMetric += 2;
                    }
                    else
                    {
                        sabrMetric += 0;
                    }
                    if (sabrMetric > 100)
                    {
                        return 100;
                    }
                    else
                    {
                        return sabrMetric;
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}