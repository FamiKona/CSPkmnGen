using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSPkmGen;

namespace PkmTests
{
    [TestClass]
    public class Shininess
    {
        [TestMethod]
        public void CanGenerateShiny()
        {
            int counter = 0;
            int limit = 1000000;
            bool shinyFound = false;
            Trainer trainer = new Trainer("name");

            while (!shinyFound && counter < limit)
            {
                Pokemon a = new Pokemon(1);
                if (a.checkShiny(trainer.getTrainerID(), trainer.getSecretID(), true))
                {
                    shinyFound = true;
                }
            }

            Assert.AreEqual(true, shinyFound, "no shiny was found after {0} attempts", limit);
        }

        [TestMethod]
        public void ShinyIsAccurate()
        {
            Trainer trainer = new Trainer("name");
            
            for (int i = 0; i < 40; i++)
            {
                bool shinyFound7 = false;
                bool shinyFound = false;
                while (!shinyFound7)
                {
                    Pokemon a = new Pokemon(1);
                    if (a.checkShiny(trainer.getTrainerID(), trainer.getSecretID(), true))
                    {
                        shinyFound7 = true;
                        int shinyVal = a.getShinyVal(trainer.getTrainerID(), trainer.getSecretID());
                        bool valid = (shinyVal < 16) && (shinyVal >= 0);
                        Assert.IsTrue(valid, "shiny value (gen 7) is out of range");
                    }
                }

                while (!shinyFound)
                {
                    Pokemon a = new Pokemon(1);
                    if (a.checkShiny(trainer.getTrainerID(), trainer.getSecretID(), false))
                    {
                        shinyFound = true;
                        int shinyVal = a.getShinyVal(trainer.getTrainerID(), trainer.getSecretID());
                        bool valid = (shinyVal < 8) && (shinyVal >= 0);
                        Assert.IsTrue(valid, "shiny value (NOT gen 7) is out of range");
                    }
                }
            }
        }
    }
}
