using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
          
            InitializeComponent();
        
        }

        public static int N = 4;//кількість стовпчиків в масиві (х, у, Z,4-ta)
        public static int M = 10;////кількість рядків в масиві 
        public static double[,] X = new double[ M,N]; /// dovilna
        public static double[,] X_Svazi = new double[M, M]; /// показує чи існує звязок між і-ю та j -ю точками (це потрібно для побудови)
                                                            /// 
        public static double[,] B = new double[M, N]; /// авторська матриця-зрізана пірамід паралелона OXY
        public static double[,] B_Svazi = new double[M, M]; /// показує чи існує звязок між і-ю та j -ю точками (це потрібно для побудови)
                                                            /// 
        public static double[,] H = new double[M, N]; /// авторська матриця-куб
        public static double[,] H_Svazi = new double[M, M]; /// показує чи існує звязок між і-ю та j -ю точками (це потрібно для побудови)
                                                            /// 
        public static double[,] H_Srez = new double[M, N]; /// авторська матриця-куб zrizani
        public static double[,] H_Srez_Svazi = new double[M, M]; /// показує чи існує звязок між і-ю та j -ю точками (це потрібно для побудови)
                                                            /// 
        public static double[,] L2 = new double[6, N]; /// авторська матриця- правильна трикутна призма паралелона осі OX
        public static double[,] L2_Svazi = new double[6, 6]; /// показує чи існує звязок між і-ю та j -ю точками (це потрібно для побудови)
                                                             /// 
        public static double[,] L1 = new double[6, N]; /// авторська матриця- правильна трикутна призма паралелона осі OX
        public static double[,] L1_Svazi = new double[6, 6]; /// показує чи існує звязок між і-ю та j -ю точками (це потрібно для побудови)

        public static double x_zsuv = 0;
        public static double y_zsuv = 0;
        public static double z_zsuv = 0;

        public static double x_roztag = 1;
        public static double y_roztag = 1;
        public static double z_roztag = 1;
        public static double fi = 0;


        public static int x_plus = 30;/// для зсуву в системі координат  0;//
        public static int y_plus = 230; ///0;//

        public static int Degree_Horiz = 145;
        public static int Degree_Vert = 45;
        public static void Pobudova_kuba_Zrizanogo()//куб zrizani
        {

            H_Srez[0, 0] = 0; H_Srez[0, 1] = 0; H_Srez[0, 2] = 0; H_Srez[0, 3] = 1; H_Srez_Svazi[0, 1] = 1;
            H_Srez[1, 0] = 0; H_Srez[1, 1] = 0; H_Srez[1, 2] = 100; H_Srez[1, 3] = 1; H_Srez_Svazi[1, 2] = 1;
            H_Srez[2, 0] = 100; H_Srez[2, 1] = 0; H_Srez[2, 2] = 100; H_Srez[2, 3] = 1; H_Srez_Svazi[2, 3] = 1;
            H_Srez[3, 0] = 100; H_Srez[3, 1] = 0; H_Srez[3, 2] = 0; H_Srez[3, 3] = 1; H_Srez_Svazi[3, 0] = 1;

            H_Srez[4, 0] = 0; H_Srez[4, 1] = 100; H_Srez[4, 2] = 0; H_Srez[4, 3] = 1; H_Srez_Svazi[4, 5] = 1;
            H_Srez[5, 0] = 0; H_Srez[5, 1] = 100; H_Srez[5, 2] = 100; H_Srez[5, 3] = 1; H_Srez_Svazi[5, 6] = 1;
            H_Srez[6, 0] = 100; H_Srez[6, 1] = 100; H_Srez[6, 2] = 100; H_Srez[6, 3] = 1; H_Srez_Svazi[6, 7] = 1;
            H_Srez[7, 0] = 100; H_Srez[7, 1] = 100; H_Srez[7, 2] = 50; H_Srez[7, 3] = 1; H_Srez_Svazi[7, 8] = 1;
            H_Srez[8, 0] = 50; H_Srez[8, 1] = 100; H_Srez[8, 2] = 0; H_Srez[8, 3] = 1; H_Srez_Svazi[8, 9] = 1;
            H_Srez[9, 0] = 100; H_Srez[9, 1] = 50; H_Srez[9, 2] = 0; H_Srez[9, 3] = 1; H_Srez_Svazi[9, 7] = 1; H_Srez_Svazi[4, 8] = 1;

            H_Srez_Svazi[0, 4] = 1;
            H_Srez_Svazi[1, 5] = 1;
            H_Srez_Svazi[2, 6] = 1;
            H_Srez_Svazi[3, 9] = 1;
        }
        public static void Pobudova_kuba()//куб
        {

            H[0,0]=10;H[0,1]=0;H[0,2]=10;H[0,3]=1; H_Svazi[0,1]=1;
            H[1,0]=10;H[1,1]=0;H[1,2]=100;H[1,3]=1; H_Svazi[1,2]=1;
            H[2,0]=100;H[2,1]=0;H[2,2]=100;H[2,3]=1; H_Svazi[2,3]=1;
            H[3,0]=100;H[3,1]=0;H[3,2]=10;H[3,3]=1; H_Svazi[3,0]=1;   
            H[4,0]=10;H[4,1]=90;H[4,2]=10;H[4,3]=1; H_Svazi[4,5]=1;
            H[5,0]=10;H[5,1]=90;H[5,2]=100;H[5,3]=1; H_Svazi[5,6]=1;
            H[6,0]=100;H[6,1]=90;H[6,2]=100;H[6,3]=1; H_Svazi[6,7]=1;
            H[7,0]=100;H[7,1]=90;H[7,2]=10;H[7,3]=1; H_Svazi[7,4]=1;
            H_Svazi[0, 4] = 1;
            H_Svazi[1, 5] = 1;
            H_Svazi[2, 6] = 1;
            H_Svazi[3, 7] = 1;
        }
        public static void Pobudova_piramidi()//Зрізана піраміда
        {
            for (int i = 0; i < M; i++)
            {
                B[i, 2] = 0;///z
                B[i, 3] = 1;  ///4-ta
            }
            B[0, 0] = 10; B[0, 1] = 10; B_Svazi[0, 1] = 1;
            B[1, 0] = 100; B[1, 1] = 10; B_Svazi[1, 2] = 1;
            B[2, 0] = 100; B[2, 1] = 100; B_Svazi[2, 3] = 1;
            B[3, 0] = 10; B[3, 1] = 100; B_Svazi[3, 0] = 1;

            B[4, 0] = 25; B[4, 1] = 25; B_Svazi[4, 5] = 1; B[4, 2] = 40;
            B[5, 0] = 85; B[5, 1] = 25; B_Svazi[5, 6] = 1; B[5, 2] = 40;
            B[6, 0] = 85; B[6, 1] = 85; B_Svazi[6, 7] = 1; B[6, 2] = 40;
            B[7, 0] = 25; B[7, 1] = 85; B_Svazi[7, 4] = 1; B[7, 2] = 40;

            B_Svazi[0, 4] = 1; B_Svazi[1, 5] = 1; B_Svazi[2, 6] = 1; B_Svazi[3, 7] = 1;
        }

        public static void Pobudova_prizmiL2()//Правильна трикутна призма
        {
            for (int i = 0; i < 6; i++)
            {
                
                L2[i, 3] = 1;  ///4-ta
            }
            L2[0, 0] = 0; L2[0, 1] = 0; L2[0, 2] = 0; L2_Svazi[0, 1] = 1;
            L2[1, 0] = 80; L2[1, 1] = 0; L2[1, 2] = 0; L2_Svazi[1, 2] = 1;
            L2[2, 0] = 80; L2[2, 1] = 0; L2[2, 2] = 120; L2_Svazi[2, 3] = 1;
            L2[3, 0] = 0; L2[3, 1] = 0; L2[3, 2] = 120; L2_Svazi[3, 0] = 1;

            L2[4, 0] = 0; L2[4, 1] = 60; L2[4, 2] = 60; L2_Svazi[4, 5] = 1;
            L2[5, 0] = 80; L2[5, 1] = 60; L2[5, 2] = 60;


            L2_Svazi[0, 4] = 1; L2_Svazi[1, 5] = 1; L2_Svazi[3, 4] = 1; L2_Svazi[5, 2] = 1; 
        }

        public static void Pobudova_prizmiL1()//Правильна трикутна призма
        {
            for (int i = 0; i < 6; i++)
            {

                L1[i, 3] = 1;  ///4-ta
            }
            L1[0, 0] = 30; L1[0, 1] = 0; L1[0, 2] = 0; L1_Svazi[0, 1] = 1;
            L1[1, 0] = 110; L1[1, 1] = 0; L1[1, 2] = 0; L1_Svazi[1, 2] = 1;
            L1[2, 0] = 80; L1[2, 1] = 0; L1[2, 2] = 120; L1_Svazi[2, 3] = 1;
            L1[3, 0] = 0; L1[3, 1] = 0; L1[3, 2] = 120; L1_Svazi[3, 0] = 1;

            L1[4, 0] = 20; L1[4, 1] = 60; L1[4, 2] = 35; L1_Svazi[4, 5] = 1;
            L1[5, 0] = 100; L1[5, 1] = 60; L1[5, 2] = 35;


            L1_Svazi[0, 4] = 1; L1_Svazi[1, 5] = 1; L1_Svazi[3, 4] = 1; L1_Svazi[5, 2] = 1;
        }

        public static void Vibor_massiva(RadioButton radioButton6, RadioButton radioButton7, RadioButton radioButton8, RadioButton radioButton9, RadioButton radioButton10)
        {
            if (radioButton6.Checked)
            {
                M = 8;
                X = Copy_Matrix(H, N, M);
                
                X_Svazi = Copy_Matrix(H_Svazi, M, M);
            }
            else if (radioButton7.Checked)
            {
                M = 8;
                X = Copy_Matrix(B, N, M);
               
                X_Svazi = Copy_Matrix(B_Svazi, M, M);
            }
            else if (radioButton8.Checked)
            {
                M = 6;
                X = Copy_Matrix(L1, N, 6);
               
                X_Svazi = Copy_Matrix(L1_Svazi, 6, 6);
            }
            else if (radioButton9.Checked)
            {
                M = 6;
                X = Copy_Matrix(L2, N, 6);             
                X_Svazi = Copy_Matrix(L2_Svazi, 6, 6);
            }
            else if (radioButton10.Checked)
            {
                M = 10;
                X = Copy_Matrix(H_Srez, N, 10);
                X_Svazi = Copy_Matrix(H_Srez_Svazi, 10, 10);
            }
        }
        public static Point space2pic(int x, int y, int z, int horzDegree, int vertDegree)//// робить з трьох координат дві (для зображення на площині 3д фігури)
        {
            return new Point((int)Math.Round(-x * cos(horzDegree)
                                                    + z * sin(horzDegree)
                                  )
                       , (int)Math.Round(
                                -y * cos(vertDegree)
                                  + x * (sin(horzDegree) * sin(vertDegree))
                                     + z * (cos(horzDegree) * sin(vertDegree))
                          )
                     );
        }
        static double sin(int degree)
        {
            return sin((double)degree);
        }
        static double sin(double degree)
        {
            return Math.Sin(degree * (Math.PI / 180));
        }
        static double cos(int degree)
        {
            return cos((double)degree);
        }
        static double cos(double degree)
        {
            return Math.Cos(degree * (Math.PI / 180));
        }  
        public static double[,] Povorot_OZ(double F) /// матриця повороту
        {
            double[,] mass = new double[4, 4];
            double fi = F * Math.PI / 180;
            mass[0, 0]=Math.Cos(fi);
            mass[0, 1]=-Math.Sin(fi);
            mass[0, 2] = 0;
            mass[0, 3] = 0;
            mass[1, 0] = Math.Sin(fi);
            mass[1, 1] = Math.Cos(fi);
            mass[1, 2] = 0;
            mass[1, 3] = 0;
            mass[2, 0] = 0;
            mass[2, 1] = 0;
            mass[2, 2] = 1;
            mass[2, 3] = 0;
            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }
        public static double[,] Povorot_OX(double F) /// матриця повороту
        {
            double[,] mass = new double[4, 4];
            double fi = F * Math.PI / 180;
            mass[0, 0] = 1;
            mass[0, 1] = 0;
            mass[0, 2] = 0;
            mass[0, 3] = 0;
            mass[1, 0] =0;
            mass[1, 1] = Math.Cos(fi);
            mass[1, 2] = -Math.Sin(fi);
            mass[1, 3] = 0;
            mass[2, 0] = 0;
            mass[2, 1] = Math.Sin(fi);
            mass[2, 2] = Math.Cos(fi);
            mass[2, 3] = 0;
            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }
        public static double[,] Povorot_OY(double F) /// матриця повороту
        {
            double[,] mass = new double[4, 4];
            double fi = F * Math.PI / 180;
            mass[0, 0] = Math.Cos(fi);
            mass[0, 1] = 0;
            mass[0, 2] = Math.Sin(fi);
            mass[0, 3] = 0;
            mass[1, 0] = 0;
            mass[1, 1] = 1;
            mass[1, 2] = 0;
            mass[1, 3] = 0;
            mass[2, 0] = -Math.Sin(fi);
            mass[2, 1] = 0;
            mass[2, 2] = Math.Cos(fi);
            mass[2, 3] = 0;
            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }
        public static double[,] Roztiag(double a, double b, double c) /// матриця розтягу 
        {
            double[,] mass = new double[4, 4];        
            mass[0, 0] = a;
            mass[0, 1] = 0;
            mass[0, 2] = 0;
            mass[0, 3] = 0;
            mass[1, 0] = 0;
            mass[1, 1] = b;
            mass[1, 2] = 0;
            mass[1, 3] = 0;
            mass[2, 0] = 0;
            mass[2, 1] = 0;
            mass[2, 2] = c;
            mass[2, 3] = 0;
            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }
        public static double[,] Zsuv(double l,double m, double n) /// матриця зсуву 
        {
            double[,] mass = new double[4, 4];

            mass[0, 0] = 1;
            mass[0, 1] = 0;
            mass[0, 2] = 0;
            mass[0, 3] = l;
            mass[1, 0] = 0;
            mass[1, 1] = 1;
            mass[1, 2] = 0;
            mass[1, 3] = m;
            mass[2, 0] = 0;
            mass[2, 1] = 0;
            mass[2, 2] = 1;
            mass[2, 3] = n;
            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }
        public static double[,] Ref(int x) /// матриця дзхеркального відображення //// x=1 -відносно xy,  x=-1  -відносно yz, x=0  -відносно xz
        {
            double[,] mass = new double[4, 4];
            if (x == 1)
            {
                mass[0, 0] = 1;
            }
            else if (x == -1)
            {
                mass[0, 0] = -1;
            }
            else
            {
                mass[0, 0] = 1;
            }
            mass[0, 1] = 0;
            mass[0, 2] = 0;
            mass[0, 3] = 0;
            mass[1, 0] = 0;
            if (x == 1)
            {
                mass[1, 1] = 1;
            }
            else if (x == -1)
            {
                mass[1, 1] = 1;
            }
            else
            {
                mass[1, 1] = -1;
            }
            mass[1, 2] = 0;
            mass[1, 3] = 0;

            mass[2, 0] = 0;
            mass[2, 1] = 0;
            if (x == 1)
            {
                mass[2, 2] = -1;
            }
            else if (x == -1)
            {
                mass[2, 2] = 1;
            }
            else
            {
                mass[2, 2] = 1;
            }
            mass[2, 3] = 0;

            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }

        public static double[,] Dimetria_A(double Psi, double F) /// матриця диметрії 
        {
            double[,] mass = new double[4, 4];
            double fi = F * Math.PI / 180;
            double psi = Psi * Math.PI / 180;
            mass[0, 0] = Math.Cos(psi);
            mass[0, 1] = 0;
            mass[0, 2] = -Math.Sin(psi);
            mass[0, 3] = 0;

            mass[1, 0] = -Math.Sin(psi) * Math.Sin(fi);
            mass[1, 1] = Math.Cos(fi);
            mass[1, 2] = -Math.Cos(psi) * Math.Sin(fi);
            mass[1, 3] = 0;

            mass[2, 0] = 0;
            mass[2, 1] = 0;
            mass[2, 2] = 0;
            mass[2, 3] = 0;
            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }

        public static double[,] Kosokut_Proek(double f, double F) /// матриця косокутної проекції
        {
            double[,] mass = new double[4, 4];
            double fi = F * Math.PI / 180;

            mass[0, 0] = 1;//Math.Cos(psi);
            mass[0, 1] = 0;
            mass[0, 2] = -f * Math.Cos(fi);
            mass[0, 3] = 0;

            mass[1, 0] = 0;
            mass[1, 1] = 1;
            mass[1, 2] = -f * Math.Sin(fi);
            mass[1, 3] = 0;

            mass[2, 0] = 0;
            mass[2, 1] = 0;
            mass[2, 2] = 0;
            mass[2, 3] = 0;

            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }
        public static double[,] Izometria_A() /// матриця ізометрії 
        {
            double[,] mass = new double[4, 4];
            mass[0, 0] = 0.707;
            mass[0, 1] = 0;
            mass[0, 2] = -0.707;
            mass[0, 3] = 0;

            mass[1, 0] = -0.408;
            mass[1, 1] = 0.816;
            mass[1, 2] = -0.408;
            mass[1, 3] = 0;

            mass[2, 0] = 0;
            mass[2, 1] = 0;
            mass[2, 2] = 0;
            mass[2, 3] = 0;

            mass[3, 0] = 0;
            mass[3, 1] = 0;
            mass[3, 2] = 0;
            mass[3, 3] = 1;
            return mass;
        }

        //public static double[,] Perspect_Proek(bool XY, bool XZ, bool YZ, double p, double q, double r) /// матриця Перспективної проекції
        //{
        //    double[,] mass = new double[4, 4];

        //    if (YZ == false)
        //    {
        //        mass[0, 0] = 1;
        //    }
        //    mass[0, 1] = 0;
        //    mass[0, 2] = 0;
        //    mass[0, 3] = p;

        //    mass[1, 0] = 0;
        //    if (XZ == false)
        //    {
        //        mass[1, 1] = 1;
        //    }
        //    mass[1, 2] = 0;
        //    mass[1, 3] = q;

        //    mass[2, 0] = 0;
        //    mass[2, 1] = 0;
        //    if (XY == false)
        //    {
        //        mass[2, 2] = 1;
        //    }
        //    mass[2, 3] = r;

        //    mass[3, 0] = 0;
        //    mass[3, 1] = 0;
        //    mass[3, 2] = 0;
        //    mass[3, 3] = 1;
        //    return mass;
        //}
        public static double[,] Perspect_Proek(double p, double q, double r) /// матриця Перспективної проекції
        {
            double[,] mass = new double[4, 4];

           // if (YZ == false)
            {
                mass[0, 0] = 1;
            }
            mass[0, 1] = 0;
            mass[0, 2] = 0;
            mass[0, 3] = 0;

            mass[1, 0] = 0;
          //  if (XZ == false)
            {
                mass[1, 1] = 1;
            }
            mass[1, 2] = 0;
            mass[1, 3] = 0;

            mass[2, 0] = 0;
            mass[2, 1] = 0;
           // if (XY == false)
            {
                mass[2, 2] = 1;
            }
            mass[2, 3] = 0;

                mass[3, 0] =(-1/ p);
                mass[3, 1] =(-1/ q);
                mass[3, 2] =(-1/ r);
            
            mass[3, 3] = 1;
            return mass;
        }
        public static bool Proverca_Location(double[,] matrix, PictureBox pictureBox1) ///Перевірка чи не виходить обєкт за межі 
        {
            for (int i = 0; i < M ; i++)
            {
                Point p1 = space2pic((int)matrix[i, 0], (int)matrix[i, 1], (int)matrix[i, 2], Degree_Horiz, Degree_Vert);
                if (p1.X + x_plus > pictureBox1.Width || p1.X + x_plus < 0)
                {
                    return false;
                }
                if (p1.Y + y_plus > pictureBox1.Height || p1.Y + y_plus < 0)
                {
                    return false;
                }
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e) ////Повернення до початкови даних 
        {
            label1.Text = "";
            Pobudova_kuba();
            Pobudova_kuba_Zrizanogo();
            Pobudova_piramidi();
            Pobudova_prizmiL1();
            Pobudova_prizmiL2();
            Vibor_massiva(radioButton6, radioButton7, radioButton8, radioButton9,radioButton10);
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Lin(flagGraphics, X,X_Svazi,M);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);
            pictureBox1.Image = flag;
        }
        public static void Draw_Lin(Graphics g, double[,] Xx, double[,] Xx_Svazi,int M) ///Зображення обєкта
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (Xx_Svazi[i, j] == 1)
                    {
                        Point p1 = space2pic((int)Xx[i, 0], (int)Xx[i, 1], (int)Xx[i, 2], Degree_Horiz, Degree_Vert);
                        Point p2 = space2pic((int)Xx[j, 0], (int)Xx[j, 1], (int)Xx[j, 2], Degree_Horiz, Degree_Vert);
                       // g.DrawLine(new Pen(Color.Red, 2), (int)Xx[i, 0], (int)Xx[i, 1], (int)Xx[j, 0], (int)Xx[j, 1]);
                        g.DrawLine(new Pen(Color.Red, 2), p1.X + x_plus, p1.Y + y_plus, p2.X + x_plus, p2.Y + y_plus);

                    }
                }
            }
            int q = 5;
            Point p11 = space2pic((int)Xx[q, 0], (int)Xx[q, 1], (int)Xx[q, 2], Degree_Horiz, Degree_Vert);
            g.DrawLine(new Pen(Color.Aquamarine, 7), p11.X + x_plus, p11.Y + y_plus, p11.X +2+ x_plus, p11.Y+2 + y_plus);
        }

        public static void Draw_Coordinat_Set(Graphics g, PictureBox pictureBox1) // побудова системи координат 
        {
           Pen myPen2 = new Pen(Color.FromArgb(255, 0, 0, 255), 1);
                myPen2.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;// strelochka
                myPen2.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
             
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 8, FontStyle.Italic, GraphicsUnit.Point);
                PointF pointF = new PointF(0, 10);
                StringFormat stringFormat = new StringFormat();
                SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
                double fi_X = 30;
                int size = 0;
                if (pictureBox1.Width < pictureBox1.Height)
                {
                    size = pictureBox1.Width;
                }
                else
                {
                    size = pictureBox1.Height;
                }

                Point px = space2pic(size - 80, 0, 0, Degree_Horiz, Degree_Vert);
                //g.DrawLine(myPen2, (int)(1) + x_plus, (int)(1) + y_plus, (int)(size - 5), (int)(1) + y_plus);// OSI  OX
                g.DrawLine(myPen2, (int)(0) + x_plus, (int)(0) + y_plus, px.X + x_plus, px.Y + y_plus);// OSI  OX

                Point py = space2pic(0,size - 5, 0, Degree_Horiz, Degree_Vert);
                //g.DrawLine(myPen2, (int)(1) + x_plus, (int)(1) + y_plus, (int)(1) + x_plus, (int)(size - 5));//OY
                g.DrawLine(myPen2, (int)(0) + x_plus, (int)(0) + y_plus,  py.X + x_plus, py.Y+280);//OY

               // g.DrawLine(myPen2, (int)(1) + x_plus, (int)(1) + y_plus, (int)(1), (int)(1));///OZ
                //g.DrawLine(myPen2, (int)(1) + x_plus, (int)(1) + y_plus, (int)((pictureBox1.Width - 5) * Math.Cos(fi_X * Math.PI / 180)), (int)(1));///OZ
                Point p1 = space2pic(0, 0, (int)(size - 5), Degree_Horiz, Degree_Vert);
                g.DrawLine(myPen2, (int)(0) + x_plus, (int)(0) + y_plus, p1.X + x_plus, p1.Y + y_plus);///OZ

                g.DrawString("y", font, solidBrush, new PointF(py.X + x_plus, py.Y+280 -10), stringFormat);
                g.DrawString("x", font, solidBrush, new PointF(px.X + x_plus-10, px.Y + y_plus ));
                g.DrawString("z", font, solidBrush, new PointF(p1.X + x_plus, p1.Y + y_plus));
    }
        private void Form1_Load(object sender, EventArgs e) /// При запускі програми відразу ж малюємо обєкт 
        {
         
            Pen myPen = new Pen(Color.Blue, 1);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Pobudova_kuba();
            Pobudova_kuba_Zrizanogo();
            Pobudova_piramidi();
            Pobudova_prizmiL2();
            Pobudova_prizmiL1();
            Vibor_massiva(radioButton6, radioButton7, radioButton8, radioButton9, radioButton10);
            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {

               // Draw_Lin(g, B, B_Svazi,8);
               // Draw_Lin(g, H, H_Svazi,8);
               // M = 10;
                Draw_Lin(g, H_Srez, H_Srez_Svazi, 10);
                //Draw_Lin(g, L2, L2_Svazi, 6);
               // Draw_Lin(g, L1, L1_Svazi, 6);
                Draw_Coordinat_Set(g, pictureBox1);
            }  
            pictureBox1.Refresh();
            x_zsuv = Convert.ToDouble(textBox1.Text);
            y_zsuv = Convert.ToDouble(textBox2.Text);

        }

        public static double[] Mnosh_Matris_na_vector(double[,] matrix, double[] mass)  /// Множення матриці на вектор 
        {
            int lenght = (int)Math.Sqrt(matrix.Length);
            double[] mass_rez = new double[lenght];
            //s = s + "\n";
            int count = 0;
            for (int i = 0; i < lenght; i++) ///
            {
                if (count == 4)
                {
                    count = 0;
                }
                if (count == 0)
                {
                    mass_rez[i] = (matrix[0, 0] * mass[i] + matrix[0, 1] * mass[i + 1] + matrix[0, 2] * mass[i + 2] + matrix[0, 3] * mass[i+3]);
                }
                if (count == 1)
                {
                    mass_rez[i] = (matrix[1, 0] * mass[i - 1] + matrix[1, 1] * mass[i] + matrix[1, 2] * mass[i + 1]+ matrix[1, 3] * mass[i+2]) ;
                }
                if (count == 2)
                {
                    mass_rez[i] = (matrix[2, 0] * mass[i - 2] + matrix[2, 1] * mass[i - 1] + matrix[2, 2] * mass[i] + matrix[2, 3] * mass[i + 1]);
                }
                if (count == 3)
                {
                    mass_rez[i] = (matrix[3, 0] * mass[i - 3] + matrix[3, 1] * mass[i - 2] + matrix[3, 2] * mass[i - 1] + matrix[3, 3] * mass[i]);
                }
                count++;


            }
            return mass_rez;
        }

        public double[,] Mnosh_Matr(double[,] A, double[,] E) /// Мнаження двох матриць
        {
            int n = (int)Math.Sqrt(A.Length);
            double[,] Proverka = new double[n, n];
            for (int i = 0; i < n; i++)// Запись данных в таблицу
            {
                for (int j = 0; j < n; j++)
                {
                    for (int g = 0; g < n; g++)
                    {
                        Proverka[i, j] = Proverka[i, j] + A[i, g] * E[g, j];
                    }
                    // pr = pr + " " + Math.Round(Proverka[i, j],0);
                }
            }
            return Proverka;
        }
        public static double[,] Copy_Matrix (double[,] A, int n, int m) //// Копіювання матриці
        {
            double[,] Proverka = new double[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Proverka[i, j] = A[i, j];
                }
            }
            return Proverka;
        }

        public static bool Peretexod_v_decart()  /// Перехід до декартових координат 
        {
            //double[,] mass_rez = new double[M,N];
            for (int i = 0; i < M; i++)
            {
                if (X[i, 3] != 0)
                {
                    X[i, 0] = X[i, 0] / X[i, 3];
                    X[i, 1] = X[i, 1] / X[i, 3];
                    X[i, 2] = X[i, 2] / X[i, 3];
                    return true;
                }
                else
                {
                    return false;
                    MessageBox.Show("Ділення на 0 при переході до декартової системи. " + (i + 1) + " координатa дорівнює 0", "Помилка");
                }
            }
            return true;
        }

        public static void Peretexod_v_decart_pri_perspectvi(double p, double q, double r)  /// Перехід до декартових координат pri perspectivi
        {
            //double[,] mass_rez = new double[M,N];
            double x = 0;
            double y = 0;
            double z = 0;
            for (int i = 0; i < M; i++)
            {
                if ((X[i, 0] * p) + (X[i, 1] * q) + (X[i, 2] * r) + 1 != 0)
                {
                    x = X[i, 0] / ((X[i, 0] * p) + (X[i, 1] * q) + (X[i, 2] * r) + 1);
                    y = X[i, 1] /  ((X[i, 0] *p)+( X[i, 1]*q)+(X[i, 2]*r)+1);
                    z = X[i, 2] /  ((X[i, 0] *p)+( X[i, 1]*q)+(X[i, 2]*r)+1);
                    X[i, 0] = x;
                    X[i, 1] = y;
                    X[i, 2] = z;
                    //return true;
                }
                else
                {
                    
                    MessageBox.Show("Ділення на 0 при переході до декартової системи. " + (i + 1) + " координатa дорівнює 0", "Помилка");
                    //return false;
                }
            }
           // return true;
        }

        public static double Ugol_meshdu_Pramimi(double l, double m, double n, double A, double B, double C)
        {
            double fi = 0;
            double z = 0;

            double s_modu = Math.Sqrt(l * l + m * m + n * n);
            double d_modu = Math.Sqrt(A * A + B * B + C * C);
            double s_d = A * l + B * m + C * n;
            double cos = s_d / (s_modu * d_modu);
            fi = Math.Acos(cos)*180/Math.PI;
            return fi;
        }
     

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)  ///ЗСУВ
        {
            
            //Vibor_massiva(radioButton6, radioButton7, radioButton8, radioButton9);
            if (textBox1.Text != "")
            {
                x_zsuv = Convert.ToDouble(textBox1.Text);
            }
            if (textBox2.Text != "")
            {
                y_zsuv = Convert.ToDouble(textBox2.Text);
            }
            if (textBox10.Text != "")
            {
                z_zsuv = Convert.ToDouble(textBox10.Text);
            }
            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }
                new_vector = Mnosh_Matris_na_vector(Zsuv(x_zsuv, y_zsuv,z_zsuv), X_vector);
                for (int j = 0; j < N; j++)
                {
                    New_mas[i, j] = new_vector[j];
                    s = s + " " + New_mas[i, j];
                }
                s = s + "\n";
            }

            X = Copy_Matrix(New_mas, N, M);
            Peretexod_v_decart();
            label1.Text = s;
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);
            if (Proverca_Location(New_mas, pictureBox1))
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi,M);
            }
            else
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");

            }
            pictureBox1.Image = flag;
        }

        private void button3_Click(object sender, EventArgs e) ///РОЗТЯГ
        {
           // Vibor_massiva(radioButton6, radioButton7, radioButton8, radioButton9);
            if (textBox3.Text != "")
            {
                x_roztag = Convert.ToDouble(textBox3.Text);
            }
            if (textBox4.Text != "")
            {
                y_roztag = Convert.ToDouble(textBox4.Text);
            }
            if (textBox11.Text != "")
            {
                z_roztag = Convert.ToDouble(textBox11.Text);
            }
            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";
            double tmpx = X[0, 0];
            double tmpy = X[0, 1];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }
                //new_vector = Mnosh_Matris_na_vector(Zsuv(-tmpx, -tmpy), X_vector);
                //X_vector = Mnosh_Matris_na_vector(Roztiag(x_roztag, y_roztag), new_vector);
                //new_vector =  Mnosh_Matris_na_vector(Zsuv(tmpx, tmpy), X_vector);
                new_vector = Mnosh_Matris_na_vector(Roztiag(x_roztag, y_roztag,z_roztag), X_vector);
                for (int j = 0; j < N; j++)
                {
                    New_mas[i, j] = new_vector[j];
                    s = s + " " + New_mas[i, j];
                }
                s = s + "\n";
            }

            X = Copy_Matrix(New_mas, N, M);
            Peretexod_v_decart();
            label1.Text = s;
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);
            if (Proverca_Location(New_mas, pictureBox1))
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi,M);
            }
            else
            {
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            pictureBox1.Image = flag;

        }


        private void button4_Click(object sender, EventArgs e) ///ПОВОРОТ
        {
            string text = textBox6.Text;
            char[] sep = { ' ', '/', '!', '@', '$', ':', ';', '*', '(', ')', '\t', '\n' };
            //  List<string> arr = new List<text.Split(sep, StringSplitOptions.RemoveEmptyEntries)>();
            string[] arr = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);

            double x=0;
            double y=0;
            double z = 0;
            bool OX = false;
            bool OY = false;
            bool OZ = false;
            if (checkBox1.Checked)
            {
                OX = true;
                if (arr.Length > 0)
                {
                    if (arr[0] != "")
                    { y = Convert.ToDouble(arr[0]); }
                }
                if (arr.Length > 1)
                {
                    if (arr[1] != "")
                    { z = Convert.ToDouble(arr[1]); }
                }
                Point p1 = space2pic((int)x, (int)y, (int)z, Degree_Horiz, Degree_Vert);
                Point p2 = space2pic((int)x+300, (int)y, (int)z, Degree_Horiz, Degree_Vert);
                flagGraphics.DrawLine(new Pen(Color.Blue, 2), p1.X + x_plus, p1.Y + y_plus, p2.X + x_plus, p2.Y + y_plus);
               
            }
            else if(checkBox2.Checked)
            {
                OY= true;
                if (arr.Length > 0)
                {
                    if (arr[0] != "")
                    { x = Convert.ToDouble(arr[0]); }
                }
                if (arr.Length > 1)
                {
                    if (arr[1] != "")
                    { z = Convert.ToDouble(arr[1]); }
                }
                Point p1 = space2pic((int)x, (int)y, (int)z, Degree_Horiz, Degree_Vert);
                Point p2 = space2pic((int)x, (int)y + 300, (int)z, Degree_Horiz, Degree_Vert);
                flagGraphics.DrawLine(new Pen(Color.Blue, 2), p1.X + x_plus, p1.Y + y_plus, p2.X + x_plus, p2.Y + y_plus);
            }
            else if (checkBox3.Checked)
            {
                OZ = true;
                if (arr.Length > 0)
                {
                    if (arr[0] != "")
                    { x = Convert.ToDouble(arr[0]); }
                }
                if (arr.Length > 1)
                {
                    if (arr[1] != "")
                    { y = Convert.ToDouble(arr[1]); }
                }
                Point p1 = space2pic((int)x, (int)y, (int)z, Degree_Horiz, Degree_Vert);
                Point p2 = space2pic((int)x, (int)y, (int)z + 300, Degree_Horiz, Degree_Vert);
                flagGraphics.DrawLine(new Pen(Color.Blue, 2), p1.X + x_plus, p1.Y + y_plus, p2.X + x_plus, p2.Y + y_plus);
            }
          
            if (textBox5.Text != "")
            {
                fi = Convert.ToDouble(textBox5.Text);
            }
           
            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }
               new_vector = Mnosh_Matris_na_vector(Zsuv(-x,-y, -z), X_vector);
               if (OX) {
                   X_vector = Mnosh_Matris_na_vector(Povorot_OX(fi), new_vector);
               }
               else if (OY)
               {
                   X_vector = Mnosh_Matris_na_vector(Povorot_OY(fi), new_vector);
               }
               else if (OZ)
               {
                   X_vector = Mnosh_Matris_na_vector(Povorot_OZ(fi), new_vector);
               }
                
                new_vector = Mnosh_Matris_na_vector(Zsuv(x,y, z), X_vector);

                for (int j = 0; j < N; j++)
                {
                    New_mas[i, j] = new_vector[j];
                    s = s + " " + New_mas[i, j];
                }
                s = s + "\n";
            }

            X = Copy_Matrix(New_mas, N, M);
            Peretexod_v_decart();
            label1.Text = s;
            
            flagGraphics.DrawEllipse(new Pen(Color.Green, 3), (int)x, (int)y, 1, 1);
            if (Proverca_Location(New_mas, pictureBox1))
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi,M);
            }
            else
            {
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            pictureBox1.Image = flag;
        }

        private void button5_Click(object sender, EventArgs e)  ///ДЗЕРКАЛЬНЕ ВІДОБРАЖЕННЯ
        {

            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }
               // new_vector = Mnosh_Matris_na_vector(Zsuv(0, -C), X_vector);
                // X_vector = Mnosh_Matris_na_vector(Povorot(-(Math.Atan(A) * 180 / Math.PI)), new_vector);
                if (checkBox4.Checked)
                {
                    new_vector = Mnosh_Matris_na_vector(Ref(1), X_vector);
                }
                else if (checkBox5.Checked)
                {
                    new_vector = Mnosh_Matris_na_vector(Ref(-1), X_vector);
                }
                else if (checkBox6.Checked)
                {
                    new_vector = Mnosh_Matris_na_vector(Ref(0), X_vector);
                }
                
                //  X_vector = Mnosh_Matris_na_vector(Povorot((Math.Atan(A) * 180 / Math.PI)), new_vector);
               // new_vector = Mnosh_Matris_na_vector(Zsuv(0, C), X_vector);

                for (int j = 0; j < N; j++)
                {
                    New_mas[i, j] = new_vector[j];
                    s = s + " " + New_mas[i, j];
                }
                s = s + "\n";
            }

            X = Copy_Matrix(New_mas, N, M);
            Peretexod_v_decart();
            label1.Text = s;
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);
            if (Proverca_Location(New_mas, pictureBox1))
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi,M);
            }
            else
            {
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            
            pictureBox1.Image = flag;

            
        }

       

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label11.Text = "Координати точки : " +
                        " " + e.Location.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //private void button6_Click(object sender, EventArgs e)////ДИМЕТРИЯ
        //{
        //    double Fi=0;
        //    double Psi=0;

        //    if (textBox7.Text != "")
        //    {
        //        Fi = Convert.ToDouble(textBox7.Text);
        //    }
        //    if (textBox8.Text != "")
        //    {
        //        Psi = Convert.ToDouble(textBox8.Text);
        //    }

        //    double[,] New_mas = new double[M, N];
        //    double[] new_vector = new double[N];
        //    double[] X_vector = new double[N];

        //    string s = "";

        //    for (int i = 0; i < M; i++)
        //    {
        //        for (int j = 0; j < N; j++)
        //        {
        //            X_vector[j] = X[i, j];
        //        }

        //        new_vector = Mnosh_Matris_na_vector(Dimetria_A(Fi,Psi), X_vector);
        //        for (int j = 0; j < N; j++)
        //        {
        //            New_mas[i, j] = new_vector[j];
        //            s = s + " " + New_mas[i, j];
        //        }
        //        s = s + "\n";
        //    }

        //    X = Copy_Matrix(New_mas, N, M);
        //    Peretexod_v_decart();
        //    label1.Text = s;
        //    Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //    Graphics flagGraphics = Graphics.FromImage(flag);
        //    Draw_Coordinat_Set(flagGraphics, pictureBox1);
        //    if (Proverca_Location(New_mas, pictureBox1))
        //    {
        //        Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
        //    }
        //    else
        //    {
        //        MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
        //        Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
        //    }
        //    pictureBox1.Image = flag;
        //}

        private void button7_Click(object sender, EventArgs e)///ІЗОМЕТРІЯ
        {
            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }

                new_vector = Mnosh_Matris_na_vector(Izometria_A(), X_vector);
                for (int j = 0; j < N; j++)
                {
                    New_mas[i, j] = new_vector[j];
                    s = s + " " + New_mas[i, j];
                }
                s = s + "\n";
            }

            X = Copy_Matrix(New_mas, N, M);
            Peretexod_v_decart();
            label1.Text = s;
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);
            if (Proverca_Location(New_mas, pictureBox1))
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            else
            {
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            pictureBox1.Image = flag;
        }

        private void button8_Click(object sender, EventArgs e)//// КОСОКУТНА ПРОЕКЦІЯ
        {
            double f=0;
            if (radioButton1.Checked)
            {
                f = 1;
            }
            else if (radioButton2.Checked)
            {
                f = 0.5;
            }
            double Fi = 0;
            if (textBox9.Text != "")
            {
                Fi = Convert.ToDouble(textBox9.Text);
            }
            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }

                new_vector = Mnosh_Matris_na_vector(Kosokut_Proek(f,Fi), X_vector);
                for (int j = 0; j < N; j++)
                {
                    New_mas[i, j] = new_vector[j];
                    s = s + " " + New_mas[i, j];
                }
                s = s + "\n";
            }

            X = Copy_Matrix(New_mas, N, M);
            Peretexod_v_decart();
            label1.Text = s;
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);
            if (Proverca_Location(New_mas, pictureBox1))
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            else
            {
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            pictureBox1.Image = flag;
        }

       

        private void button10_Click(object sender, EventArgs e) ////Зображення фигур
        {
            Vibor_massiva(radioButton6, radioButton7, radioButton8, radioButton9, radioButton10);
            Pobudova_kuba();
            Pobudova_kuba_Zrizanogo();
            Pobudova_piramidi();
            Pobudova_prizmiL2();
            Pobudova_prizmiL1();
            Pen myPen = new Pen(Color.Blue, 1);
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {

                Draw_Lin(g, X, X_Svazi, M);
               
                Draw_Coordinat_Set(g, pictureBox1);
            }
            pictureBox1.Refresh();
        }

        private void button11_Click(object sender, EventArgs e) ///Поворот навколо прямоъ, заданоъ точкою та векотором
        {
            string text = textBox13.Text;
            char[] sep = { ' ', '/', '!', '@', '$', ':', ';', '*', '(', ')', '\t', '\n' };
            //  List<string> arr = new List<text.Split(sep, StringSplitOptions.RemoveEmptyEntries)>();
            string[] arr = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);

            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);

            double x = 0;
            double y = 0;
            double z = 0;

            if (arr.Length > 0)
            {
                if (arr[0] != "")
                { x = Convert.ToDouble(arr[0]); }
            }
            if (arr.Length > 1)
            {
                if (arr[1] != "")
                { y = Convert.ToDouble(arr[1]); }
            }
            if (arr.Length > 2)
            {
                if (arr[2] != "")
                { z = Convert.ToDouble(arr[2]); }
            }

             text = textBox14.Text;
             arr = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);

             double l = 0, m = 0, n = 0;
             if (arr.Length > 0)
             {
                 if (arr[0] != "")
                 { l = Convert.ToDouble(arr[0]); }
             }
             if (arr.Length > 1)
             {
                 if (arr[1] != "")
                 { m = Convert.ToDouble(arr[1]); }
             }
             if (arr.Length > 2)
             {
                 if (arr[2] != "")
                 { n = Convert.ToDouble(arr[2]); }
             }

            double x2 = 0;
            double y2 = 0;
            double z2 = 0;
            double k = 0;
            if (l != 0)
            {
                x2 = 200;
                k = (x2 - x) / l;
                y2 = (k * m) + y;
                z2 = (k * n) + z;
            }
            else if(m!=0)
            {
                y2 = 200;
                k = (y2 - y) / m;
                x2 = (k * l) + x;
                z2 = (k * n) + z;
            }
            else if (n != 0)
            {
                z2 = 200;
                k = (z2 - z) / n;
                x2 = (k * l) + x;
                y2 = (k * m) + y;
            }
             
                Point p1 = space2pic((int)x, (int)y, (int)z, Degree_Horiz, Degree_Vert);
                Point p2 = space2pic((int)x2, (int)y2, (int)z2, Degree_Horiz, Degree_Vert);
                flagGraphics.DrawLine(new Pen(Color.Blue, 2), p1.X + x_plus, p1.Y + y_plus, p2.X + x_plus, p2.Y + y_plus); ///Будуємо пряму навколо якої обертаємо 
     

            if (textBox15.Text != "")
            {
                fi = Convert.ToDouble(textBox15.Text);
            }

            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }
                new_vector = Mnosh_Matris_na_vector(Zsuv(-x, -y, -z), X_vector);
                //if (OX)

                if (l == 0 && m == 0 && n == 0)
                {

                }
                else if (l == 0 && m == 0)
                {
                    X_vector = Mnosh_Matris_na_vector(Povorot_OZ(fi), new_vector);
                }
                else if (l == 0 && n == 0)
                {
                    X_vector = Mnosh_Matris_na_vector(Povorot_OY(fi), new_vector);
                }
                else if (m == 0 && n == 0)
                {
                    X_vector = Mnosh_Matris_na_vector(Povorot_OX(fi), new_vector);
                }

                else if (l == 0)
                {
                    X_vector = Mnosh_Matris_na_vector(Povorot_OX(Ugol_meshdu_Pramimi(l,m,n,l,0,n)), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OZ(fi), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OX(-Ugol_meshdu_Pramimi(l, m, n, l, 0, n)), new_vector);
                }
                else if (m == 0)
                {

                    X_vector = Mnosh_Matris_na_vector(Povorot_OY(Ugol_meshdu_Pramimi(l, m, n, 0, m, n)), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OX(fi), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OY(-Ugol_meshdu_Pramimi(l, m, n, 0, m, n)), new_vector);
                }
                else if (n == 0)
                {
                    X_vector = Mnosh_Matris_na_vector(Povorot_OZ(Ugol_meshdu_Pramimi(l, m, n, l, 0, n)), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OY(fi), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OZ(-Ugol_meshdu_Pramimi(l, m, n, l, 0, n)), new_vector);
                }

                else
                {
                    X_vector = Mnosh_Matris_na_vector(Povorot_OZ(Ugol_meshdu_Pramimi(l, m, n, 0, m, n)), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OX(Ugol_meshdu_Pramimi(0, 0, n, 0, m, n)), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OZ(fi), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OX(-Ugol_meshdu_Pramimi(0, 0, n, 0, m, n)), new_vector);
                    new_vector = X_vector;
                    X_vector = Mnosh_Matris_na_vector(Povorot_OZ(-Ugol_meshdu_Pramimi(l, m, n, 0, m, n)), new_vector);
                }
              
                
                new_vector = Mnosh_Matris_na_vector(Zsuv(x, y, z), X_vector);

                for (int j = 0; j < N; j++)
                {
                    New_mas[i, j] = new_vector[j];
                    s = s + " " + New_mas[i, j];
                }
                s = s + "\n";
            }

            X = Copy_Matrix(New_mas, N, M);
            Peretexod_v_decart();
            label1.Text = s;
           // label1.Text = Ugol_meshdu_Pramoi_and_Ploskistu(l,m,n,0,1,0).ToString();

            flagGraphics.DrawEllipse(new Pen(Color.Green, 3), (int)x, (int)y, 1, 1);
            if (Proverca_Location(New_mas, pictureBox1))
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            else
            {
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            pictureBox1.Image = flag;
        }

        private void button12_Click(object sender, EventArgs e)/// Триметрія 
        {
            double Fi = 0;
            double Psi = 0;

            if (textBox16.Text != "")
            {
                Fi = Convert.ToDouble(textBox16.Text);
            }
            if (textBox17.Text != "")
            {
                Psi = Convert.ToDouble(textBox17.Text);
            }

            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }

                new_vector = Mnosh_Matris_na_vector(Povorot_OY(Psi), X_vector);
                X_vector = Mnosh_Matris_na_vector(Povorot_OX(Fi), new_vector);
                new_vector = Mnosh_Matris_na_vector(Povorot_OY(Psi), X_vector);
                new_vector[2] = 0;
                for (int j = 0; j < N; j++)
                {
                    New_mas[i, j] = new_vector[j];
                    s = s + " " + New_mas[i, j];
                }
                s = s + "\n";
            }

            X = Copy_Matrix(New_mas, N, M);
            Peretexod_v_decart();
            label1.Text = s;
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);
            if (Proverca_Location(New_mas, pictureBox1))
            {
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            else
            {
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
                Draw_Lin(flagGraphics, New_mas, X_Svazi, M);
            }
            pictureBox1.Image = flag;
        }

        private void button13_Click(object sender, EventArgs e) /// Триточкова перспективна проекція
        {
            double p = 0;
            double q = 0;
            double r = 0;

            if (textBox18.Text != "")
            {
                p = Convert.ToDouble(textBox18.Text);
            }
            if (textBox19.Text != "")
            {
                q = Convert.ToDouble(textBox19.Text);
            }
            if (textBox20.Text != "")
            {
                r = Convert.ToDouble(textBox20.Text);
            }


            double[,] New_mas = new double[M, N];
            double[] new_vector = new double[N];
            double[] X_vector = new double[N];

            string s = "";

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    X_vector[j] = X[i, j];
                }

                new_vector = Mnosh_Matris_na_vector(Perspect_Proek(p,q,r), X_vector);
                for (int j = 0; j < N; j++)
                {
                    X[i, j] = new_vector[j];
                    s = s + " " + X[i, j];
                }
                s = s + "\n";
            }

          //  X = Copy_Matrix(New_mas, N, M);    
            Peretexod_v_decart_pri_perspectvi(p,q,r);
            label1.Text = s;
            Bitmap flag = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics flagGraphics = Graphics.FromImage(flag);
            Draw_Coordinat_Set(flagGraphics, pictureBox1);
            if (Proverca_Location(X, pictureBox1))
            {
                Draw_Lin(flagGraphics, X, X_Svazi, M);
            }
            else
            {
                MessageBox.Show("При введених вхідних даних обєкт буде знаходитися за межами PictureBox.", "Попередження");
                Draw_Lin(flagGraphics, X, X_Svazi, M);
            }
            pictureBox1.Image = flag;
        }
    }
}
