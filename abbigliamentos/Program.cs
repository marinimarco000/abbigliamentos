namespace abbigliamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int siono = 0;
            List<string> nome = new List<string>();
            List<string> cat = new List<string>();
            List<double> prezzo = new List<double>();
            List<bool> disponibilita = new List<bool>();
            double prezzotot = 0;
            double mediaprezzo = 0;
            string[] data = File.ReadAllLines("prodotti_abbigliamento.csv");
            for (int i = 1; i < data.Length; i++)
            {
                string[] riga = data[i].Split(",");
                nome.Add(riga[1]);
                cat.Add(riga[2]);
                string prezzosost = riga[3].Replace(".", ",");
                prezzo.Add(Convert.ToDouble(prezzosost));
                if (riga[4] == "Non disponibile")
                {
                    disponibilita.Add(false);
                }
                else
                {
                    disponibilita.Add(true);
                }

            }
            for (int i = 0; i < prezzo.Count; i++)
            {

                prezzotot = prezzotot + prezzo[i];

            }
            mediaprezzo = prezzotot / prezzo.Count;
            Console.WriteLine($"costo totale dei vestiti {mediaprezzo}");
            for (int i = 0; i < disponibilita.Count; i++)
            {
                if (disponibilita[i] == false)
                {
                    siono++;
                }
            }
            Console.WriteLine($"in tutto ci sono {siono} prodotti non disponibili");
            List<string> categoria = new List<string>();
            for (int i = 0; i < cat.Count; i++) 
            {
                if (!categoria.Contains(cat[i])) 
                { 
                    categoria.Add(cat[i]);
                }
            }
            Console.WriteLine($"in tutto ci sono {categoria.Count} categorie");

            List<double> prezziaggiornati = prezzo;
            for(int i = 0; i < prezzo.Count; i++) 
            {
                prezziaggiornati[i] = prezzo[i] * 1.10;
            }
            using (StreamWriter sw = new StreamWriter("prodotti_abbligliamento_aggiornati.csv")) 
            {
                sw.WriteLine("NOME,CATEGORIE,PREZZO,DISPONIBILITA");
                for(int i = 0; i < nome.Count; i++) 
                {
                    sw.WriteLine(nome[i] +"," +  cat[i]  +  prezziaggiornati[i]  +  disponibilita[i]);
                }
            }

            foreach(string c in categoria)
            {
                using (StreamWriter sw = new StreamWriter(c+".csv"))
                {
                    sw.WriteLine("categoria "+c);
                    for (int i = 0; i < nome.Count; i++)
                    {
                        if (cat[i] == c)
                        {
                            sw.WriteLine(nome[i] + cat[i] + prezziaggiornati[i] + disponibilita[i]);
                        }
                    }

                }
            }
            

        }
    }
}
