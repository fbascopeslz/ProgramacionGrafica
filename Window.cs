using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace ProgramacionGrafica
{
    class Window : GameWindow
    {
        int angle;
        int s;

        float speed = 0.2f;

        Vector3 position = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

        float largo = 80;
        float alto = 80;
        float ancho = 80;

        Escenario escenario;

        public Window(int width, int height) : base(width, height, GraphicsMode.Default, "Programacion Grafica")
        {
            //VSync = VSyncMode.On;

            //angle = 1;
            //s = 1;                                 
        }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Indigo);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-300, 300, -300, 300, -300, 300);
                        


            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            //GL.DepthMask(true);
            GL.Enable(EnableCap.DepthTest);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Modelview);

            /*Matrix4 modelview = Matrix4.LookAt(position, position + front, up);            
            GL.LoadMatrix(ref modelview);
            
            GL.Translate(0.0f, 0.0f, -15.0f);

            angle = angle + 5;

            GL.PushMatrix();
            GL.Rotate(s, 0.0f, 1.0f, 0.0f);
            GL.Scale(1.5f, 1.5f, 1.5f);
                       
            GL.Color3(0.0f, 2.0f, 1.0f);            
            GL.PopMatrix();
           
            GL.PushMatrix();
            GL.Translate(5.0f, 0.0f, 0.0f);
            GL.Scale(1.5f, 1.5f, 1.5f);                                 

            GL.PopMatrix();*/


            Dictionary<string, Objeto> objetos = this.listaDeObjetos();
            this.escenario = new Escenario(objetos);
            escenario.dibujar();


            SwapBuffers();
            base.OnRenderFrame(e);
        }

        /*protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.Width, this.Height);

            base.OnResize(e);
            

            float aspect_ratio = Width / (float)Height;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            //Matrix4 projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView((float)(Math.PI * 57 / 180.0), aspect_ratio, 1.0f, 3048 - 1848);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }*/

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            GL.Rotate(1.0f, 0.0f, 0.1f, 0.0f);

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Key.ControlLeft))
            {
                s = s + 1;
            }

            if (!Focused)
            {
                return;
            }

            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.W))
            {
                position += front * speed;
            }

            if (input.IsKeyDown(Key.S))
            {
                position -= front * speed;
            }

            if (input.IsKeyDown(Key.A))
            {
                position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (input.IsKeyDown(Key.D))
            {
                position += Vector3.Normalize(Vector3.Cross(front, up)) * speed;
            }

            if (input.IsKeyDown(Key.Space))
            {
                position += up * speed;
            }

            if (input.IsKeyDown(Key.LShift))
            {
                position -= up * speed;
            }

            if (state.IsKeyDown(Key.Escape))
            {
                Exit();
            }


            base.OnUpdateFrame(e);
        }

        public Dictionary<string, Objeto> listaDeObjetos()
        {
            //PIRAMIDE
            List<Vector3> vertices1 = new List<Vector3>();
            vertices1.Add(new Vector3(-50f, 0f, 0f));
            vertices1.Add(new Vector3(0f, 100f, 0f));
            vertices1.Add(new Vector3(0f, 0f, -50f));

            List<Vector3> vertices2 = new List<Vector3>();
            vertices2.Add(new Vector3(50f, 0f, 0f));
            vertices2.Add(new Vector3(0f, 100f, 0f));
            vertices2.Add(new Vector3(0f, 0f, 50f));

            List<Vector3> vertices3 = new List<Vector3>();
            vertices3.Add(new Vector3(-50f, 0f, 0f));
            vertices3.Add(new Vector3(0f, 100f, 0f));
            vertices3.Add(new Vector3(0f, 0f, 50f));

            List<Vector3> vertices4 = new List<Vector3>();
            vertices4.Add(new Vector3(0f, 0f, -50f));
            vertices4.Add(new Vector3(50f, 0f, 0f));
            vertices4.Add(new Vector3(0f, 100f, 0f));

            List<Cara> caras = new List<Cara>();
            caras.Add(new Cara(vertices1, new Vector3(0f, 0f, 0f), Color.Violet));
            caras.Add(new Cara(vertices2, new Vector3(0f, 0f, 0f), Color.Red));
            caras.Add(new Cara(vertices3, new Vector3(0f, 0f, 0f), Color.LightBlue));
            caras.Add(new Cara(vertices4, new Vector3(0f, 0f, 0f), Color.LightYellow));

            List<Cara> caras2 = new List<Cara>();
            caras2.Add(new Cara(vertices1, new Vector3(0f, 0f, 0f), Color.Black));
            caras2.Add(new Cara(vertices2, new Vector3(0f, 0f, 0f), Color.FloralWhite));
            caras2.Add(new Cara(vertices3, new Vector3(0f, 0f, 0f), Color.LightSeaGreen));
            caras2.Add(new Cara(vertices4, new Vector3(0f, 0f, 0f), Color.Blue));

            //CUBO
            List<Vector3> vertices5 = new List<Vector3>();
            vertices5.Add(new Vector3(-50f, 50f, -50f));
            vertices5.Add(new Vector3(50f, 50f, -50f));
            vertices5.Add(new Vector3(50f, -50f, -50f));
            vertices5.Add(new Vector3(-50f, -50f, -50f));

            List<Vector3> vertices6 = new List<Vector3>();
            vertices6.Add(new Vector3(-50f, 50f, 50f));
            vertices6.Add(new Vector3(-50f, 50f, -50f));
            vertices6.Add(new Vector3(-50f, -50f, -50f));
            vertices6.Add(new Vector3(-50f, -50f, 50f));

            List<Vector3> vertices7 = new List<Vector3>();
            vertices7.Add(new Vector3(50f, 50f, 50f));
            vertices7.Add(new Vector3(50f, 50f, -50f));
            vertices7.Add(new Vector3(50f, -50f, -50f));
            vertices7.Add(new Vector3(50f, -50f, 50f));

            List<Vector3> vertices8 = new List<Vector3>();
            vertices8.Add(new Vector3(-50f, 50f, 50f));
            vertices8.Add(new Vector3(50f, 50f, 50f));
            vertices8.Add(new Vector3(50f, -50f, 50f));
            vertices8.Add(new Vector3(-50f, -50f, 50f));

            List<Vector3> vertices9 = new List<Vector3>();
            vertices9.Add(new Vector3(-50f, 50f, 50f));
            vertices9.Add(new Vector3(50f, 50f, 50f));
            vertices9.Add(new Vector3(50f, 50f, -50f));
            vertices9.Add(new Vector3(-50f, 50f, -50f));

            List<Vector3> vertices10 = new List<Vector3>();
            vertices10.Add(new Vector3(-50f, -50f, 50f));
            vertices10.Add(new Vector3(50f, -50f, 50f));
            vertices10.Add(new Vector3(50f, -50f, -50f));
            vertices10.Add(new Vector3(-50f, -50f, -50f));

            List<Cara> caras3 = new List<Cara>();
            caras3.Add(new Cara(vertices5, new Vector3(0f, 0f, 0f), Color.Violet));
            caras3.Add(new Cara(vertices6, new Vector3(0f, 0f, 0f), Color.LightSkyBlue));
            caras3.Add(new Cara(vertices7, new Vector3(0f, 0f, 0f), Color.Red));
            caras3.Add(new Cara(vertices8, new Vector3(0f, 0f, 0f), Color.Pink));
            caras3.Add(new Cara(vertices9, new Vector3(0f, 0f, 0f), Color.White));
            caras3.Add(new Cara(vertices10, new Vector3(0f, 0f, 0f), Color.Azure));


            Dictionary<string, Objeto> objetos = new Dictionary<string, Objeto>();
            objetos.Add("Piramide 1", new Objeto(caras, new Vector3(-100f, -100f, -100f), "Piramide 1"));
            objetos.Add("Piramide 2", new Objeto(caras2, new Vector3(100f, 100f, 100f), "Piramide 2"));
            objetos.Add("Cubo 1", new Objeto(caras3, new Vector3(0f, 0f, 0f), "Cubo 1"));

            return objetos;
        }
        
    }
}
