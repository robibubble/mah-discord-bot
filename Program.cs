﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mah_discord_bot
{
    class Program
    {

        static void Main(string[] args)
        { 

            Console.WriteLine("token: " + Config.bot.token);
            Console.WriteLine("cmdPrefix: " + Config.bot.cmdPrefix);
            Console.ReadLine();
        }
    }
}
