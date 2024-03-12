using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;
using Path = System.IO.Path;

namespace WpfApp1.window.Views
{
    /// <summary>
    /// BreakPage.xaml 的交互逻辑
    /// </summary>
    public partial class BreakPage : Page
    {
        public BreakPage()
        {
            InitializeComponent();
        }

        private void ReadFile(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取应用程序的安装目录
                string installationDirectory = AppDomain.CurrentDomain.BaseDirectory;
                // 构建文件路径
                string filePath = Path.Combine(installationDirectory, "file.txt");
                int[] arrayData;

                // 如果文件存在，则读取文件中的数据
                if (File.Exists(filePath))
                {
                    // 从文件中读取数据
                    string fileContent = File.ReadAllText(filePath);
                    // 将读取的数据转换为整数数组
                    arrayData = fileContent.Split(',').Select(int.Parse).ToArray();


                }
                else
                {
                    // 如果文件不存在，则创建文件并写入数组
                    arrayData = new int[] { 1, 2, 3, 4, 5, 6, 7 };

                    // 写入数组数据到文件中
                    WriteArrayToFile(filePath, arrayData);
                }

                MessageBox.Show("操作完成。");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }

        private void ReadAndUpdateOrCreateFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // 获取应用程序的安装目录
                string installationDirectory = AppDomain.CurrentDomain.BaseDirectory;
                // 构建文件路径
                string filePath = Path.Combine(installationDirectory, "file.txt");
                int[] arrayData;

                // 如果文件存在，则读取文件中的数据
                if (File.Exists(filePath))
                {
                    // 从文件中读取数据
                    string fileContent = File.ReadAllText(filePath);

                    // 将读取的数据转换为整数数组
                    arrayData = fileContent.Split(',').Select(int.Parse).ToArray();

                    // 修改数组中的值，这里示例修改第一个元素为 100
                    a0.Content = arrayData[0];
                    a1.Content = arrayData[1];
                    a2.Content = arrayData[2];
                    a3.Content = arrayData[3];
                    a4.Content = arrayData[4];
                    a5.Content = arrayData[5];

                    // 写入修改后的数组数据回文件中
                    WriteArrayToFile(filePath, arrayData);
                }
                else
                {
                    // 如果文件不存在，则创建文件并写入数组
                    arrayData = new int[] { 1, 2, 3, 4, 5, 6, 7 };

                    // 写入数组数据到文件中
                    WriteArrayToFile(filePath, arrayData);
                }

                MessageBox.Show("操作完成。");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误: {ex.Message}");
            }
        }
        private void WriteArrayToFile(string filePath, int[] arrayData)
        {
            // 将数组中的每个元素转换为字符串，并用逗号分隔
            string arrayString = string.Join(",", arrayData);

            // 将数组数据写入文件
            File.WriteAllText(filePath, arrayString);
        }

    }
}
