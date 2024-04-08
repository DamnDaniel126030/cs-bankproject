namespace BankProject
{
    /// <summary>
    /// Bank műveleteit végrehajtó osztály.
    /// </summary>
    public class Bank
    {
        private class Szamla
        {
            public string Nev { get; set; }
            public string Szamlaszam { get; set; }

            public ulong Egyenleg { get; set; }

            public Szamla(string nev, string szamLaszam)
            {
                Nev = nev;
                Szamlaszam = szamLaszam;
                Egyenleg = 0;
            }

        }

        private List<Szamla> szamlak = new List<Szamla>();
        /// <summary>
        /// Új számlát nyit a megadott névvel, számlaszámmal, 0 Ft egyenleggel
        /// </summary>
        /// <param name="nev">A számla tulajdonosának neve</param>
        /// <param name="szamlaszam">A számla számlaszáma</param>
        /// <exception cref="ArgumentNullException">A név és a számlaszám nem lehet null</exception>
        /// <exception cref="ArgumentException">A név és a számlaszám nem lehet üres
        /// A számlaszámmal nem létezhet számla
        /// A számlaszám számot, szóközt és kötőjelet tartalmazhat</exception>
        public void UjSzamla(string nev, string szamlaszam)
        {
            if (nev == null)
            {
                throw new ArgumentNullException(nameof(nev));
            }
			if (szamlaszam == null)
			{
				throw new ArgumentNullException(nameof(szamlaszam));
			}
			if (nev == "")
			{
				throw new ArgumentException("A név nem lehet üres",nameof(nev));
			}
			if (szamlaszam == "")
			{
				throw new ArgumentException("A számlaszám nem lehet üres", nameof(szamlaszam));
			}

            int idx = 0;
            while (idx < szamlak.Count && szamlak[idx].Szamlaszam != szamlaszam)
            {
                idx++;
            }
            if (idx < szamlak.Count)
            {
                throw new ArgumentException("A megadott számlaszámmal létezik számla", nameof(szamlaszam));
            }

            Szamla szamla = new Szamla(nev, szamlaszam);
            szamlak.Add(szamla);
		}

        /// <summary>
        /// Lekérdezi az adott számlán lévő pénzösszeget
        /// </summary>
        /// <param name="szamlaszam">A számla számlaszáma, aminek az egyenlegét keressük</param>
        /// <returns>A számlán lévő egyenleg</returns>
        /// <exception cref="ArgumentNullException">A számlaszám nem lehet null</exception>
        /// <exception cref="ArgumentException">A számlaszám számot, szóközt és kötőjelet tartalmazhat</exception>
        /// <exception cref="HibasSzamlaszamException">A megadott számlaszámmal nem létezik számla</exception>
        public ulong Egyenleg(string szamlaszam)
        {
            return 0;
        }

        /// <summary>
        /// Egy létező számlára pénzt helyez
        /// </summary>
        /// <param name="szamlaszam">A számla számlaszáma, amire pénzt helyez</param>
        /// <param name="osszeg">A számlára helyezendő pénzösszeg</param>
        /// <exception cref="ArgumentNullException">A számlaszám nem lehet null</exception>
        /// <exception cref="ArgumentException">Az összeg csak pozitív lehet.
        /// A számlaszám számot, szóközt és kötőjelet tartalmazhat</exception>
        /// <exception cref="HibasSzamlaszamException">A megadott számlaszámmal nem létezik számla</exception>
        public void EgyenlegFeltolt(string szamlaszam, ulong osszeg)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Két számla között utal.
        /// Ha nincs elég pénz a forrás számlán, akkor false értékkel tér vissza
        /// </summary>
        /// <param name="honnan">A forrás számla számlaszáma</param>
        /// <param name="hova">A cél számla számlaszáma</param>
        /// <param name="osszeg">Az átutalandó egyenleg</param>
        /// <returns>Az utalás sikeressége</returns>
        /// <exception cref="ArgumentNullException">A forrás és cél számlaszám nem lehet null</exception>
        /// <exception cref="ArgumentException">Az összeg csak pozitív lehet.
        /// A számlaszám számot, szóközt és kötőjelet tartalmazhat</exception>
        /// <exception cref="HibasSzamlaszamException">A megadott számlaszámmal nem létezik számla</exception>
        public bool Utal(string honnan, string hova, ulong osszeg)
        {
            throw new NotImplementedException();
        }
    }
}
