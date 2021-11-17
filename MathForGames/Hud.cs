using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using MathLibrary;

namespace Falsebound
{
    class Hud : Actor
    {
        private UIText _hudText;
        private Player _player;

        /// <summary>
        /// A basic constructor for the hud.
        /// </summary>
        /// <param name="player"> The player that the user controls and the hud will update them about. </param>
        public Hud(Player player)
        {
            _player = player;

            //Initializes the text box.
            _hudText = new UIText(10, 5, 0, "Hud Text", 150, 300, 12, "");
        }

        public override void Start()
        {
            base.Start();

            Scene currentScene = Engine.GetCurrentScene();

            currentScene.AddUIElement(_hudText);
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);

            // If the player has a selected marshal...
            if (_player.SelectedMarshal != null)
            {
                // ...Find the marshal and the members of their team.
                Marshal selectedMarshal = _player.SelectedMarshal;
                Monster teamMember1 = selectedMarshal.Team[0];
                Monster teamMember2 = selectedMarshal.Team[1];
                Monster teamMember3 = selectedMarshal.Team[2];

                // Print the name of the marshal and the stats of their team members.
                _hudText.Text = selectedMarshal.Name + "\n \n" + teamMember1.Name + "\n" + 
                    teamMember1.Health + " / " + teamMember1.MaxHealth + "\n" + teamMember1.AttackPower 
                    + "\n" + teamMember1.Defense + "\n \n" + teamMember2.Name + "\n" + 
                    teamMember2.Health + " / " + teamMember2.MaxHealth + "\n" + teamMember2.AttackPower 
                    + "\n" + teamMember2.Defense + "\n \n" + teamMember3.Name + "\n" + 
                    teamMember3.Health + " / " + teamMember3.MaxHealth + "\n" + teamMember3.AttackPower 
                    + "\n" + teamMember3.Defense;
            }
        }
    }
}
