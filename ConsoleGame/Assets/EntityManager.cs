using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Assets
{
    class EntityManager
    {
        Entity entity;

        public void CreateEntity()
        {
            entity = new Entity();
            entity.Avanzar();
        }
    }
}
