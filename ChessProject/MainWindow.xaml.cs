using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace ChessProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static int[,] board = {
                                { -50, -30, -33, -90, -1000, -33, -30, -50 },
                                { -10, -10, -10, -10,   -10, -10, -10, -10 },
                                {   0,   0,   0,   0,     0,   0,   0,   0 },
                                {   0,   0,   0,   0,     0,   0,   0,   0 },
                                {   0,   0,   0,   0,     0,   0,   0,   0 },
                                {   0,   0,   0,   0,     0,   0,   0,   0 },
                                {  10,  10,  10,  10,    10,  10,  10,  10 },
                                {  50,  30,  33,  90,  1000,  33,  30,  50 }
        };
        /////////////////////////
        /*static void Main(string[] args)
        {
            int n = 1;
            using (var db = new BoardContext())
            {
                //db.Database.Delete();
                Board matrix = new Board
                {
                    ID = n,
                    Matrix = board,

                };
                db.Boards.Add(matrix);
                db.SaveChanges();
                var query = from b in db.Boards
                            orderby b.ID
                            select b;
                Console.WriteLine("Board:");
                foreach (var element in query)
                {
                    Console.WriteLine($"{element.ID} is {element.Matrix}");
                }
            }
        }*/

        //////////////////////
        bool Wpawn1 = false, Wpawn2 = false, Wpawn3 = false, Wpawn4 = false, Wpawn5 = false, Wpawn6 = false, Wpawn7 = false, Wpawn8 = false, Wrook1 = false, Wrook2 = false, Wknight1 = false, Wknight2 = false, Wbishop1 = false, Wbishop2 = false, Wking = false, Wqueen = false;
        bool Bpawn1 = false, Bpawn2 = false, Bpawn3 = false, Bpawn4 = false, Bpawn5 = false, Bpawn6 = false, Bpawn7 = false, Bpawn8 = false, Brook1 = false, Brook2 = false, Bknight1 = false, Bknight2 = false, Bbishop1 = false, Bbishop2 = false, Bking = false, Bqueen = false;
        double Xplace, Yplace;

        void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (Wpawn1)
                wp1.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wpawn2)
                wp2.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wpawn3)
                wp3.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wpawn4)
                wp4.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wpawn5)
                wp5.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wpawn6)
                wp6.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wpawn7)
                wp7.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wpawn8)
                wp8.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wrook1)
                wr1.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wrook2)
                wr2.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wknight1)
                wn1.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wknight2)
                wn2.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wbishop1)
                wb1.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wbishop2)
                wb2.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wking)
                wk.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Wqueen)
                wq.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bpawn1)
                bp1.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bpawn2)
                bp2.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bpawn3)
                bp3.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bpawn4)
                bp4.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bpawn5)
                bp5.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bpawn6)
                bp6.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bpawn7)
                bp7.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bpawn8)
                bp8.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Brook1)
                br1.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Brook2)
                br2.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bknight1)
                bn1.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bknight2)
                bn2.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bbishop1)
                bb1.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bbishop2)
                bb2.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bking)
                bk.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
            if (Bqueen)
                bq.Margin = new Thickness(e.GetPosition(this).X - Xplace, e.GetPosition(this).Y - Yplace, 0, 0);
        }
        int wp1_xindex = 0, wp1_yindex = 6, wp2_xindex = 1, wp2_yindex = 6, wp3_xindex = 2, wp3_yindex = 6, wp4_xindex = 3, wp4_yindex = 6, wp5_xindex = 4, wp5_yindex = 6, wp6_xindex = 5, wp6_yindex = 6, wp7_xindex = 6, wp7_yindex = 6, wp8_xindex = 7, wp8_yindex = 6, wr1_xindex = 0, wr1_yindex = 7, wn1_xindex = 1, wn1_yindex = 7, wb1_xindex = 2, wb1_yindex = 7, wq_xindex = 3, wq_yindex = 7, wk_xindex = 4, wk_yindex = 7, wb2_xindex = 5, wb2_yindex = 7, wn2_xindex = 6, wn2_yindex = 7, wr2_xindex = 7, wr2_yindex = 7;
        int bp1_xindex = 0, bp1_yindex = 1, bp2_xindex = 1, bp2_yindex = 1, bp3_xindex = 2, bp3_yindex = 1, bp4_xindex = 3, bp4_yindex = 1, bp5_xindex = 4, bp5_yindex = 1, bp6_xindex = 5, bp6_yindex = 1, bp7_xindex = 6, bp7_yindex = 1, bp8_xindex = 7, bp8_yindex = 1, br1_xindex = 0, br1_yindex = 0, bn1_xindex = 1, bn1_yindex = 0, bb1_xindex = 2, bb1_yindex = 0, bq_xindex = 3, bq_yindex = 0, bk_xindex = 4, bk_yindex = 0, bb2_xindex = 5, bb2_yindex = 0, bn2_xindex = 6, bn2_yindex = 0, br2_xindex = 7, br2_yindex = 0;
        bool check_white_or_black = true;
        int t = 0, l = 0;
        
        
        ////////

        void wp_MouseDown(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref bool b)
        {
            if (e.ButtonState == e.LeftButton && check_white_or_black)
            {
                StackPanel.SetZIndex(elem, 1);
                if (!b)
                {
                    t = (int)elem.Margin.Top;
                    l = (int)elem.Margin.Left;
                }
                b = true;
                Xplace = e.GetPosition(this).X - elem.Margin.Left;
                Yplace = e.GetPosition(this).Y - elem.Margin.Top;

            }
        }
        void wp_MouseUp(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref int x, ref int y, ref bool b)
        {
            b = false;
            if (((t - (int)(elem.Margin.Top + 25) / 50 * 50 == 50 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 50) || (t - (int)(elem.Margin.Top + 25) / 50 * 50 == 50 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == -50)) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] < 0)
            {
                for (int i = ramka.Children.Count - 1; i >= 0; i--)
                {
                    UIElement child = ramka.Children[i];
                    Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                    if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                    {
                        ramka.Children.Remove(child);
                    }
                }
                elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 10;
                board[y, x] = 0;
                x = (int)(elem.Margin.Left + 25) / 50;
                y = (int)(elem.Margin.Top + 25) / 50;
                check_white_or_black = false;
                StackPanel.SetZIndex(elem, 0);
            }
            else if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0) && (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && ((t == 300 && (t - (int)(elem.Margin.Top + 25) / 50 * 50 == 100 || t - (int)(elem.Margin.Top + 25) / 50 * 50 == 50) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0) || ((t - (int)(elem.Margin.Top + 25) / 50 * 50 == 50) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0)))
            {
                elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 10;
                board[y, x] = 0;
                x = (int)(elem.Margin.Left + 25) / 50;
                y = (int)(elem.Margin.Top + 25) / 50;
                check_white_or_black = false;
                StackPanel.SetZIndex(elem, 0);
            }
            else
            {
                elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                StackPanel.SetZIndex(elem, 0);
            }
        }

        ////////




        void wp1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wp_MouseDown(sender, e, wp1, ref Wpawn1);
        }
        void wp1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wp_MouseUp(sender, e, wp1, ref wp1_xindex, ref wp1_yindex, ref Wpawn1);
        }
        void wp2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wp_MouseDown(sender, e, wp2, ref Wpawn2);
        }
        void wp2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wp_MouseUp(sender, e, wp2, ref wp2_xindex, ref wp2_yindex, ref Wpawn2);
        }
        void wp3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wp_MouseDown(sender, e, wp3, ref Wpawn3);
        }
        void wp3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wp_MouseUp(sender, e, wp3, ref wp3_xindex, ref wp3_yindex, ref Wpawn3);
        }
        void wp4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wp_MouseDown(sender, e, wp4, ref Wpawn4);
        }
        void wp4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wp_MouseUp(sender, e, wp4, ref wp4_xindex, ref wp4_yindex, ref Wpawn4);
        }
        void wp5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wp_MouseDown(sender, e, wp5, ref Wpawn5);
        }
        void wp5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wp_MouseUp(sender, e, wp5, ref wp5_xindex, ref wp5_yindex, ref Wpawn5);
        }
        void wp6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wp_MouseDown(sender, e, wp6, ref Wpawn6);
        }
        void wp6_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wp_MouseUp(sender, e, wp6, ref wp6_xindex, ref wp6_yindex, ref Wpawn6);
        }
        void wp7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wp_MouseDown(sender, e, wp7, ref Wpawn7);
        }
        void wp7_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wp_MouseUp(sender, e, wp7, ref wp7_xindex, ref wp7_yindex, ref Wpawn7);
        }
        void wp8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wp_MouseDown(sender, e, wp8, ref Wpawn8);
        }
        void wp8_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wp_MouseUp(sender, e, wp8, ref wp8_xindex, ref wp8_yindex, ref Wpawn8);
        }

        
        ////////////////////////////////
        void wr_MouseDown(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref bool b)
        {
            if (e.ButtonState == e.LeftButton && check_white_or_black)
            {
                StackPanel.SetZIndex(elem, 1);
                if (!b)
                {
                    t = (int)elem.Margin.Top;
                    l = (int)elem.Margin.Left;
                }
                b = true;
                Xplace = e.GetPosition(this).X - elem.Margin.Left;
                Yplace = e.GetPosition(this).Y - elem.Margin.Top;

            }
        }
        void wr_MouseUp(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref int x, ref int y, ref bool b)
        {
            b = false;
            if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] < 0)
            {
                int f = 1;
                if (t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[t / 50, i] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 50;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else if (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(t / 50, (int)(elem.Margin.Top + 25) / 50);
                    int max = Math.Max(t / 50, (int)(elem.Margin.Top + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[i, l / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 50;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else
                {
                    elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                    StackPanel.SetZIndex(elem, 0);
                }
            }
            else if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0)
            {
                int f = 1;
                if (t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[t / 50, i] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 50;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else if (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(t / 50, (int)(elem.Margin.Top + 25) / 50);
                    int max = Math.Max(t / 50, (int)(elem.Margin.Top + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[i, l / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 50;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(elem, 0);

                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else
                {
                    elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                    StackPanel.SetZIndex(elem, 0);
                }
            }
            else
            {
                elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                StackPanel.SetZIndex(elem, 0);
            }
        }


        ////////////////////////////////


        void wr1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wr_MouseDown(sender, e, wr1, ref Wrook1);
        }
        void wr1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wr_MouseUp(sender, e, wr1, ref wr1_xindex, ref wr1_yindex, ref Wrook1);
        }
        void wr2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wr_MouseDown(sender, e, wr2, ref Wrook2);
        }
        void wr2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wr_MouseUp(sender, e, wr2, ref wr2_xindex, ref wr2_yindex, ref Wrook2);
        }


        ///////////////////////////////////////////

        void wn_MouseDown(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref bool b)
        {
            if (e.ButtonState == e.LeftButton && check_white_or_black)
            {
                StackPanel.SetZIndex(elem, 1);
                if (!b)
                {
                    t = (int)elem.Margin.Top;
                    l = (int)elem.Margin.Left;
                }
                b = true;
                Xplace = e.GetPosition(this).X - elem.Margin.Left;
                Yplace = e.GetPosition(this).Y - elem.Margin.Top;

            }
        }
        void wn_MouseUp(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref int x, ref int y, ref bool b)
        {
            b = false;
            if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0)) && (((Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == 100 && Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50) == 50) || (Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50) == 100 && Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == 50)) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] < 0))
            {
                for (int i = ramka.Children.Count - 1; i >= 0; i--)
                {
                    UIElement child = ramka.Children[i];
                    Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                    if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                    {
                        ramka.Children.Remove(child);
                    }
                }
                elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 30;
                board[y, x] = 0;
                x = (int)(elem.Margin.Left + 25) / 50;
                y = (int)(elem.Margin.Top + 25) / 50;
                check_white_or_black = false;
                StackPanel.SetZIndex(elem, 0);
            }
            else if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0)) && (((Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == 100 && Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50) == 50) || (Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50) == 100 && Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == 50)) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0))
            {
                elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 30;
                board[y, x] = 0;
                x = (int)(elem.Margin.Left + 25) / 50;
                y = (int)(elem.Margin.Top + 25) / 50;
                check_white_or_black = false;
                StackPanel.SetZIndex(elem, 0);
            }
            else
            {
                elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                StackPanel.SetZIndex(elem, 0);
            }
        }


        ///////////////////////////////////////////


        void wn1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wn_MouseDown(sender, e, wn1, ref Wknight1);
        }
        void wn1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wn_MouseUp(sender, e, wn1, ref wn1_xindex, ref wn1_yindex, ref Wknight1);
        }

        void wn2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wn_MouseDown(sender, e, wn2, ref Wknight2);
        }
        void wn2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wn_MouseUp(sender, e, wn2, ref wn2_xindex, ref wn2_yindex, ref Wknight2);
        }


        ////////////////////////////////
        


        void wb_MouseDown(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref bool b)
        {
            if (e.ButtonState == e.LeftButton && check_white_or_black)
            {
                StackPanel.SetZIndex(elem, 1);
                if (!b)
                {
                    t = (int)elem.Margin.Top;
                    l = (int)elem.Margin.Left;
                }
                b = true;
                Xplace = e.GetPosition(this).X - elem.Margin.Left;
                Yplace = e.GetPosition(this).Y - elem.Margin.Top;

            }
        }
        void wb_MouseUp(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref int x, ref int y, ref bool b)
        {
            b = false;
            if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] < 0)
            {
                int f = 1;
                if (Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50))
                {
                    int min = Math.Min(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    for (int i = 1; i < max - min; i++)
                    {
                        if (board[(t - i * (t - (int)(elem.Margin.Top + 25)) / (max - min)) / 50, (l - i * (l - (int)(elem.Margin.Left + 25)) / (max - min)) / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 33;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else
                {
                    elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                    StackPanel.SetZIndex(elem, 0);
                }
            }
            else if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0)
            {
                int f = 1;
                if (Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50))
                {
                    int min = Math.Min(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    for (int i = 1; i < max - min; i++)
                    {
                        if (board[(t - i * (t - (int)(elem.Margin.Top + 25)) / (max-min)) / 50, (l - i * (l - (int)(elem.Margin.Left + 25)) / (max - min)) / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = 33;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else
                {
                    elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                    StackPanel.SetZIndex(elem, 0);
                }
            }
            else
            {
                elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                StackPanel.SetZIndex(elem, 0);
            }
        }


        ////////////////////////////////


        void wb1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wb_MouseDown(sender, e, wb1, ref Wbishop1);
        }
        void wb1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wb_MouseUp(sender, e, wb1, ref wb1_xindex, ref wb1_yindex, ref Wbishop1);
        }
        void wb2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wb_MouseDown(sender, e, wb2, ref Wbishop2);
        }
        void wb2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            wb_MouseUp(sender, e, wb2, ref wb2_xindex, ref wb2_yindex, ref Wbishop2);
        }





        void wk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == e.LeftButton && check_white_or_black)
            {
                StackPanel.SetZIndex(wk, 1);
                if (!Wking)
                {
                    t = (int)wk.Margin.Top;
                    l = (int)wk.Margin.Left;
                }
                Wking = true;
                Xplace = e.GetPosition(this).X - wk.Margin.Left;
                Yplace = e.GetPosition(this).Y - wk.Margin.Top;

            }
        }
        void wk_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wking = false;
            if (!(t - (int)(wk.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(wk.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(wk.Margin.Top + 25) / 50, (int)(wk.Margin.Left + 25) / 50] < 0)
            {
                if (t - (int)(wk.Margin.Top + 25) / 50 * 50 == 0 && Math.Abs(l - (int)(wk.Margin.Left + 25) / 50 * 50) == 50)
                {
                    for (int i = ramka.Children.Count - 1; i >= 0; i--)
                    {
                        UIElement child = ramka.Children[i];
                        Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                        if (marginChild.Top == (int)(wk.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(wk.Margin.Left + 25) / 50 * 50)
                        {
                            ramka.Children.Remove(child);
                        }
                    }
                    wk.Margin = new Thickness((int)(wk.Margin.Left + 25) / 50 * 50, (int)(wk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(wk.Margin.Top + 25) / 50, (int)(wk.Margin.Left + 25) / 50] = 1000;
                    board[wk_yindex, wk_xindex] = 0;
                    wk_xindex = (int)(wk.Margin.Left + 25) / 50;
                    wk_yindex = (int)(wk.Margin.Top + 25) / 50;
                    check_white_or_black = false;
                    StackPanel.SetZIndex(wk, 0);
                }
                else if (l - (int)(wk.Margin.Left + 25) / 50 * 50 == 0 && Math.Abs(t - (int)(wk.Margin.Top + 25) / 50 * 50) == 50)
                {
                    for (int i = ramka.Children.Count - 1; i >= 0; i--)
                    {
                        UIElement child = ramka.Children[i];
                        Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                        if (marginChild.Top == (int)(wk.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(wk.Margin.Left + 25) / 50 * 50)
                        {
                            ramka.Children.Remove(child);
                        }
                    }
                    wk.Margin = new Thickness((int)(wk.Margin.Left + 25) / 50 * 50, (int)(wk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(wk.Margin.Top + 25) / 50, (int)(wk.Margin.Left + 25) / 50] = 1000;
                    board[wk_yindex, wk_xindex] = 0;
                    wk_xindex = (int)(wk.Margin.Left + 25) / 50;
                    wk_yindex = (int)(wk.Margin.Top + 25) / 50;
                    check_white_or_black = false;
                    StackPanel.SetZIndex(wk, 0);
                }
                else if (Math.Abs(t - (int)(wk.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(wk.Margin.Left + 25) / 50 * 50) && Math.Abs(t - (int)(wk.Margin.Top + 25) / 50 * 50) == 50)
                {
                    for (int i = ramka.Children.Count - 1; i >= 0; i--)
                    {
                        UIElement child = ramka.Children[i];
                        Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                        if (marginChild.Top == (int)(wk.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(wk.Margin.Left + 25) / 50 * 50)
                        {
                            ramka.Children.Remove(child);
                        }
                    }
                    wk.Margin = new Thickness((int)(wk.Margin.Left + 25) / 50 * 50, (int)(wk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(wk.Margin.Top + 25) / 50, (int)(wk.Margin.Left + 25) / 50] = 1000;
                    board[wk_yindex, wk_xindex] = 0;
                    wk_xindex = (int)(wk.Margin.Left + 25) / 50;
                    wk_yindex = (int)(wk.Margin.Top + 25) / 50;
                    check_white_or_black = false;
                    StackPanel.SetZIndex(wk, 0);
                }
                else
                {
                    wk.Margin = new Thickness(wk_xindex * 50, wk_yindex * 50, 0, 0);
                    StackPanel.SetZIndex(wk, 0);
                }
            }
            else if (!(t - (int)(wk.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(wk.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(wk.Margin.Top + 25) / 50, (int)(wk.Margin.Left + 25) / 50] == 0)
            {
                if (t - (int)(wk.Margin.Top + 25) / 50 * 50 == 0 && Math.Abs(l - (int)(wk.Margin.Left + 25) / 50 * 50) == 50)
                {
                    wk.Margin = new Thickness((int)(wk.Margin.Left + 25) / 50 * 50, (int)(wk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(wk.Margin.Top + 25) / 50, (int)(wk.Margin.Left + 25) / 50] = 1000;
                    board[wk_yindex, wk_xindex] = 0;
                    wk_xindex = (int)(wk.Margin.Left + 25) / 50;
                    wk_yindex = (int)(wk.Margin.Top + 25) / 50;
                    check_white_or_black = false;
                    StackPanel.SetZIndex(wk, 0);
                }
                else if (l - (int)(wk.Margin.Left + 25) / 50 * 50 == 0 && Math.Abs(t - (int)(wk.Margin.Top + 25) / 50 * 50) == 50)
                {
                    wk.Margin = new Thickness((int)(wk.Margin.Left + 25) / 50 * 50, (int)(wk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(wk.Margin.Top + 25) / 50, (int)(wk.Margin.Left + 25) / 50] = 1000;
                    board[wk_yindex, wk_xindex] = 0;
                    wk_xindex = (int)(wk.Margin.Left + 25) / 50;
                    wk_yindex = (int)(wk.Margin.Top + 25) / 50;
                    check_white_or_black = false;
                    StackPanel.SetZIndex(wk, 0);
                }
                else if (Math.Abs(t - (int)(wk.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(wk.Margin.Left + 25) / 50 * 50) && Math.Abs(t - (int)(wk.Margin.Top + 25) / 50 * 50) == 50)
                {
                    wk.Margin = new Thickness((int)(wk.Margin.Left + 25) / 50 * 50, (int)(wk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(wk.Margin.Top + 25) / 50, (int)(wk.Margin.Left + 25) / 50] = 1000;
                    board[wk_yindex, wk_xindex] = 0;
                    wk_xindex = (int)(wk.Margin.Left + 25) / 50;
                    wk_yindex = (int)(wk.Margin.Top + 25) / 50;
                    check_white_or_black = false;
                    StackPanel.SetZIndex(wk, 0);
                }
                else
                {
                    wk.Margin = new Thickness(wk_xindex * 50, wk_yindex * 50, 0, 0);
                    StackPanel.SetZIndex(wk, 0);
                }
            }
            else
            {
                wk.Margin = new Thickness(wk_xindex * 50, wk_yindex * 50, 0, 0);
                StackPanel.SetZIndex(wk, 0);
            }
        }


        ///////////////////////////////////////////






        ////////////////////////////////
        void wq_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == e.LeftButton && check_white_or_black)
            {
                StackPanel.SetZIndex(wq, 1);
                if (!Wqueen)
                {
                    t = (int)wq.Margin.Top;
                    l = (int)wq.Margin.Left;
                }
                Wqueen = true;
                Xplace = e.GetPosition(this).X - wq.Margin.Left;
                Yplace = e.GetPosition(this).Y - wq.Margin.Top;

            }
        }
        void wq_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Wqueen = false;
            if (!(t - (int)(wq.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(wq.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(wq.Margin.Top + 25) / 50, (int)(wq.Margin.Left + 25) / 50] < 0)
            {
                int f = 1;
                if (t - (int)(wq.Margin.Top + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(l / 50, (int)(wq.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(wq.Margin.Left + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[t / 50, i] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(wq.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(wq.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        wq.Margin = new Thickness((int)(wq.Margin.Left + 25) / 50 * 50, (int)(wq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(wq.Margin.Top + 25) / 50, (int)(wq.Margin.Left + 25) / 50] = 90;
                        board[wq_yindex, wq_xindex] = 0;
                        wq_xindex = (int)(wq.Margin.Left + 25) / 50;
                        wq_yindex = (int)(wq.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(wq, 0);
                    }
                    else
                    {
                        wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(wq, 0);
                    }
                }
                else if (l - (int)(wq.Margin.Left + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(t / 50, (int)(wq.Margin.Top + 25) / 50);
                    int max = Math.Max(t / 50, (int)(wq.Margin.Top + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[i, l / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(wq.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(wq.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        wq.Margin = new Thickness((int)(wq.Margin.Left + 25) / 50 * 50, (int)(wq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(wq.Margin.Top + 25) / 50, (int)(wq.Margin.Left + 25) / 50] = 90;
                        board[wq_yindex, wq_xindex] = 0;
                        wq_xindex = (int)(wq.Margin.Left + 25) / 50;
                        wq_yindex = (int)(wq.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(wq, 0);
                    }
                    else
                    {
                        wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(wq, 0);
                    }
                }
                else if (Math.Abs(t - (int)(wq.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(wq.Margin.Left + 25) / 50 * 50))
                {
                    int min = Math.Min(l / 50, (int)(wq.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(wq.Margin.Left + 25) / 50);
                    for (int i = 1; i < max - min; i++)
                    {
                        if (board[(t - i * (t - (int)(wq.Margin.Top + 25)) / (max - min)) / 50, (l - i * (l - (int)(wq.Margin.Left + 25)) / (max - min)) / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(wq.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(wq.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        wq.Margin = new Thickness((int)(wq.Margin.Left + 25) / 50 * 50, (int)(wq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(wq.Margin.Top + 25) / 50, (int)(wq.Margin.Left + 25) / 50] = 90;
                        board[wq_yindex, wq_xindex] = 0;
                        wq_xindex = (int)(wq.Margin.Left + 25) / 50;
                        wq_yindex = (int)(wq.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(wq, 0);
                    }
                    else
                    {
                        wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(wq, 0);
                    }
                }
                else
                {
                    wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                    StackPanel.SetZIndex(wq, 0);
                }
            }
            else if (!(t - (int)(wq.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(wq.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(wq.Margin.Top + 25) / 50, (int)(wq.Margin.Left + 25) / 50] == 0)
            {
                int f = 1;
                if (t - (int)(wq.Margin.Top + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(l / 50, (int)(wq.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(wq.Margin.Left + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[t / 50, i] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        wq.Margin = new Thickness((int)(wq.Margin.Left + 25) / 50 * 50, (int)(wq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(wq.Margin.Top + 25) / 50, (int)(wq.Margin.Left + 25) / 50] = 90;
                        board[wq_yindex, wq_xindex] = 0;
                        wq_xindex = (int)(wq.Margin.Left + 25) / 50;
                        wq_yindex = (int)(wq.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(wq, 0);
                    }
                    else
                    {
                        wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(wq, 0);
                    }
                }
                else if (l - (int)(wq.Margin.Left + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(t / 50, (int)(wq.Margin.Top + 25) / 50);
                    int max = Math.Max(t / 50, (int)(wq.Margin.Top + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[i, l / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        wq.Margin = new Thickness((int)(wq.Margin.Left + 25) / 50 * 50, (int)(wq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(wq.Margin.Top + 25) / 50, (int)(wq.Margin.Left + 25) / 50] = 90;
                        board[wq_yindex, wq_xindex] = 0;
                        wq_xindex = (int)(wq.Margin.Left + 25) / 50;
                        wq_yindex = (int)(wq.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(wq, 0);

                    }
                    else
                    {
                        wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(wq, 0);
                    }
                }
                else if (Math.Abs(t - (int)(wq.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(wq.Margin.Left + 25) / 50 * 50))
                {
                    int min = Math.Min(l / 50, (int)(wq.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(wq.Margin.Left + 25) / 50);
                    for (int i = 1; i < max - min; i++)
                    {
                        if (board[(t - i * (t - (int)(wq.Margin.Top + 25)) / (max - min)) / 50, (l - i * (l - (int)(wq.Margin.Left + 25)) / (max - min)) / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        wq.Margin = new Thickness((int)(wq.Margin.Left + 25) / 50 * 50, (int)(wq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(wq.Margin.Top + 25) / 50, (int)(wq.Margin.Left + 25) / 50] = 90;
                        board[wq_yindex, wq_xindex] = 0;
                        wq_xindex = (int)(wq.Margin.Left + 25) / 50;
                        wq_yindex = (int)(wq.Margin.Top + 25) / 50;
                        check_white_or_black = false;
                        StackPanel.SetZIndex(wq, 0);
                    }
                    else
                    {
                        wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(wq, 0);
                    }
                }
                else
                {
                    wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                    StackPanel.SetZIndex(wq, 0);
                }
            }
            else
            {
                wq.Margin = new Thickness(wq_xindex * 50, wq_yindex * 50, 0, 0);
                StackPanel.SetZIndex(wq, 0);
            }
        }


        ///////////////////////////////////////////








        void bp_MouseDown(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref bool b)
        {
            if (e.ButtonState == e.LeftButton && !check_white_or_black)
            {
                StackPanel.SetZIndex(elem, 1);
                if (!b)
                {
                    t = (int)elem.Margin.Top;
                    l = (int)elem.Margin.Left;
                }
                b = true;
                Xplace = e.GetPosition(this).X - elem.Margin.Left;
                Yplace = e.GetPosition(this).Y - elem.Margin.Top;
            }
        }


        void bp_MouseUp(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref int x, ref int y, ref bool b)
        {
            b = false;
            if (((t - (int)(elem.Margin.Top + 25) / 50 * 50 == -50 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == -50) || (t - (int)(elem.Margin.Top + 25) / 50 * 50 == -50 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 50)) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] > 0)
            {
                for (int i = ramka.Children.Count - 1; i >= 0; i--)
                {
                    UIElement child = ramka.Children[i];
                    Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                    if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                    {
                        ramka.Children.Remove(child);
                    }
                }
                elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -10;
                board[y, x] = 0;
                x = (int)(elem.Margin.Left + 25) / 50;
                y = (int)(elem.Margin.Top + 25) / 50;
                check_white_or_black = true;
                StackPanel.SetZIndex(elem, 0);
            }
            else if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0) && (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && ((t == 50 && (t - (int)(elem.Margin.Top + 25) / 50 * 50 == -100 || t - (int)(elem.Margin.Top + 25) / 50 * 50 == -50) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0) || ((t - (int)(elem.Margin.Top + 25) / 50 * 50 == -50) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0)))
            {
                elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -10;
                board[y, x] = 0;
                board[t / 50, l / 50] = 0;
                x = (int)(elem.Margin.Left + 25) / 50;
                y = (int)(elem.Margin.Top + 25) / 50;
                check_white_or_black = true;
                StackPanel.SetZIndex(elem, 0);
            }
            else
            {
                elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                StackPanel.SetZIndex(elem, 0);
            }
        }


        ///////////////////////////////////////////



        void bp1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bp_MouseDown(sender, e, bp1, ref Bpawn1);
        }
        void bp1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bp_MouseUp(sender, e, bp1, ref bp1_xindex, ref bp1_yindex, ref Bpawn1);
        }

        void bp2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bp_MouseDown(sender, e, bp2, ref Bpawn2);
        }
        void bp2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bp_MouseUp(sender, e, bp2, ref bp2_xindex, ref bp2_yindex, ref Bpawn2);
        }
        void bp3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bp_MouseDown(sender, e, bp3, ref Bpawn3);
        }
        void bp3_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bp_MouseUp(sender, e, bp3, ref bp3_xindex, ref bp3_yindex, ref Bpawn3);
        }
        void bp4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bp_MouseDown(sender, e, bp4, ref Bpawn4);
        }
        void bp4_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bp_MouseUp(sender, e, bp4, ref bp4_xindex, ref bp4_yindex, ref Bpawn4);
        }
        void bp5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bp_MouseDown(sender, e, bp5, ref Bpawn5);
        }
        void bp5_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bp_MouseUp(sender, e, bp5, ref bp5_xindex, ref bp5_yindex, ref Bpawn5);
        }
        void bp6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bp_MouseDown(sender, e, bp6, ref Bpawn6);
        }
        void bp6_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bp_MouseUp(sender, e, bp6, ref bp6_xindex, ref bp6_yindex, ref Bpawn6);
        }
        void bp7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bp_MouseDown(sender, e, bp7, ref Bpawn7);
        }
        void bp7_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bp_MouseUp(sender, e, bp7, ref bp7_xindex, ref bp7_yindex, ref Bpawn7);
        }
        void bp8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bp_MouseDown(sender, e, bp8, ref Bpawn8);
        }
        void bp8_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bp_MouseUp(sender, e, bp8, ref bp8_xindex, ref bp8_yindex, ref Bpawn8);
        }

        ///////////////////////////////////////////

        void br_MouseDown(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref bool b)
        {
            if (e.ButtonState == e.LeftButton && !check_white_or_black)
            {
                StackPanel.SetZIndex(elem, 1);
                if (!b)
                {
                    t = (int)elem.Margin.Top;
                    l = (int)elem.Margin.Left;
                }
                b = true;
                Xplace = e.GetPosition(this).X - elem.Margin.Left;
                Yplace = e.GetPosition(this).Y - elem.Margin.Top;

            }
        }
        void br_MouseUp(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref int x, ref int y, ref bool b)
        {
            b = false;
            if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] > 0)
            {
                int f = 1;
                if (t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[t / 50, i] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -50;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else if (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(t / 50, (int)(elem.Margin.Top + 25) / 50);
                    int max = Math.Max(t / 50, (int)(elem.Margin.Top + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[i, l / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -50;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else
                {
                    elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                    StackPanel.SetZIndex(elem, 0);
                }
            }
            else if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0)
            {
                int f = 1;
                if (t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[t / 50, i] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -50;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else if (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(t / 50, (int)(elem.Margin.Top + 25) / 50);
                    int max = Math.Max(t / 50, (int)(elem.Margin.Top + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[i, l / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -50;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else
                {
                    elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                    StackPanel.SetZIndex(elem, 0);
                }
            }
            else
            {
                elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                StackPanel.SetZIndex(elem, 0);
            }
        }



        ///////////////////////////////////////////
        




        void br1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            br_MouseDown(sender, e, br1, ref Brook1);
        }
        void br1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            br_MouseUp(sender, e, br1, ref br1_xindex, ref br1_yindex, ref Brook1);
        }
        void br2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            br_MouseDown(sender, e, br2, ref Brook2);
        }
        void br2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            br_MouseUp(sender, e, br2, ref br2_xindex, ref br2_yindex, ref Brook2);
        }


        ///////////////////////////////////////////

        void bn_MouseDown(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref bool b)
        {
            if (e.ButtonState == e.LeftButton && !check_white_or_black)
            {
                StackPanel.SetZIndex(elem, 1);
                if (!b)
                {
                    t = (int)elem.Margin.Top;
                    l = (int)elem.Margin.Left;
                }
                b = true;
                Xplace = e.GetPosition(this).X - elem.Margin.Left;
                Yplace = e.GetPosition(this).Y - elem.Margin.Top;

            }
        }
        void bn_MouseUp(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref int x, ref int y, ref bool b)
        {
            b = false;
            if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0)) && (((Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == 100 && Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50) == 50) || (Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50) == 100 && Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == 50)) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] > 0))
            {
                for (int i = ramka.Children.Count - 1; i >= 0; i--)
                {
                    UIElement child = ramka.Children[i];
                    Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                    if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                    {
                        ramka.Children.Remove(child);
                    }
                }
                elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -30;
                board[y, x] = 0;
                x = (int)(elem.Margin.Left + 25) / 50;
                y = (int)(elem.Margin.Top + 25) / 50;
                check_white_or_black = true;
                StackPanel.SetZIndex(elem, 0);
            }
            else if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && (l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0)) && (((Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == 100 && Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50) == 50) || (Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50) == 100 && Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == 50)) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0))
            {
                elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -30;
                board[y, x] = 0;
                x = (int)(elem.Margin.Left + 25) / 50;
                y = (int)(elem.Margin.Top + 25) / 50;
                check_white_or_black = true;
                StackPanel.SetZIndex(elem, 0);
            }
            else
            {
                elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                StackPanel.SetZIndex(elem, 0);
            }
        }

        ///////////////////////////////////////////

        void bn1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bn_MouseDown(sender, e, bn1, ref Bknight1);
        }
        void bn1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bn_MouseUp(sender, e, bn1, ref bn1_xindex, ref bn1_yindex, ref Bknight1);
        }

        void bn2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bn_MouseDown(sender, e, bn2, ref Bknight2);
        }
        void bn2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bn_MouseUp(sender, e, bn2, ref bn2_xindex, ref bn2_yindex, ref Bknight2);
        }

        ///////////////////////////////////////////

        void bb_MouseDown(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref bool b)
        {
            if (e.ButtonState == e.LeftButton && !check_white_or_black)
            {
                StackPanel.SetZIndex(elem, 1);
                if (!b)
                {
                    t = (int)elem.Margin.Top;
                    l = (int)elem.Margin.Left;
                }
                b = true;
                Xplace = e.GetPosition(this).X - elem.Margin.Left;
                Yplace = e.GetPosition(this).Y - elem.Margin.Top;

            }
        }

        void bb_MouseUp(object sender, MouseButtonEventArgs e, FrameworkElement elem, ref int x, ref int y, ref bool b)
        {
            b = false;
            if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] > 0)
            {
                int f = 1;
                if (Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50))
                {
                    int min = Math.Min(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    for (int i = 1; i < max - min; i++)
                    {
                        if (board[(t - i * (t - (int)(elem.Margin.Top + 25)) / (max - min)) / 50, (l - i * (l - (int)(elem.Margin.Left + 25)) / (max - min)) / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(elem.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(elem.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -33;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else
                {
                    elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                    StackPanel.SetZIndex(elem, 0);
                }
            }
            else if (!(t - (int)(elem.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(elem.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] == 0)
            {
                int f = 1;
                if (Math.Abs(t - (int)(elem.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(elem.Margin.Left + 25) / 50 * 50))
                {
                    int min = Math.Min(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(elem.Margin.Left + 25) / 50);
                    for (int i = 1; i < max - min; i++)
                    {
                        if (board[(t - i * (t - (int)(elem.Margin.Top + 25)) / (max - min)) / 50, (l - i * (l - (int)(elem.Margin.Left + 25)) / (max - min)) / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        elem.Margin = new Thickness((int)(elem.Margin.Left + 25) / 50 * 50, (int)(elem.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(elem.Margin.Top + 25) / 50, (int)(elem.Margin.Left + 25) / 50] = -33;
                        board[y, x] = 0;
                        x = (int)(elem.Margin.Left + 25) / 50;
                        y = (int)(elem.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(elem, 0);
                    }
                    else
                    {
                        elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                        StackPanel.SetZIndex(elem, 0);
                    }
                }
                else
                {
                    elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                    StackPanel.SetZIndex(elem, 0);
                }
            }
            else
            {
                elem.Margin = new Thickness(x * 50, y * 50, 0, 0);
                StackPanel.SetZIndex(elem, 0);
            }
        }


        ////////////////////////////////


        void bb1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bb_MouseDown(sender, e, bb1, ref Bbishop1);
        }
        void bb1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bb_MouseUp(sender, e, bb1, ref bb1_xindex, ref bb1_yindex, ref Bbishop1);
        }
        void bb2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bb_MouseDown(sender, e, bb2, ref Bbishop2);
        }
        void bb2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bb_MouseUp(sender, e, bb2, ref bb2_xindex, ref bb2_yindex, ref Bbishop2);
        }
        ///////////////////////////////////////


        void bk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == e.LeftButton && !check_white_or_black)
            {
                StackPanel.SetZIndex(bk, 1);
                if (!Bking)
                {
                    t = (int)bk.Margin.Top;
                    l = (int)bk.Margin.Left;
                }
                Bking = true;
                Xplace = e.GetPosition(this).X - bk.Margin.Left;
                Yplace = e.GetPosition(this).Y - bk.Margin.Top;

            }
        }
        void bk_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Bking = false;
            if (!(t - (int)(bk.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(bk.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(bk.Margin.Top + 25) / 50, (int)(bk.Margin.Left + 25) / 50] > 0)
            {
                if (t - (int)(bk.Margin.Top + 25) / 50 * 50 == 0 && Math.Abs(l - (int)(bk.Margin.Left + 25) / 50 * 50) == 50)
                {
                    for (int i = ramka.Children.Count - 1; i >= 0; i--)
                    {
                        UIElement child = ramka.Children[i];
                        Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                        if (marginChild.Top == (int)(bk.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(bk.Margin.Left + 25) / 50 * 50)
                        {
                            ramka.Children.Remove(child);
                        }
                    }
                    bk.Margin = new Thickness((int)(bk.Margin.Left + 25) / 50 * 50, (int)(bk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(bk.Margin.Top + 25) / 50, (int)(bk.Margin.Left + 25) / 50] = -1000;
                    board[bk_yindex, bk_xindex] = 0;
                    bk_xindex = (int)(bk.Margin.Left + 25) / 50;
                    bk_yindex = (int)(bk.Margin.Top + 25) / 50;
                    check_white_or_black = true;
                    StackPanel.SetZIndex(bk, 0);
                }
                else if (l - (int)(bk.Margin.Left + 25) / 50 * 50 == 0 && Math.Abs(t - (int)(bk.Margin.Top + 25) / 50 * 50) == 50)
                {
                    for (int i = ramka.Children.Count - 1; i >= 0; i--)
                    {
                        UIElement child = ramka.Children[i];
                        Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                        if (marginChild.Top == (int)(bk.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(bk.Margin.Left + 25) / 50 * 50)
                        {
                            ramka.Children.Remove(child);
                        }
                    }
                    bk.Margin = new Thickness((int)(bk.Margin.Left + 25) / 50 * 50, (int)(bk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(bk.Margin.Top + 25) / 50, (int)(bk.Margin.Left + 25) / 50] = -1000;
                    board[bk_yindex, bk_xindex] = 0;
                    bk_xindex = (int)(bk.Margin.Left + 25) / 50;
                    bk_yindex = (int)(bk.Margin.Top + 25) / 50;
                    check_white_or_black = true;
                    StackPanel.SetZIndex(bk, 0);
                }
                else if (Math.Abs(t - (int)(bk.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(bk.Margin.Left + 25) / 50 * 50) && Math.Abs(t - (int)(bk.Margin.Top + 25) / 50 * 50) == 50)
                {
                    for (int i = ramka.Children.Count - 1; i >= 0; i--)
                    {
                        UIElement child = ramka.Children[i];
                        Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                        if (marginChild.Top == (int)(bk.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(bk.Margin.Left + 25) / 50 * 50)
                        {
                            ramka.Children.Remove(child);
                        }
                    }
                    bk.Margin = new Thickness((int)(bk.Margin.Left + 25) / 50 * 50, (int)(bk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(bk.Margin.Top + 25) / 50, (int)(bk.Margin.Left + 25) / 50] = -1000;
                    board[bk_yindex, bk_xindex] = 0;
                    bk_xindex = (int)(bk.Margin.Left + 25) / 50;
                    bk_yindex = (int)(bk.Margin.Top + 25) / 50;
                    check_white_or_black = true;
                    StackPanel.SetZIndex(bk, 0);
                }
                else
                {
                    bk.Margin = new Thickness(bk_xindex * 50, bk_yindex * 50, 0, 0);
                    StackPanel.SetZIndex(bk, 0);
                }
            }
            else if (!(t - (int)(bk.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(bk.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(bk.Margin.Top + 25) / 50, (int)(bk.Margin.Left + 25) / 50] == 0)
            {
                if (t - (int)(bk.Margin.Top + 25) / 50 * 50 == 0 && Math.Abs(l - (int)(bk.Margin.Left + 25) / 50 * 50) == 50)
                {
                    bk.Margin = new Thickness((int)(bk.Margin.Left + 25) / 50 * 50, (int)(bk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(bk.Margin.Top + 25) / 50, (int)(bk.Margin.Left + 25) / 50] = -1000;
                    board[bk_yindex, bk_xindex] = 0;
                    bk_xindex = (int)(bk.Margin.Left + 25) / 50;
                    bk_yindex = (int)(bk.Margin.Top + 25) / 50;
                    check_white_or_black = true;
                    StackPanel.SetZIndex(bk, 0);
                }
                else if (l - (int)(bk.Margin.Left + 25) / 50 * 50 == 0 && Math.Abs(t - (int)(bk.Margin.Top + 25) / 50 * 50) == 50)
                {
                    bk.Margin = new Thickness((int)(bk.Margin.Left + 25) / 50 * 50, (int)(bk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(bk.Margin.Top + 25) / 50, (int)(bk.Margin.Left + 25) / 50] = -1000;
                    board[bk_yindex, bk_xindex] = 0;
                    bk_xindex = (int)(bk.Margin.Left + 25) / 50;
                    bk_yindex = (int)(bk.Margin.Top + 25) / 50;
                    check_white_or_black = true;
                    StackPanel.SetZIndex(bk, 0);
                }
                else if (Math.Abs(t - (int)(bk.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(bk.Margin.Left + 25) / 50 * 50) && Math.Abs(t - (int)(bk.Margin.Top + 25) / 50 * 50) == 50)
                {
                    bk.Margin = new Thickness((int)(bk.Margin.Left + 25) / 50 * 50, (int)(bk.Margin.Top + 25) / 50 * 50, 0, 0);
                    board[(int)(bk.Margin.Top + 25) / 50, (int)(bk.Margin.Left + 25) / 50] = -1000;
                    board[bk_yindex, bk_xindex] = 0;
                    bk_xindex = (int)(bk.Margin.Left + 25) / 50;
                    bk_yindex = (int)(bk.Margin.Top + 25) / 50;
                    check_white_or_black = true;
                    StackPanel.SetZIndex(bk, 0);
                }
                else
                {
                    bk.Margin = new Thickness(bk_xindex * 50, bk_yindex * 50, 0, 0);
                    StackPanel.SetZIndex(bk, 0);
                }
            }
            else
            {
                bk.Margin = new Thickness(bk_xindex * 50, bk_yindex * 50, 0, 0);
                StackPanel.SetZIndex(bk, 0);
            }
        }

        ///////////////////////////////////////////
        
        void bq_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == e.LeftButton && !check_white_or_black)
            {
                StackPanel.SetZIndex(bq, 1);
                if (!Bqueen)
                {
                    t = (int)bq.Margin.Top;
                    l = (int)bq.Margin.Left;
                }
                Bqueen = true;
                Xplace = e.GetPosition(this).X - bq.Margin.Left;
                Yplace = e.GetPosition(this).Y - bq.Margin.Top;

            }
        }
        void bq_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Bqueen = false;
            if (!(t - (int)(bq.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(bq.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(bq.Margin.Top + 25) / 50, (int)(bq.Margin.Left + 25) / 50] > 0)
            {
                int f = 1;
                if (t - (int)(bq.Margin.Top + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(l / 50, (int)(bq.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(bq.Margin.Left + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[t / 50, i] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(bq.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(bq.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        bq.Margin = new Thickness((int)(bq.Margin.Left + 25) / 50 * 50, (int)(bq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(bq.Margin.Top + 25) / 50, (int)(bq.Margin.Left + 25) / 50] = -90;
                        board[bq_yindex, bq_xindex] = 0;
                        bq_xindex = (int)(bq.Margin.Left + 25) / 50;
                        bq_yindex = (int)(bq.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(bq, 0);
                    }
                    else
                    {
                        bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(bq, 0);
                    }
                }
                else if (l - (int)(bq.Margin.Left + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(t / 50, (int)(bq.Margin.Top + 25) / 50);
                    int max = Math.Max(t / 50, (int)(bq.Margin.Top + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[i, l / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(bq.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(bq.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        bq.Margin = new Thickness((int)(bq.Margin.Left + 25) / 50 * 50, (int)(bq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(bq.Margin.Top + 25) / 50, (int)(bq.Margin.Left + 25) / 50] = -90;
                        board[bq_yindex, bq_xindex] = 0;
                        bq_xindex = (int)(bq.Margin.Left + 25) / 50;
                        bq_yindex = (int)(bq.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(bq, 0);
                    }
                    else
                    {
                        bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(bq, 0);
                    }
                }
                else if (Math.Abs(t - (int)(bq.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(bq.Margin.Left + 25) / 50 * 50))
                {
                    int min = Math.Min(l / 50, (int)(bq.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(bq.Margin.Left + 25) / 50);
                    for (int i = 1; i < max - min; i++)
                    {
                        if (board[(t - i * (t - (int)(bq.Margin.Top + 25)) / (max - min)) / 50, (l - i * (l - (int)(bq.Margin.Left + 25)) / (max - min)) / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        for (int i = ramka.Children.Count - 1; i >= 0; i--)
                        {
                            UIElement child = ramka.Children[i];
                            Thickness marginChild = (Thickness)child.GetValue(FrameworkElement.MarginProperty);
                            if (marginChild.Top == (int)(bq.Margin.Top + 25) / 50 * 50 && marginChild.Left == (int)(bq.Margin.Left + 25) / 50 * 50)
                            {
                                ramka.Children.Remove(child);
                            }
                        }
                        bq.Margin = new Thickness((int)(bq.Margin.Left + 25) / 50 * 50, (int)(bq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(bq.Margin.Top + 25) / 50, (int)(bq.Margin.Left + 25) / 50] = -90;
                        board[bq_yindex, bq_xindex] = 0;
                        bq_xindex = (int)(bq.Margin.Left + 25) / 50;
                        bq_yindex = (int)(bq.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(bq, 0);
                    }
                    else
                    {
                        bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(bq, 0);
                    }
                }
                else
                {
                    bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                    StackPanel.SetZIndex(bq, 0);
                }
            }
            else if (!(t - (int)(bq.Margin.Top + 25) / 50 * 50 == 0 && l - (int)(bq.Margin.Left + 25) / 50 * 50 == 0) && board[(int)(bq.Margin.Top + 25) / 50, (int)(bq.Margin.Left + 25) / 50] == 0)
            {
                int f = 1;
                if (t - (int)(bq.Margin.Top + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(l / 50, (int)(bq.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(bq.Margin.Left + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[t / 50, i] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        bq.Margin = new Thickness((int)(bq.Margin.Left + 25) / 50 * 50, (int)(bq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(bq.Margin.Top + 25) / 50, (int)(bq.Margin.Left + 25) / 50] = -90;
                        board[bq_yindex, bq_xindex] = 0;
                        bq_xindex = (int)(bq.Margin.Left + 25) / 50;
                        bq_yindex = (int)(bq.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(bq, 0);
                    }
                    else
                    {
                        bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(bq, 0);
                    }
                }
                else if (l - (int)(bq.Margin.Left + 25) / 50 * 50 == 0)
                {
                    int min = Math.Min(t / 50, (int)(bq.Margin.Top + 25) / 50);
                    int max = Math.Max(t / 50, (int)(bq.Margin.Top + 25) / 50);
                    for (int i = min + 1; i < max; i++)
                    {
                        if (board[i, l / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        bq.Margin = new Thickness((int)(bq.Margin.Left + 25) / 50 * 50, (int)(bq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(bq.Margin.Top + 25) / 50, (int)(bq.Margin.Left + 25) / 50] = -90;
                        board[bq_yindex, bq_xindex] = 0;
                        bq_xindex = (int)(bq.Margin.Left + 25) / 50;
                        bq_yindex = (int)(bq.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(bq, 0);

                    }
                    else
                    {
                        bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(bq, 0);
                    }
                }
                else if (Math.Abs(t - (int)(bq.Margin.Top + 25) / 50 * 50) == Math.Abs(l - (int)(bq.Margin.Left + 25) / 50 * 50))
                {
                    int min = Math.Min(l / 50, (int)(bq.Margin.Left + 25) / 50);
                    int max = Math.Max(l / 50, (int)(bq.Margin.Left + 25) / 50);
                    for (int i = 1; i < max - min; i++)
                    {
                        if (board[(t - i * (t - (int)(bq.Margin.Top + 25)) / (max - min)) / 50, (l - i * (l - (int)(bq.Margin.Left + 25)) / (max - min)) / 50] != 0)
                        {
                            f = 0;
                        }
                    }
                    if (f == 1)
                    {
                        bq.Margin = new Thickness((int)(bq.Margin.Left + 25) / 50 * 50, (int)(bq.Margin.Top + 25) / 50 * 50, 0, 0);
                        board[(int)(bq.Margin.Top + 25) / 50, (int)(bq.Margin.Left + 25) / 50] = -90;
                        board[bq_yindex, bq_xindex] = 0;
                        bq_xindex = (int)(bq.Margin.Left + 25) / 50;
                        bq_yindex = (int)(bq.Margin.Top + 25) / 50;
                        check_white_or_black = true;
                        StackPanel.SetZIndex(bq, 0);
                    }
                    else
                    {
                        bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                        StackPanel.SetZIndex(bq, 0);
                    }
                }
                else
                {
                    bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                    StackPanel.SetZIndex(bq, 0);
                }
            }
            else
            {
                bq.Margin = new Thickness(bq_xindex * 50, bq_yindex * 50, 0, 0);
                StackPanel.SetZIndex(bq, 0);
            }
        }
        ///////////////////////////////////////////
    }
} 
