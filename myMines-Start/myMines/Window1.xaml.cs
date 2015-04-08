using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace myMines
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        internal DispatcherTimer timer;  //計時器
        int _height = 10;  //地雷盤高度格數(列數)
        int _width = 10;  //地雷盤寬度格數(行數) 
        int _mines = 10;  //地雷數
        int _count; //被標記為地雷的數目
        Game gm;  //遊戲類別物件

        public Window1()
        {
            InitializeComponent();
            //建立計時器實例、設定屬性及新增事件



            //重設遊戲畫面
            Reset();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //重設遊戲畫面
            Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //每一秒在計時Label內顯示秒數
        
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //判斷遊戲仍在進行且按下去的來源是Square類別的物件
            if (gm.IsStarted && e.Source.GetType() == typeof(Square))
            {
                //若計時器未啟動則啟動之


                Square s = (Square)e.Source;
                //判斷是否按下的是滑鼠左鍵
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    //打開格子(呼叫Game的Click Method傳入s當參數)
                    
                    if (gm.IsFinished)
                    {
                        //顯示完成訊息
                        MessageBox.Show("<系級/學號/姓名>\n恭喜您在 " + "lblTimer.Content" + " 秒內完成遊戲!");
                        Reset();
                    }
                }
                //判斷是否按下的是滑鼠右鍵
                else if (e.RightButton == MouseButtonState.Pressed)
                {
                    //標註地雷 (呼叫Square物件s的DismantleClick Method)
                    
                    _count = (s.Dismantled) ? _count - 1 : _count + 1;
                    //顯示數目

                }
            }
        }

        //重設遊戲畫面
        void Reset()   
        {
            //關閉計時器

            //所有label歸零



            //建立新的地雷盤
            gm = new Game(this, _width, _height, _mines);
            gm.Start();  //放地雷進去
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("請顯示關於對話方塊，內容需包含系級學號、姓名資訊\n並放置能清晰辨別個人之生活照一張。");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //設定初級地雷盤

            
            
            //調整視窗寬度，讓格子看起來像正方形
            
            //重設遊戲畫面
            Reset();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //設定中級地雷盤

            
            
            //調整視窗寬度，讓格子看起來像正方形
            
            //重設遊戲畫面
            Reset();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //設定高級地雷盤

            
            
            //調整視窗寬度，讓格子看起來像正方形
            
            //重設遊戲畫面
            Reset();
        }

        private void MenuItem_Close_Click(object sender, RoutedEventArgs e)
        {
            //關閉視窗
            
        }
    }
}
