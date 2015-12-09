using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Nook
{
    class Player : Sprite
    {
        float xAccel, yAccel, xVel, yVel, initVel = 30, maxAccel = 5, maxVel = 50, jumpValue = 120;
        bool hasJumped, hasLanded = true, hasStoppedMoving = false, isSteppingOnAPlatform = false;
        Vector2f posPrev;

        public Player(Texture texture)
        {
            this.Texture = texture;
        }

        public void Move(float x, float y)
        {
            this.posPrev = this.Position;
            this.Position = new Vector2f(this.Position.X + x, this.Position.Y + y);
            //xVel = this.Position.X - posPrev.X;
            //yVel = this.Position.Y - posPrev.Y;
            //posPrev = this.Position;
            //this.Position = new Vector2f(this.Position.X + xVel + x, this.Position.Y + yVel + y);
        }

        public float XAccel
        {
            get { return this.xAccel; }
            set { this.xAccel = value; }
        }

        public float YAccel
        {
            get { return this.yAccel; }
            set { this.yAccel = value; }
        }

        public float XVel
        {
            get { return this.xVel; }
            set { this.xVel = value; }
        }

        public float YVel
        {
            get { return this.yVel; }
            set { this.yVel = value; }
        }

        public float InitVel
        {
            get { return this.initVel; }
            set { this.initVel = value; }
        }

        public float MaxAccel
        {
            get { return this.maxAccel; }
            set { this.maxAccel = value; }
        }

        public float MaxVel
        {
            get { return this.maxVel; }
            set { this.maxVel = value; }
        }

        public float JumpValue
        {
            get { return this.jumpValue; }
            set { this.jumpValue = value; }
        }

        public bool HasJumped
        {
            get { return this.hasJumped; }
            set { this.hasJumped = value; }
        }

        public bool HasLanded
        {
            get { return this.hasLanded; }
            set { this.hasLanded = value; }
        }

        public bool HasStoppedMoving
        {
            get { return this.hasStoppedMoving; }
            set { this.hasStoppedMoving = value; }
        }

        public bool IsSteppingOnAPlatform
        {
            get { return this.isSteppingOnAPlatform; }
            set { this.isSteppingOnAPlatform = value; }
        }

        public Vector2f PosPrev
        {
            get { return this.posPrev; }
            set { this.posPrev = value; }
        }

        public float UpperBound
        {
            get { return this.Position.Y; }
        }

        public float LowerBound
        {
            get { return this.Position.Y + this.TextureRect.Height; }
        }

        public float LeftBound
        {
            get { return this.Position.X; }
        }

        public float RightBound
        {
            get { return this.Position.X + this.TextureRect.Width; }
        }

        public float ClampXCoord(float testValue)
        {
            if (testValue < this.Position.X)
            {
                testValue = this.Position.X;
            }
            else if (testValue > this.Position.X + this.TextureRect.Width)
            {
                testValue = this.Position.X + this.TextureRect.Width;
            }

            return testValue;
        }

        public float ClampYCoord(float testValue)
        {
            if (testValue < this.Position.Y)
            {
                testValue = this.Position.Y;
            }
            else if (testValue > this.Position.Y + this.TextureRect.Height)
            {
                testValue = this.Position.Y + this.TextureRect.Height;
            }

            return testValue;
        }
    }

    class Ball : Sprite
    {
        float xAccel, yAccel, xVel, yVel, maxAccel = 10, maxVel = 75, radius;

        public Ball(Texture texture)
        {
            this.Texture = texture;
            this.radius = this.TextureRect.Width / 2;
        }

        public void Move(float x, float y)
        {
            this.Position = new Vector2f(this.Position.X + x, this.Position.Y + y);
        }

        public float XAccel
        {
            get { return this.xAccel; }
            set { this.xAccel = value; }
        }

        public float YAccel
        {
            get { return this.yAccel; }
            set { this.yAccel = value; }
        }

        public float XVel
        {
            get { return this.xVel; }
            set { this.xVel = value; }
        }

        public float YVel
        {
            get { return this.yVel; }
            set { this.yVel = value; }
        }

        public float MaxAccel
        {
            get { return this.maxAccel; }
            set { this.maxAccel = value; }
        }

        public float MaxVel
        {
            get { return this.maxVel; }
            set { this.maxVel = value; }
        }

        public float Radius
        {
            get { return this.radius; }
            set { this.radius = value; }
        }
        
        public Vector2f Center
        {
            get { return new Vector2f(this.Position.X + radius, this.Position.Y + radius); }
        }
    }

    class Platform : Sprite
    {
        float xAccel, yAccel, xVel, yVel;
        List<Player> players = new List<Player>();
        Vector2f posPrev;

        public Platform(Texture texture)
        {
            this.Texture = texture;
        }

        public void Move(float x, float y)
        {
            this.posPrev = this.Position;
            this.Position = new Vector2f(this.Position.X + x, this.Position.Y + y);
        }

        public float XAccel
        {
            get { return this.xAccel; }
            set { this.xAccel = value; }
        }

        public float YAccel
        {
            get { return this.yAccel; }
            set { this.yAccel = value; }
        }

        public float XVel
        {
            get { return this.xVel; }
            set { this.xVel = value; }
        }

        public float YVel
        {
            get { return this.yVel; }
            set { this.yVel = value; }
        }

        public Vector2f PosPrev
        {
            get { return this.posPrev; }
            set { this.posPrev = value; }
        }

        public List<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public float UpperBound
        {
            get { return this.Position.Y; }
        }

        public float LowerBound
        {
            get { return this.Position.Y + this.TextureRect.Height; }
        }

        public float LeftBound
        {
            get { return this.Position.X; }
        }

        public float RightBound
        {
            get { return this.Position.X + this.TextureRect.Width; }
        }

        public Vector2f Center
        {
            get { return new Vector2f(this.Position.X + (this.TextureRect.Width / 2), this.Position.Y + (this.TextureRect.Height / 2)); }
        }
    }

    class Program
    {
        //------------------------------Declare Game Variables/Retrieve Sprites------------------------------
        const float gravity = 13f;
        const float deltaTime = 0.01f;
        static List<KeyEventArgs> keyboardEventHandler = new List<KeyEventArgs>();
        static ContextSettings context = new ContextSettings();
        static RenderWindow window = new RenderWindow(new VideoMode(500, 600), "Nook", Styles.Close, context);
        static int windowLeftBound = 0, windowRightBound = (int)window.Size.X, windowUpperBound = 0, windowLowerBound = (int)window.Size.Y;
        static Random randomizer = new Random();
        static Player player1 = new Player(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(0, 0, 20, 45)));
        static Player player2 = new Player(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(0, 0, 20, 45)));
        static Ball centerBall = new Ball(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(0, 0, 20, 20)));
        static Ball ball1 = new Ball(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(windowRightBound / 2, windowUpperBound + 10, 30, 30)));
        static Platform fixedPlatform1 = new Platform(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(randomizer.Next(windowLeftBound, windowRightBound - 100), randomizer.Next(100, 200), 100, 10)));
        static Platform fixedPlatform2 = new Platform(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(randomizer.Next(windowLeftBound, windowRightBound - 100), randomizer.Next(100, 200), 100, 10)));
        static Platform fixedPlatform3 = new Platform(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(randomizer.Next(windowLeftBound, windowRightBound - 100), randomizer.Next(100, 200), 100, 10)));
        static Platform fixedPlatform4 = new Platform(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(randomizer.Next(windowLeftBound, windowRightBound - 100), randomizer.Next(100, 200), 100, 10)));
        static Platform movingPlatform1 = new Platform(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(randomizer.Next(windowLeftBound, windowRightBound - 100), randomizer.Next(100, 200), 100, 10)));
        static Platform movingPlatform2 = new Platform(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(randomizer.Next(windowLeftBound, windowRightBound - 100), randomizer.Next(100, 200), 100, 10)));
        static Platform movingPlatform3 = new Platform(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(randomizer.Next(windowLeftBound, windowRightBound - 100), randomizer.Next(100, 200), 100, 10)));
        static Platform movingPlatform4 = new Platform(new Texture("shibuya_crossing_by_fatlittlenick.jpg", new IntRect(randomizer.Next(windowLeftBound, windowRightBound - 100), randomizer.Next(100, 200), 100, 10)));
        static VertexArray movingPlatform1Anchor = new VertexArray(PrimitiveType.LinesStrip, 2);
        static VertexArray movingPlatform2Anchor = new VertexArray(PrimitiveType.LinesStrip, 2);
        static VertexArray movingPlatform3Anchor = new VertexArray(PrimitiveType.LinesStrip, 2);
        static VertexArray movingPlatform4Anchor = new VertexArray(PrimitiveType.LinesStrip, 2);
        static float movingPlatformMinX = windowRightBound / 10, movingPlatformMaxX = 9 * windowRightBound / 10; //400 10
        static float movingPlatformMinY = 2 * windowLowerBound / 10, movingPlatformMaxY = 8 * windowLowerBound / 10; //360 9

        static void UpdatePlayerMovement(Player player)
        {
            //------------------------------Apply Gravity------------------------------
            if (player.HasLanded)
            {
                player.YAccel = 0;
                player.YVel = 0;
                player.HasJumped = false;
            }
            else
            {
                player.HasJumped = true;
                player.YAccel += gravity * deltaTime;
                player.YVel += player.YAccel * deltaTime;
                if (player.Position.Y + player.TextureRect.Height > windowLowerBound)
                {
                    player.Position = new Vector2f(player.Position.X, (int)(windowLowerBound - player.TextureRect.Height));
                    player.YAccel = 0;
                    player.YVel = 0;
                    player.HasJumped = false;
                    player.HasLanded = true;
                }
            }

            //------------------------------Detect Collision with Left Boundary of Window------------------------------
            if (player.Position.X < windowLeftBound)
            {
                player.XAccel = 0;
                player.XVel = 0;
                player.Position = new Vector2f(windowLeftBound, player.Position.Y);
            }

            //------------------------------Detect Collision with Right Boundary of Window------------------------------
            if (player.Position.X + player.TextureRect.Width > windowRightBound)
            {
                player.XAccel = 0;
                player.XVel = 0;
                player.Position = new Vector2f(windowRightBound - player.TextureRect.Width, player.Position.Y);
            }

            //------------------------------Gradually Slow the Player Down to a Stop------------------------------
            if (player.HasStoppedMoving && player.HasLanded)
            {
                if (player.XVel > 0)
                {
                    player.XVel -= 0.5f;
                }
                else if (player.XVel < 0)
                {
                    player.XVel += 0.5f;
                }
                else
                {
                    player.HasStoppedMoving = false;
                }
            }

            player.Move(player.XVel * deltaTime * 0.5f, player.YVel * deltaTime * 0.5f);
        }

        static void UpdateBallMovement(Ball ball)
        {
            //------------------------------Detect Collision with Left/Right Boundary of the Window------------------------------
            if (ball.Position.X < windowLeftBound || ball.Position.X + ball.TextureRect.Width > windowRightBound)
            {
                ball.XVel = -ball.XVel;
            }

            //------------------------------Detect Collision with Upper/Lower Boundary of the Window------------------------------
            if (ball.Position.Y < windowUpperBound || ball.Position.Y + ball.TextureRect.Height > windowLowerBound)
            {
                ball.YVel = -ball.YVel;
            }

            ball.Move(ball.XVel * deltaTime * 0.5f, ball.YVel * deltaTime * 0.5f);
        }

        static void UpdatePlatformMovement(Platform platform, VertexArray anchor)
        {
            if (platform.Position.X < movingPlatformMinX || platform.Position.X + platform.TextureRect.Width > movingPlatformMaxX)
            {
                platform.XVel = -platform.XVel;
            }

            if (platform.Position.Y < movingPlatformMinY || platform.Position.Y > movingPlatformMaxY)
            {
                platform.YVel = -platform.YVel;
            }

            platform.Move(platform.XVel * deltaTime * 0.5f, platform.YVel * deltaTime * 0.5f);
            anchor[0] = new Vertex(platform.Center);
            anchor[1] = new Vertex(centerBall.Center);

        }

        static void CheckIfPlayerCollidesWithPlatform(Player player, List<Platform> platformArray)
        {
            foreach (Platform testPlatform in platformArray)
            {
                if ((player.UpperBound >= testPlatform.UpperBound && player.UpperBound <= testPlatform.LowerBound) && ((player.LeftBound >= testPlatform.LeftBound && player.RightBound <= testPlatform.RightBound) || (player.RightBound >= testPlatform.LeftBound && player.RightBound <= testPlatform.RightBound)))
                {
                    player.Move(0, 1);
                    player.YVel = -player.YVel;
                    break;
                }
                else if (((player.LowerBound >= testPlatform.UpperBound && player.LowerBound <= testPlatform.LowerBound) || (player.LowerBound >= testPlatform.LowerBound && player.UpperBound <= testPlatform.UpperBound)) && ((player.LeftBound >= testPlatform.LeftBound && player.LeftBound <= testPlatform.RightBound) || (player.RightBound >= testPlatform.LeftBound && player.RightBound <= testPlatform.RightBound)))
                {
                    if (!testPlatform.Players.Contains(player))
                    {
                        player.HasLanded = true;
                        testPlatform.Players.Add(player);
                        player.Position = new Vector2f(player.Position.X, testPlatform.UpperBound - player.TextureRect.Height);
                    }
                }

                if (testPlatform.Players.Contains(player))
                {
                    if (!((player.LeftBound >= testPlatform.LeftBound && player.RightBound <= testPlatform.RightBound) || (player.RightBound >= testPlatform.LeftBound && player.RightBound <= testPlatform.RightBound)) || (!player.HasLanded))
                    {
                        player.HasLanded = false;
                        testPlatform.Players.Remove(player);
                        break;
                    }
                    else
                    {
                        player.Position = new Vector2f(player.Position.X, testPlatform.UpperBound - player.TextureRect.Height);
                        break;
                    }
                }
            }
        }

        //for-loop/array version of platform-player collision detection
        //static void test(Player player)
        //{
        //    Platform[] platformArray = new Platform[4] { platform1, platform2, platform3, platform4 };
        //    for (int i = 0; i < platformArray.Length; i++)
        //    {
        //        //------------------------------Computes for left, right, upper, and lower bounds of the player's sprite------------------------------
        //        bool isLowerLeftVertexInsidePlatformBoundary = ((int)player.Position.X >= (int)platformArray[i].Position.X) && ((int)player.Position.X <= (int)platformArray[i].Position.X + platformArray[i].TextureRect.Width);
        //        bool isLowerRightVertexInsidePlatformBoundary = ((int)player.Position.X + player.TextureRect.Width >= (int)platformArray[i].Position.X) && ((int)player.Position.X + player.TextureRect.Width <= (int)platformArray[i].Position.X + platformArray[i].TextureRect.Width);
        //        bool isIntersectingWithPlatform = (player.Position.Y <= platformArray[i].Position.Y) && (player.Position.Y + player.TextureRect.Height >= platformArray[i].Position.Y);
        //        if (isIntersectingWithPlatform)
        //        {
        //            if ((isLowerLeftVertexInsidePlatformBoundary || isLowerRightVertexInsidePlatformBoundary) && player.PosPrev.Y + player.TextureRect.Height <= platformArray[i].Position.Y)
        //            {
        //                player.Position = new Vector2f(player.Position.X, platformArray[i].Position.Y - player.TextureRect.Height);
        //                player.HasLanded = true;
        //                player.IsSteppingOnAPlatform = true;
        //                break;
        //            }
        //        }
        //        else if (player.IsSteppingOnAPlatform)
        //        {
        //            player.IsSteppingOnAPlatform = false;
        //            player.HasLanded = false;
        //        }
        //    }
        //}

        static void CheckIfBallCollidesWithPlayer(Player player, Ball ball)
        {
            Vector2f ballCenter = new Vector2f(ball.Position.X + ball.Radius, ball.Position.Y + ball.Radius);
            float distanceBallXtoPlayerX = ballCenter.X - player.ClampXCoord(ballCenter.X);
            float distanceBallYtoPlayerY = ballCenter.Y - player.ClampYCoord(ballCenter.Y);
            float distance = (float)Math.Sqrt(distanceBallXtoPlayerX * distanceBallXtoPlayerX + distanceBallYtoPlayerY * distanceBallYtoPlayerY);
            if (distance < ball.TextureRect.Width / 2)
            {
                // do nothing / collision!
            }
        }

        static void Main(string[] args)
        {
            //------------------------------Initialize Values------------------------------
            player1.Position = new Vector2f(windowLeftBound + 50, windowLowerBound - player1.TextureRect.Height);
            player2.Position = new Vector2f(windowRightBound - player2.TextureRect.Width - 50, windowLowerBound - player2.TextureRect.Height);
            ball1.Position = new Vector2f(windowRightBound / 2, windowUpperBound + ball1.TextureRect.Height + 10);
            centerBall.Position = new Vector2f(windowRightBound / 2 - centerBall.Radius, windowLowerBound / 2 - centerBall.Radius);
            ball1.XVel = 30;
            ball1.YVel = 40;
            fixedPlatform1.Position = new Vector2f(windowLeftBound, windowLowerBound / 6);
            fixedPlatform2.Position = new Vector2f(windowLeftBound, 5 * windowLowerBound / 6);
            fixedPlatform3.Position = new Vector2f(windowRightBound - fixedPlatform3.TextureRect.Width, windowLowerBound / 6);
            fixedPlatform4.Position = new Vector2f(windowRightBound - fixedPlatform4.TextureRect.Width, 5 * windowLowerBound / 6);
            movingPlatform1.Position = new Vector2f(movingPlatformMinX, movingPlatformMinY + (movingPlatformMaxY - movingPlatformMinY) / 2);
            movingPlatform2.Position = new Vector2f(movingPlatformMinX + (movingPlatformMaxX - movingPlatformMinX) / 2 - movingPlatform2.TextureRect.Width / 2, movingPlatformMinY);
            movingPlatform3.Position = new Vector2f(movingPlatformMaxX - movingPlatform3.TextureRect.Width, movingPlatformMinY + (movingPlatformMaxY - movingPlatformMinY) / 2);
            movingPlatform4.Position = new Vector2f(movingPlatformMinX + (movingPlatformMaxX - movingPlatformMinX) / 2 - movingPlatform2.TextureRect.Width / 2, movingPlatformMaxY);
            movingPlatform1.XVel = 10; movingPlatform1.YVel = -12;
            movingPlatform2.XVel = 10; movingPlatform2.YVel = 12;
            movingPlatform3.XVel = -10; movingPlatform3.YVel = 12;
            movingPlatform4.XVel = -10; movingPlatform4.YVel = -12;

            window.KeyPressed += Window_KeyPressed;
            window.KeyReleased += Window_KeyReleased;
            List<Platform> platformCollection = new List<Platform>() { fixedPlatform1, fixedPlatform2, fixedPlatform3, fixedPlatform4, movingPlatform1, movingPlatform2, movingPlatform3, movingPlatform4 };

            //3 Random Stages: Horizontal moving platforms, rotating platforms in the middles, appear disappear

            //------------------------------Game Loop------------------------------
            while (window.IsOpen)
            {
                
                window.DispatchEvents();
                UpdatePlayerMovement(player1);
                UpdatePlayerMovement(player2);
                UpdateBallMovement(ball1);
                UpdatePlatformMovement(movingPlatform1, movingPlatform1Anchor);
                UpdatePlatformMovement(movingPlatform2, movingPlatform2Anchor);
                UpdatePlatformMovement(movingPlatform3, movingPlatform3Anchor);
                UpdatePlatformMovement(movingPlatform4, movingPlatform4Anchor);
                window.Clear();
                foreach (Platform platform in platformCollection)
                {
                    window.Draw(platform);
                }
                window.Draw(centerBall);
                window.Draw(ball1);
                window.Draw(player1);
                window.Draw(player2);
                window.Draw(movingPlatform1Anchor);
                window.Draw(movingPlatform2Anchor);
                window.Draw(movingPlatform3Anchor);
                window.Draw(movingPlatform4Anchor);
                window.Display();
                CheckIfPlayerCollidesWithPlatform(player1, platformCollection);
                CheckIfPlayerCollidesWithPlatform(player2, platformCollection);
                CheckIfBallCollidesWithPlayer(player1, ball1);
                CheckIfBallCollidesWithPlayer(player2, ball1);

            }
        }

        private static void Window_KeyReleased(object sender, KeyEventArgs e)
        {
            keyboardEventHandler.Clear();
            player1.HasStoppedMoving = true;
            player1.XAccel = 0;
            player2.HasStoppedMoving = true;
            player2.XAccel = 0;
        }

        private static void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            //------------------------------Player 1 Control Module------------------------------
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                if (player1.XVel == 0)
                {
                    player1.XVel = -player1.InitVel;
                }
                if (player1.XAccel > -player1.MaxAccel)
                {
                    player1.XAccel -= 1;
                }
                if (player1.XVel > -player1.MaxVel)
                {
                    player1.XVel += player1.XAccel;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    player1.HasLanded = false;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                if (player1.XVel == 0)
                {
                    player1.XVel = player1.InitVel;
                }
                if (player1.XAccel < player1.MaxAccel)
                {
                    player1.XAccel += 1;
                }
                if (player1.XVel < player1.MaxVel)
                {
                    player1.XVel += player1.XAccel;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    player1.HasLanded = false;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                if (!player1.HasJumped)
                {
                    player1.HasJumped = true;
                    if (player1.IsSteppingOnAPlatform)
                    {
                        player1.IsSteppingOnAPlatform = false;
                    }
                    if (player1.HasLanded)
                    {
                        player1.HasLanded = false;
                    }
                    player1.Move(0, -1);
                    player1.YVel = -player1.JumpValue;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.C))
            {
                player1.YVel = 0;
                player1.Move(player1.XVel * 2, 0);
            }

            //------------------------------Player 2 Control Module------------------------------
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                if (player2.XVel == 0)
                {
                    player2.XVel = -player2.InitVel;
                }
                if (player2.XAccel > -player2.MaxAccel)
                {
                    player2.XAccel -= 1;
                }
                if (player2.XVel > -player2.MaxVel)
                {
                    player2.XVel += player2.XAccel;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    player2.HasLanded = false;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                if (player2.XVel == 0)
                {
                    player2.XVel = player2.InitVel;
                }
                if (player2.XAccel < player2.MaxAccel)
                {
                    player2.XAccel += 1;
                }
                if (player2.XVel < player2.MaxVel)
                {
                    player2.XVel += player2.XAccel;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    player2.HasLanded = false;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                if (!player2.HasJumped)
                {
                    player2.HasJumped = true;
                    if (player2.IsSteppingOnAPlatform)
                    {
                        player2.IsSteppingOnAPlatform = false;
                    }
                    if (player2.HasLanded)
                    {
                        player2.HasLanded = false;
                    }
                    player2.Move(0, -1);
                    player2.YVel = -player2.JumpValue;
                }
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                window.Close();
            }
        }
    }
}