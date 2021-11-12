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
        private Monster[] _turnOrder = new Monster[6];
        private Monster _currentMonster;

        public BattleScene() : base() { }

        /// <summary>
        /// Begins the battle by setting the positions of the monsters.
        /// </summary>
        /// <param name="teamOne"> The first team of monsters. </param>
        /// <param name="teamTwo"> The second team of monsters. </param>
        public void StartBattle(Monster[] teamOne, Monster[] teamTwo)
        {
            // Adds the monsters in team one to the scene.
            for (int i = 0; i < teamOne.Length; i++)
                AddActor(teamOne[i]);
            // Adds the monsters in team two to the scene.
            for (int i = 0; i < teamTwo.Length; i++)
                AddActor(teamTwo[i]);

            // Sets the positions for the monster's in team one.
            teamOne[0].SetTranslation(0, 1, 5);
            teamOne[1].SetTranslation(5, 1, 5);
            teamOne[2].SetTranslation(-5, 1, 5);

            // Sets the positions for the monsters in team two.
            teamTwo[0].SetTranslation(0, 1, -5);
            teamTwo[1].SetTranslation(5, 1, -5);
            teamTwo[2].SetTranslation(-5, 1, -5);
        }
    }
}
