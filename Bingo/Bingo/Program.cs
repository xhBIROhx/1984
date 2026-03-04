using System;
using System.Collections.Generic;
using System.IO;
namespace Bingo
{
	class Program
	{
		static void Main(string[] args)
		{
			List<BingoJatekos> jatekosok = new List<BingoJatekos>();
			Random rand = new Random();
			var nevekFile = File.ReadAllLines("nevek.text");

			foreach (var nev in nevekFile)
			{
				string[,] kartya = new string[5, 5];
				var lines = File.ReadAllLines(nev.Trim());
				for (int i = 0; i < 5; i++)
				{
					var szamok = lines[i].Split(';');
					for (int j = 0; j < 5; j++)
					{
						kartya[i, j] = szamok[j];
					}
				}
				jatekosok.Add(new BingoJatekos(nev, kartya));
			}

			Console.WriteLine($"Játékosok száma: {jatekosok.Count}");

			List<int> kihuzottSzamok = new();
			bool vanBingo = false;
			while (!vanBingo)
			{
				int kihuzottSzam = rand.Next(1, 76);
				while (kihuzottSzamok.Contains(kihuzottSzam))
				{
					kihuzottSzam = rand.Next(1, 76);
				}
				kihuzottSzamok.Append(kihuzottSzam);
				Console.WriteLine($"Kihúzott szám: {kihuzottSzam}");

				foreach (BingoJatekos jatekos in jatekosok)
				{
					jatekos.SorsoltSzamotJelol(kihuzottSzam);
					if (jatekos.BingoEll())
					{
						Console.WriteLine($"{jatekos.Nev} nyert!");
						jatekos.KartyatMegjelenit();
						vanBingo = true;
						break;
					}
				}
			}
		}
	}
}