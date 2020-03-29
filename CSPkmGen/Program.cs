using System;
using System.Collections;

namespace CSPkmGen
{
    class Program
    {

        private Trainer trainer;
        private int runtime;
        static bool gen7;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello! What is your name?");
            string name = Console.ReadLine();
            bool gen7InputOK = false;
            Console.WriteLine("Use the Gen 7 math? (Y/N)");
            while (!gen7InputOK)
            {
                string gen7Input = Console.ReadLine();
                if (gen7Input.ToUpper().Equals("Y"))
                {
                    gen7 = true;
                    gen7InputOK = true;
                } else if (gen7Input.ToUpper().Equals("N"))
                {
                    gen7 = false;
                    gen7InputOK = true;
                } else
                {
                    Console.WriteLine("Please input Y or N.");
                }
            }
            

            Program p = new Program();

            p.genTrainer(name);

            ArrayList al = new ArrayList();

            for (int i = 0; i < 1000; i++)
            {
                al.Add(p.bruh());
            }


            int total = 0;

            foreach (int element in al)
            {
                total += element;
            }

            double avg = total / al.Count;

            Console.WriteLine("That took an average of {0} attempts, and a total of {1} attempts!", avg, total);
        }

        void genTrainer(string name)
        {
            trainer = new Trainer(name);
        }

        int bruh()
        {
            bool gotShiny = false;
            int catches = 0;

            while (!gotShiny)
            {
                Pokemon a = new Pokemon(1);
                catches++;
                if (a.checkShiny(trainer.getTrainerID(), trainer.getSecretID(), gen7))
                {
                    gotShiny = true;
                }
            }

            runtime++;
            string output = String.Format("{1}) You caught a X after {0} tries!", catches, runtime);
            Console.WriteLine(output);
            return catches;

        }
    }
}
