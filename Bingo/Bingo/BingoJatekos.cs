using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
	internal class BingoJatekos
	{
		public string Nev { get; set; }
		public string[,] kartyak { get; set; }
		public bool[,] Talalatok { get; set; }

		public BingoJatekos(string nev, string[,] kartya)
		{
			Nev = nev;
			kartyak = kartya;
			Talalatok = new bool[5, 5]; // 5x5-es kártya

			for (int i = 0; i < 5; i++) 
			{
				for (int j = 0; j < 5; j++)
				{
					if (kartyak[i, j] == "X")
					{
						Talalatok[i, j] = true;
					}
				}
			}
		}

		public void SorsoltSzamotJelol(int szam)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (kartyak[i, j] == szam.ToString())
					{
						Talalatok[i, j] = true;
					}
				}
			}
		}

		public bool BingoEll()
		{
			// sor
			for (int i = 0; i < 5; i++)
			{
				bool nyert = true;
				for (int j = 0; j < 5; j++)
				{
					if (!Talalatok[i, j])
					{
						nyert = false;
						break;
					}
				}
				if (nyert)
					return true;
			}

			// oszlop
			for (int j = 0; j < 5; j++)
			{
				bool nyert = true;
				for (int i = 0; i < 5; i++)
				{
					if (!Talalatok[i, j])
					{
						nyert = false;
						break;
					}
				}
				if (nyert)
					return true;
			}

			// átlót
			bool nyertDiagonal1 = true;
			bool nyertDiagonal2 = true;

			for (int i = 0; i < 5; i++)
			{
				if (!Talalatok[i, i]) 
				{
					nyertDiagonal1 = false;
				}
				if (!Talalatok[i, 4 - i])
				{
					nyertDiagonal2 = false;
				}
			}

			return nyertDiagonal1 || nyertDiagonal2;
		}

		public void KartyatMegjelenit()
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (kartyak[i, j] == "X")
						Console.Write("X ".PadLeft(4));
					else if (Talalatok[i, j]) {
						Console.Write(kartyak[i, j].ToString().PadLeft(4));
					}
					else
						Console.Write("0".PadLeft(4));
				}
				Console.WriteLine();
			}
		}
	}
}
