using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    // By creating this abstract class, it's allowed to add new types of assistant coaches without any change 
    // in code, resulting in satisfying Open-Closed Principle.
    abstract class AssistantCoach : Coach
    {
        public abstract void TrainPlayers(List<Player> players);
    }
}
