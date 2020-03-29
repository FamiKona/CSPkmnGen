using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSPkmGen;

namespace PkmTests
{
    [TestClass]
    public class UnitTest1
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
    }
}
