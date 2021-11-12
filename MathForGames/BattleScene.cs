using System;
using System.Collections.Generic;
using System.Text;

namespace Falsebound
{
    class BattleScene : Scene
    {
        private Marshal _marshalOne;
        private Monster[] _teamOne = new Monster[3];
        private Marshal _marshalTwo;
        private Monster[] _teamTwo = new Monster[3];

        public BattleScene() : base() { }

        public void StartBattle(Monster[] teamOne, Monster[] teamTwo)
        {
            for (int i = 0; i < teamOne.Length; i++)
                AddActor(teamOne[i]);
            for (int i = 0; i < teamTwo.Length; i++)
                AddActor(teamTwo[i]);

            teamOne[0].SetTranslation(0, 0, 5);
            teamOne[1].SetTranslation(5, 0, 5);
            teamOne[2].SetTranslation(-5, 0, 5);

            teamTwo[0].SetTranslation(0, 0, -5);
            teamTwo[1].SetTranslation(5, 0, -5);
            teamTwo[2].SetTranslation(-5, 0, -5);
        }
    }
}
