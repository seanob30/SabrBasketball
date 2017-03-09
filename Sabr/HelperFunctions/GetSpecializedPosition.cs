using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sabr.Models;

namespace Sabr.HelperFunctions
{
    public class GetSpecializedPosition
    {
        public static string GetCurrentPlayerSpecialization(PerGameStatLine stat, int position)
        {
            if (position == 1)
            {
                try
                {
                    if (decimal.Parse(stat.Points) >= 22 && decimal.Parse(stat.TotalRebounds) >= 4 &&
                        decimal.Parse(stat.Assists) >= 6  && decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "All-Around Superstar";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.Points) >= 18 && decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "Two-Way Player";
                    }
                    else if (decimal.Parse(stat.Assists) >= 8)
                    {
                        return "Premier Playmaker";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        return "Sharpshooter";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Inside Scoring Machine";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 && decimal.Parse(stat.ThreePointersAttempted) * 10 >= 25)
                    {
                        return "Perimeter Threat";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 15)
                    {
                        return "Reliable Inside Scorer";
                    }
                    else if (decimal.Parse(stat.Blocks) >= 2 || decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "Lockdown Defender";
                    }
                    else if (decimal.Parse(stat.Assists) >= 6)
                    {
                        return "Reliable Playmaker";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 10)
                    {
                        return "Inside Scorer";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 5)
                    {
                        return "Reliable Rebounder";
                    }
                    else if (decimal.Parse(stat.Assists) >= 4)
                    {
                        return "Playmaker";
                    }
                    else
                    {
                        return "Role Player";
                    }
                }
                catch
                {
                    return "Role Player";
                }
            }
            else if (position == 2)
            {
                try
                {
                    if (decimal.Parse(stat.Points) >= 22 && decimal.Parse(stat.TotalRebounds) >= 5 &&
                        decimal.Parse(stat.Assists) >= 5  && decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "All-Around Superstar";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.Points) >= 18 && decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "Two-Way Player";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        return "Sharpshooter";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Inside Scoring Machine";
                    }
                    else if (decimal.Parse(stat.Assists) >= 7)
                    {
                        return "Premier Playmaker";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 && decimal.Parse(stat.ThreePointersAttempted) * 10 >= 25)
                    {
                        return "Perimeter Threat";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 15)
                    {
                        return "Reliable Inside Scorer";
                    }
                    else if (decimal.Parse(stat.Blocks) >= 2 || decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "Lockdown Defender";
                    }
                    else if (decimal.Parse(stat.Assists) >= 5)
                    {
                        return "Reliable Playmaker";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 10)
                    {
                        return "Inside Scorer";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 5)
                    {
                        return "Reliable Rebounder";
                    }
                    else if (decimal.Parse(stat.Assists) * 10 >= 35)
                    {
                        return "Playmaker";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 30)
                    {
                        return "Shooter";
                    }
                    else
                    {
                        return "Role Player";
                    }
                }
                catch
                {
                    return "Role Player";
                }
            }
            else if (position == 3)
            {
                try
                {
                    if (decimal.Parse(stat.Points) >= 22 && decimal.Parse(stat.TotalRebounds) >= 6 &&
                        decimal.Parse(stat.Assists) * 100 >= 475 && decimal.Parse(stat.Blocks) * 10 >= 3 && decimal.Parse(stat.Steals) >= 1)
                    {
                        return "All-Around Superstar";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.Points) >= 18 && decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "Two-Way Player";
                    }
                    else if (decimal.Parse(stat.Points) >= 18 && decimal.Parse(stat.Blocks) * 10 >= 15)
                    {
                        return "Two-Way Player";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Inside Scoring Machine";
                    }
                    else if (decimal.Parse(stat.Assists) >= 7)
                    {
                        return "Premier Playmaker";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        return "Sharpshooter";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 8)
                    {
                        return "Glass Cleaner";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 15)
                    {
                        return "Reliable Inside Scorer";
                    }
                    else if (decimal.Parse(stat.Assists) >= 5)
                    {
                        return "Reliable Playmaker";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 && decimal.Parse(stat.ThreePointersAttempted) * 10 >= 25)
                    {
                        return "Perimeter Threat";
                    }
                    else if (decimal.Parse(stat.Blocks) >= 2 || decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "Lockdown Defender";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 10)
                    {
                        return "Inside Scorer";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 6)
                    {
                        return "Reliable Rebounder";
                    }
                    else if (decimal.Parse(stat.Assists) * 10 >= 35)
                    {
                        return "Playmaker";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 30)
                    {
                        return "Shooter";
                    }
                    else
                    {
                        return "Role Player";
                    }
                }
                catch
                {
                    return "Role Player";
                }
            }
            else if (position == 4)
            {
                try
                {
                    if (decimal.Parse(stat.Points) >= 22 && decimal.Parse(stat.TotalRebounds) >= 7 &&
                        decimal.Parse(stat.Assists) >= 2 && decimal.Parse(stat.Blocks) * 10 >= 15 && 
                        decimal.Parse(stat.Steals) * 10 >= 8)
                    {
                        return "All-Around Superstar";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.Points) >= 15 && decimal.Parse(stat.Steals)  >= 1)
                    {
                        return "Two-Way Player";
                    }
                    else if (decimal.Parse(stat.Points) >= 15 && decimal.Parse(stat.Blocks) * 10 >= 15)
                    {
                        return "Two-Way Player";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Low Post Star";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 9)
                    {
                        return "Glass Cleaner";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        return "Sharpshooter";
                    }
                    else if (decimal.Parse(stat.Blocks) >= 2 || decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "Lockdown Defender";
                    }
                    else if (decimal.Parse(stat.Assists) >= 5)
                    {
                        return "Premier Playmaking Big";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 7)
                    {
                        return "Reliable Rebounder";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 15)
                    {
                        return "Inside Scoring Machine";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 && decimal.Parse(stat.ThreePointersAttempted) * 10 >= 25)
                    {
                        return "Perimeter Threat";
                    }
                    else if (decimal.Parse(stat.Assists) >= 4)
                    {
                        return "Playmaking Big";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 10)
                    {
                        return "Inside Scorer";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 5)
                    {
                        return "Rebounder";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 30)
                    {
                        return "Shooter";
                    }
                    else
                    {
                        return "Role Player";
                    }
                }
                catch
                {
                    return "Role Player";
                }
            }
            else if (position == 5)
            {
                try
                {
                    if (decimal.Parse(stat.Points) >= 20 && decimal.Parse(stat.TotalRebounds) >= 9 &&
                        decimal.Parse(stat.Assists) >= 2 && decimal.Parse(stat.Blocks) * 10 >= 15
                        && decimal.Parse(stat.Steals) * 10 >= 5)
                    {
                        return "All-Around Superstar";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Offensive Superstar";
                    }
                    else if (decimal.Parse(stat.Points) >= 15 && decimal.Parse(stat.Steals) >= 1)
                    {
                        return "Two-Way Player";
                    }
                    else if (decimal.Parse(stat.Points) >= 15 && decimal.Parse(stat.Blocks) * 10 >= 15)
                    {
                        return "Two-Way Player";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 20)
                    {
                        return "Low Post Star";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 10)
                    {
                        return "Glass Cleaner";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 40 && decimal.Parse(stat.ThreePointersAttempted) >= 3)
                    {
                        return "Sharpshooter";
                    }
                    else if (decimal.Parse(stat.Blocks) >= 2 || decimal.Parse(stat.Steals) * 10 >= 15)
                    {
                        return "Rim Protector";
                    }
                    else if (decimal.Parse(stat.Assists) >= 5)
                    {
                        return "Premier Playmaking Big";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 8)
                    {
                        return "Reliable Rebounder";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 15)
                    {
                        return "Inside Scoring Machine";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 35 && decimal.Parse(stat.ThreePointersAttempted) * 10 >= 25)
                    {
                        return "Perimeter Threat";
                    }
                    else if (decimal.Parse(stat.Assists) >= 4)
                    {
                        return "Playmaking Big";
                    }
                    else if (decimal.Parse(stat.TwoPointPercentage) * 100 >= 50 && decimal.Parse(stat.Points) >= 10)
                    {
                        return "Inside Scorer";
                    }
                    else if (decimal.Parse(stat.TotalRebounds) >= 5)
                    {
                        return "Rebounder";
                    }
                    else if (decimal.Parse(stat.ThreePointPercentage) * 100 >= 30)
                    {
                        return "Shooter";
                    }
                    else
                    {
                        return "Role Player";
                    }
                }
                catch
                {
                    return "Role Player";
                }

            }
            return "Role Player";
        }
    }
}