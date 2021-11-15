﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using MathLibrary;
using Raylib_cs;

namespace Falsebound
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private static Scene[] _scenes = new Scene[0];
        private Stopwatch _stopWatch = new Stopwatch();
        private Camera3D _camera = new Camera3D();

        /// <summary>
        /// Called to begin the application.
        /// </summary>
        public void Run()
        {
            // Initalizes important variables for the application.
            Start();

            float currentTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            // Loop until the application is told to close.
            while (!(Raylib.WindowShouldClose() || _applicationShouldClose))
            {
                // Get how much time has passed since the application started.
                currentTime = _stopWatch.ElapsedMilliseconds / 1000.0f;

                // Set delta time to be the difference in time from the last time recorded.
                deltaTime = currentTime - lastTime;

                // Update the application.
                Update(deltaTime);
                // Draw all items.
                Draw();

                // Set the last time recorded to be the current time.
                lastTime = currentTime;
            }

            End();
        }

        private void InitializeCamera()
        {
            // Camera position.
            _camera.position = new System.Numerics.Vector3(0, 10, 10);
            // Point the camera is focused on.
            _camera.target = new System.Numerics.Vector3(0, 0, 0);
            // Camera up vector(rotation towards target).
            _camera.up = new System.Numerics.Vector3(0, 1, 0);
            // Camera's field of view Y.
            _camera.fovy = 60;
            // Camera mode type.
            _camera.projection = CameraProjection.CAMERA_PERSPECTIVE;
        }

        /// <summary>
        /// Initalizes important variables for the application.
        /// </summary>
        private void Start()
        {
            _stopWatch.Start();

            // Creates a window using Raylib.
            Raylib.InitWindow(800, 450, "Math For Games");
            Raylib.SetTargetFPS(60);
            InitializeCamera();

            // Initalizes the overworld scene.
            Scene overworld = new Scene();

            // Initalizes the battle scene.
            BattleScene battle = new BattleScene();

            // Adds the scenes to the engine.
            AddScene(overworld);
            AddScene(battle);

            // Initalizes the monsters.
            Monster wompus = new Monster(0, 0, 0, 10, 120, 30, 25, 3, "Wompus");
            wompus.SetColor(new Vector4(220, 120, 54, 255));

            Monster skelly = new Monster(0, 0, 0, 15, 115, 37, 15, 4, "Skelly");
            skelly.SetColor(new Vector4(220, 120, 0, 255));

            Monster thaeve = new Monster(0, 0, 0, 22, 74, 21, 16, 3, "Thaeve");
            thaeve.SetColor(new Vector4(120, 0, 54, 255));

            Monster aLittleDude = new Monster(0, 0, 0, 16, 92, 23, 16, 4, "A Little Dude");
            aLittleDude.SetColor(new Vector4(150, 120, 0, 255));

            Monster facelessHorror = new Monster(0, 0, 0, 10, 112, 29, 28, 4, "Faceless Horror");
            facelessHorror.SetColor(new Vector4(0, 120, 0, 255));

            Monster thwompus = new Monster(0, 0, 0, 8, 140, 20, 38, 2, "Thwompus");
            thwompus.SetColor(new Vector4(220, 0, 225, 255));

            // Initalizes the player.
            Player player = new Player(0, 1, 0, 25);
            player.SetColor(new Vector4(0, 200, 0, 150));
            player.SetScale(1, 0.5f, 1);
            SphereCollider playerCollider = new SphereCollider(1, player);
            player.Collider = playerCollider;

            // Initalizes the actor that hovers above the player.
            Actor hand = new Actor(0, 20, 0, "Hand", Shape.SPHERE, player);
            hand.SetColor(new Vector4(0, 200, 0, 150));
            player.AddChild(hand);

            // Initalizes the allied marshal.
            Marshal marshal = new Marshal(10, 1, 0, "Vizza");
            marshal.SetColor(new Vector4(0, 0, 255, 255));
            marshal.SetScale(2, 2, 2);
            SphereCollider marshalCollider = new SphereCollider(2, marshal);
            marshal.Collider = marshalCollider;
            marshal.Team[0] = Monster.CopyMonster(marshal.Team[0], wompus);
            marshal.Team[1] = Monster.CopyMonster(marshal.Team[1], wompus);
            marshal.Team[2] = Monster.CopyMonster(marshal.Team[2], wompus);

            // Initalizes the enemy marshal.
            Marshal enemyMarshal = new Marshal(-10, 1, 20, "Haladar");
            enemyMarshal.SetColor(new Vector4(255, 0, 0, 255));
            enemyMarshal.SetScale(2, 2, 2);
            SphereCollider enemyMarshalCollider = new SphereCollider(2, enemyMarshal);
            enemyMarshal.Collider = enemyMarshalCollider;
            enemyMarshal.AddTeamMemeber(aLittleDude, 0);
            enemyMarshal.AddTeamMemeber(facelessHorror, 1);
            enemyMarshal.AddTeamMemeber(thwompus, 2);

            // Creates the hud.
            Hud hud = new Hud(player);

            // Adds the required actors to the overworld scene.
            overworld.AddActor(player);
            overworld.AddActor(marshal);
            overworld.AddActor(enemyMarshal);
            overworld.AddActor(hud);

            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called each time the game loops.
        /// </summary>
        private void Update(float deltaTime)
        {
            UpdateCamera();

            _scenes[_currentSceneIndex].Update(deltaTime);
            _scenes[_currentSceneIndex].UpdateUI(deltaTime);

            // Keeps inputs from piling up, allowing one input per update.
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        /// <summary>
        /// Updates the position of the camera based on the scene and the actor in the first position.
        /// </summary>
        private void UpdateCamera()
        {
            // Sets the player character equal to the first actor in the first scene.
            Actor playerCharacter = _scenes[0].Actors[0];

            // If the current scene is not a battle scene...
            if (!((_scenes[_currentSceneIndex]) is BattleScene))
            {
                // ...set the position of the camera above the player.
                _camera.position = new System.Numerics.Vector3(playerCharacter.WorldPosition.X,
                            playerCharacter.WorldPosition.Y + 20, playerCharacter.WorldPosition.Z + 25);
                // And set the target to the player's current location.
                _camera.target = new System.Numerics.Vector3(playerCharacter.WorldPosition.X,
                    0, playerCharacter.WorldPosition.Z);
            }
            // If the current scene is a battle scene...
            else
            {
                // Set the camera to a fixed position.
                _camera.position = new System.Numerics.Vector3(10, 4, -10);
                _camera.target = new System.Numerics.Vector3(0, 1, 0);
            }
        }

        /// <summary>
        /// Draws all necessary information to the screen.
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode3D(_camera);

            Raylib.ClearBackground(Color.WHITE);
            Raylib.DrawGrid(50, 1);
            // Draws all of the non-UI actors in the scene.
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndMode3D();
            // Draws all of the UI elements in the scene.
            _scenes[_currentSceneIndex].DrawUI();

            Raylib.EndDrawing();
        }

        /// <summary>
        /// Is called when the application is about to close.
        /// </summary>
        private void End()
        {
            _scenes[(int)_currentSceneIndex].End();
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Adds a new scene to the _scenes array.
        /// </summary>
        /// <param name="scene"> The new scene being added to the array. </param>
        /// <returns> The index that the new scene was added to. </returns>
        public int AddScene(Scene scene)
        {
            // Creates a temporary array.
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            // Copies all of the old values from the array and adds them to the new array.
            for (int i = 0; i < _scenes.Length; i++)
                tempArray[i] = _scenes[i];

            // Sets the last index to be a new scene.
            tempArray[_scenes.Length] = scene;

            // Set the old array to the new array.
            _scenes = tempArray;

            // Return the last index.
            return _scenes.Length - 1;
        }

        /// <summary>
        /// Gets the next key in the input stream.
        /// </summary>
        /// <returns> Whether or not a key was pressed. </returns>
        public static ConsoleKey GetNextKey()
        {
            // If there is no key being pressed...
            if (!Console.KeyAvailable)
                // ...return.
                return 0;

            // Return the current key being pressed.
            return Console.ReadKey(true).Key;
        }

        /// <summary>
        /// Sets _applicationShouldClose to true.
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }

        /// <summary>
        /// Takes in two arrays associated with the teams of two marshals and sets the scene to battle.
        /// </summary>
        /// <param name="teamOne"> The first marshal's team. </param>
        /// <param name="teamTwo"> The second marshal's team. </param>
        public static void MoveToBattleScene(Monster[] teamOne, Monster[] teamTwo)
        {
            _currentSceneIndex = 1;
            (_scenes[_currentSceneIndex] as BattleScene).StartBattle(teamOne, teamTwo);
        }

        /// <summary>
        /// Finds the current scene.
        /// </summary>
        /// <returns> The current scene. </returns>
        public static Scene GetCurrentScene()
        {
            return _scenes[_currentSceneIndex];
        }
    }
}
