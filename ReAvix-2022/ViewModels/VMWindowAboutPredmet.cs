using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAboutPredmet
    {
        public int NumberPred { get; set; }
        public byte[] Document { get; set; }

        //Для текста
        public string NamePred { get; set; }
        public string MainPrep { get; set; }
        public string AboutPred { get; set; }
        public string EndJob { get; set; }
        public string KolTime { get; set; }


        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public VMWindowAboutPredmet(int NomerPred)
        {
            NumberPred = NomerPred;
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            CommandSql.Connection = _Connection;
            _Connection.Open();

            CommandSql.CommandText = $"select Название_Предмета from Предметы_Преподавателя where Номер_Предмета = {NumberPred}";
            NamePred = CommandSql.ExecuteScalar().ToString();

            CommandSql.CommandText = $"select Ведущий_Преподаватель from Предметы_Преподавателя where Номер_Предмета = {NumberPred}";
            MainPrep = CommandSql.ExecuteScalar().ToString();

            CommandSql.CommandText = $"select Описание_предмета from Предметы_Преподавателя where Номер_Предмета = {NumberPred}";
            AboutPred = CommandSql.ExecuteScalar().ToString();

            CommandSql.CommandText = $"select Итоговая_работа from Предметы_Преподавателя where Номер_Предмета = {NumberPred}";
            EndJob = CommandSql.ExecuteScalar().ToString();

            CommandSql.CommandText = $"select Количество_часов from Предметы_Преподавателя where Номер_Предмета = {NumberPred}";
            KolTime = CommandSql.ExecuteScalar().ToString();
            _Connection.Close();
        }

        public void GetDataPredmet(string NameDocument) //Рабочий метод
        {

            _Connection.Close();
            _Connection.Open();

            if (CheckFailInDataBase(NameDocument) == true)
            {
                CommandSql.CommandText = $"select [{NameDocument}] from Предметы_Преподавателя where Номер_Предмета = {NumberPred}";
                Document = (byte[])CommandSql.ExecuteScalar();


                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "Word files (*.doc)|*.docx|ALL files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.ShowDialog();



                string filePatch2 = saveFileDialog.FileName;
                if (filePatch2 == "")
                {
                    return;
                }
                FileStream fileStream = new FileStream(filePatch2, FileMode.Create);

                BinaryWriter binaryWriter = new BinaryWriter(fileStream);
                binaryWriter.Write(Document, 0, Document.Length);
                MessageBox.Show("Успешное скачивание файла", "Диалоговое окно");
            }
            else
            {
                MessageBox.Show("Файла отсутствует", "Диалоговое окно");
            }
        }
        public void DeleteDocumentPredmets(string NameDocument)
        {
            _Connection.Close();
            _Connection.Open();
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить файл?", "Диалогове окно", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                CommandSql.CommandText = $"Update Предметы_Преподавателя set {NameDocument} = null where Номер_Предмета = {NumberPred}";
                CommandSql.ExecuteNonQuery();
                MessageBox.Show("Успешное удаление файла!","Диалоговое окно");
            }
        }
        public string AddDocument(out string Url)
        {
            OpenFileDialog openFile = new OpenFileDialog();// создаем диалоговое окно
            openFile.ShowDialog();
            string FileName = openFile.FileName;
            return Url = FileName;
        }
        private bool CheckFailInDataBase(string NameDoc)
        {
            CommandSql.CommandText = $"select [{NameDoc}] from Предметы_Преподавателя where Номер_Предмета = {NumberPred} and {NameDoc} is not null";
            object Result = CommandSql.ExecuteScalar();
            if (Result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
