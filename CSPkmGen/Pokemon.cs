using System;
using System.Collections.Generic;
using System.Text;

namespace CSPkmGen
{
    public class Pokemon
    {

        Random r = new Random();

        int id;
        int hpIV;
        int atIV;
        int deIV;
        int saIV;
        int sdIV;
        int spIV;
        uint personality;

        public Pokemon(int id)
        {
            this.id = id;
            genIVs();
            this.personality = personalityGen();
        }

        public int getHP()
        {
            return this.hpIV;
        }

        public uint getPersonality()
        {
            return this.personality;
        }

        private void genIVs()
        {
            this.hpIV = r.Next(32);
            this.atIV = r.Next(32);
            this.deIV = r.Next(32);
            this.saIV = r.Next(32);
            this.sdIV = r.Next(32);
            this.spIV = r.Next(32);
        }

        private uint personalityGen()
        {
            // https://stackoverflow.com/questions/17080112/generate-random-uint
            uint thirtyBits = (uint)r.Next(1 << 30);
            uint twoBits = (uint)r.Next(1 << 2);
            uint fullRange = (thirtyBits << 2) | twoBits;
            return fullRange;
        }

        public bool checkShiny(UInt16 trainerID, UInt16 secretID, bool gen7)
        {

            byte[] perBytes = BitConverter.GetBytes(this.personality);
            UInt16 upper = (UInt16)(this.personality >> 16);
            UInt16 lower = (UInt16)(this.personality & 0xFFFF);
            ushort val = (ushort)(trainerID ^ secretID ^ upper ^ lower);
            if (gen7)
            {
                return val < 16;
            } else
            {
                return val < 8;
            }
        }

        public int getShinyVal(ushort trainerID, ushort secretID)
        {
            byte[] perBytes = BitConverter.GetBytes(this.personality);
            UInt16 upper = (UInt16)(this.personality >> 16);
            UInt16 lower = (UInt16)(this.personality & 0xFFFF);
            return (ushort)(trainerID ^ secretID ^ upper ^ lower);
        }
    }
}
