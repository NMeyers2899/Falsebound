using System;
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
        private Scene[] _scenes = new Scene[0];
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

            Scene battle = new Scene();

            // Initalizes the player.
            Player player = new Player(0, 0, 0, 15);
            player.SetColor(new Vector4(0, 200, 0, 255));
            player.SetScale(1, 0.5f, 1);
            SphereCollider playerCollider = new SphereCollider(1, player);
            player.Collider = playerCollider;

            // Initalizes the actor that hovers above the player.
            Actor hand = new Actor(0, 20, 0, "Hand", Shape.SPHERE, player);
            hand.SetColor(new Vector4(0, 200, 0, 255));
            player.AddChild(hand);

            // Initalizes the allied marshal.
            Marshal marshal = new Marshal(10, 0, 0, 15);
            marshal.SetColor(new Vector4(0, 0, 255, 255));
            marshal.SetScale(2, 2, 2);
            SphereCollider marshalCollider = new SphereCollider(2, marshal);
            marshal.Collider = marshalCollider;

            // Initalizes the enemy marshal.
            Marshal enemyMarshal = new Marshal(-10, 0, 20, 15);
            enemyMarshal.SetColor(new Vector4(0, 0, 255, 255));
            enemyMarshal.SetScale(2, 2, 2);
            SphereCollider enemyMarshalCollider = new SphereCollider(2, enemyMarshal);
            enemyMarshal.Collider = enemyMarshalCollider;

            // Adds the required actors to the overworld scene.
            overworld.AddActor(player);
            overworld.AddActor(marshal);
            overworld.AddActor(enemyMarshal);

            // Adds the required actors to the battle scene.
            battle.AddActor(player);

            // Adds the scenes to the engine.
            AddScene(overworld);
            AddScene(battle);

            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called each time the game loops.
        /// </summary>
        private void Update(float deltaTime)
        {
            Actor playerCharacter = _scenes[0].Actors[0];

            if (playerCharacter is Player)
            {
                _camera.position = new System.Numerics.Vector3(playerCharacter.WorldPosition.X,
                playerCharacter.WorldPosition.Y + 20, playerCharacter.WorldPosition.Z + 25);
                _camera.target = new System.Numerics.Vector3(playerCharacter.WorldPosition.X,
                    0, playerCharacter.WorldPosition.Z);
            }


            _scenes[_currentSceneIndex].Update(deltaTime, _scenes[_currentSceneIndex]);
            _scenes[_currentSceneIndex].UpdateUI(deltaTime, _scenes[_currentSceneIndex]);

            // Keeps inputs from piling up, allowing one input per update.
            while (Console.KeyAvailable)
                Console.ReadKey(true);
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

            _scenes[_currentSceneIndex].Draw();
            _scenes[_currentSceneIndex].DrawUI();

            Raylib.EndMode3D();
            Raylib.EndDrawing();
        }

        /// <summary>
        /// Is called when the application is about to close.
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
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

        public static void MoveToNextScene()
        {
            _currentSceneIndex++;
        }
    }
}
