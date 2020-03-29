using System;
using System.Collections.Generic;
using System.Text;

namespace CSPkmGen
{
    class Trainer
    {
        Random r = new Random();

        string name;
        ushort trainerID;
        ushort secretID;

        public Trainer(string name)
        {
            this.name = name;
            this.trainerID = (ushort)r.Next(65536);
            this.secretID = (ushort)r.Next(65536);
        }

        public string getName()
        {
            return this.name;
        }

        public ushort getTrainerID()
        {
            return this.trainerID;
        }

        public ushort getSecretID()
        {
            return this.secretID;
        }
    }
}
