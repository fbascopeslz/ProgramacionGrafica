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

        //OBJLoader o;
        List<Escenario> escenarios;

        Escenario escenario;

        public Window(int width, int height) : base(width, height, GraphicsMode.Default, "")
        {
            VSync = VSyncMode.On;
            angle = 1;
            s = 1;

            escenarios = new List<Escenario>();

            escenario = new Escenario();

            escenarios.Add(escenario);
        }


        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);

            //o = new OBJLoader("house_type12");

            //escenario.addObjeto(new Cubo("cubo.xml"));
            //escenario.addObjeto(new Cubo("piramide.xml"));
            escenario.addObjeto(new Cubo());
            escenario.addObjeto(new Cubo());
            //escenario.addObjeto(new Piramide());

            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            //Matrix4 modelview = Matrix4.LookAt(new Vector3(0.0f, 0.0f, 8.0f),new Vector3(0.0f, 0.0f, -1.0f),new Vector3(0.0f, 1.0f, 0.0f));

            Matrix4 modelview = Matrix4.LookAt(position, position + front, up);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);


            int indiceat = 0;

            GL.Translate(0.0f, 0.0f, -15.0f);

            angle = angle + 5;
            //GL.Rotate(10, 0.0f, 0.0f, 1.0f);



            GL.PushMatrix();
            GL.Rotate(s, 0.0f, 1.0f, 0.0f);

            GL.Scale(1.5f, 1.5f, 1.5f);
            
            //drawPiramide();

            GL.Color3(0.0f, 2.0f, 1.0f);
            //o.Draw(modelview);
            GL.PopMatrix();

            //drawCubo();


            GL.PushMatrix();
            GL.Translate(5.0f, 0.0f, 0.0f);
            GL.Scale(1.5f, 1.5f, 1.5f);
            //drawCubo();


            /*foreach (Objeto objetos in escenario.getObjetos())
            {
                objetos.rotar(s);
                objetos.dibujar2();
            }*/

            escenario.dibujar();

            GL.PopMatrix();


            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, this.Width, this.Height);

            float aspect_ratio = Width / (float)Height;
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            //Matrix4 projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView((float)(Math.PI * 57 / 180.0)/*MathHelper.PiOver2*/, aspect_ratio, 1.0f, 3048 - 1848);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
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

        }



        public void drawCubo()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.End();
        }


        public void drawPiramide()
        {
            GL.Begin(PrimitiveType.Polygon);

            GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex3(-1.0f, -1.0f, 0.0f);
            GL.Color3(1.0f, 0.0f, 0.0f); GL.Vertex3(1.0f, -1.0f, 0.0f);
            GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex3(0.0f, 1.0f, 1.0f);

            GL.End();

            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex3(0.0f, 1.0f, 1.0f);
            GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex3(-1.0f, -1.0f, 2.0f);
            GL.Color3(1.0f, 0.0f, 0.0f); GL.Vertex3(1.0f, -1.0f, 2.0f);

            GL.End();

            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(Color.Blue); GL.Vertex3(-1.0f, -1.0f, 0.0f);
            GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex3(-1.0f, -1.0f, 2.0f);
            GL.Color3(Color.Red); GL.Vertex3(1.0f, -1.0f, 2.0f);
            GL.Color3(Color.Red); GL.Vertex3(1.0f, -1.0f, 0.0f);

            GL.End();
        }
    }
}
