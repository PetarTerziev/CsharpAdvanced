using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            byte bulletPrice = byte.Parse(Console.ReadLine());
            ushort gunBarelSize = ushort.Parse(Console.ReadLine());
            Stack<byte> bullets = new Stack<byte>(Console.ReadLine().Split().Select(byte.Parse).ToArray());
            Queue<byte> locks = new Queue<byte>(Console.ReadLine().Split().Select(byte.Parse).ToArray());
            int intelligenceValue = int.Parse(Console.ReadLine());
            int totalBulletFired = 0;
            ushort gunFire = 0;


            while (locks.Count > 0 && bullets.Count > 0)
            {
                int bulletSize = bullets.Pop();

                if (locks.Peek() >= bulletSize)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                totalBulletFired++;
                gunFire++;

                if (gunFire == gunBarelSize && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    gunFire = 0;
                }
            }

            int moneyEarned = intelligenceValue - totalBulletFired * bulletPrice;

            if (locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
