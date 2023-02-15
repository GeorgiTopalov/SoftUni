using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
                IDye currentDye = bunny.Dyes.FirstOrDefault(x => x.IsFinished() == false);

                if (bunny.Energy == 0 || currentDye == default)
                {
                    break;
                }
                bunny.Work();
                currentDye.Use();
                egg.GetColored();

                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
