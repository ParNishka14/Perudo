using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Perudo
{
    public partial class MainWindow : Window
    {
        int stageGame = 0;
        int whoStartFirst = 0;

        int currentNominal = 0;
        int currentCount = 0;
        
        Player pl3 = new Player();
        Player pl1 = new Player();
        Player pl2 = new Player();
        public MainWindow()
        {
            InitializeComponent();

            pl1.generetionCubes();
            pl1.name = "Игрок 1";
            //Cubic1.Text = pl1.getCubes();

            pl3.generetionCubes();
            pl3.name = "Игрок 3";
            //Cubic3.Text = pl3.getCubes();
            pl2.generetionCubes();
            pl2.name = "Вы";
           
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            roll();
        }

        public void roll()
        {
            int g1 = pl1.dropCube();
            Cubic1.Text = g1.ToString();


            int g2 = pl2.dropCube();
            Cubic2.Text = g2.ToString();


            int g3 = pl3.dropCube();
            Cubic3.Text = g3.ToString();
            if (g1 == g2 || g2 == g3 || g3 == g1)
            {
                roll();
            }
            else { 
            if (g1 > g2 && g1 > g3)
            {
                if (g2 > g3)
                {
                    addToLog(pl1.name + " ходит первый " + pl2.name + " ходит вторым", 4);
                        whoStartFirst = 1;
                }
                else
                {
                    addToLog(pl1.name + " ходит первый " + pl3.name + " ходит вторым", 4);
                        whoStartFirst = 1;
                }
            }
            else if (g2 > g3 && g2 > g1)
            {
                if (g3 > g1)
                {
                    addToLog(pl2.name + " ходит первый " + pl3.name + " ходит вторым", 4);
                        whoStartFirst = 2;
                }
                else
                {
                    addToLog(pl2.name + " ходит первый " + pl1.name + " ходит вторым", 4);
                        whoStartFirst = 2;
                }
            }
            else if (g3 > g1 && g3 > g2)
            {
                if (g2 > g1)
                {
                    addToLog(pl3.name + " ходит первый " + pl2.name + " ходит вторым", 4);
                        whoStartFirst = 3;
                }
                else
                {
                    addToLog(pl3.name + " ходит первый " + pl1.name + " ходит вторым", 4);
                        whoStartFirst = 3;
                }
            }
        }
        }

        public void addToLog(string who, int whatDo) { 

        TextBlock log = new TextBlock();
            string whatDoString = "";
            switch (whatDo)
            {
                case 1: whatDoString = " бросил кубики ";
                    break;
                case 2: whatDoString = " не верит ";
                    break;
                case 3: whatDoString = " повышает ";
                    break;
                case 4: whatDoString = "";
                    break;
                case 5: whatDoString = " считает что " + currentNominal + " = " + currentCount;
                    break;
            }
         log.Text = who + " " + whatDoString;
            LogBox.Items.Add(log);
        }

        public void clearLog() { 
        LogBox.Items.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Cubic3.Text = pl3.getCubes();
            Cubic2.Text = pl2.getCubes();
            Cubic1.Text = pl1.getCubes();
        }

        public void nextItteration() {
            if (whoStartFirst == 2)
            {
                Post.IsEnabled = true;
            }
            else {
                Post.IsEnabled = false;
                botSetPost(whoStartFirst);
            }
            if (whoStartFirst == 3) { 
            whoStartFirst = 1;
            }
            else { 
                whoStartFirst++; 
            }
            
        }

        public void botSetPost(int id) { 
            
        }

        private void Post_Click(object sender, RoutedEventArgs e)
        {
            currentCount = Int32.Parse(Count.Text);
            currentNominal = Int32.Parse(Nominal.Text);
            addToLog(pl2.name,5);
            nextItteration();
        }
    }
}
