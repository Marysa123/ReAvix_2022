using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;


namespace ReAvix_2022.ViewModels
{
    internal class VMWindowInfoAboutPredmet
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        public string NamePredmet { get; set; }
        public string NameWork { get; set; }
        public string FIOPrep { get; set; }

        List<int> listOchenok;
        List<int> listDate;

        public static ObservableCollection<ISeries> Series { get; set; }
        public static ObservableCollection<ObservablePoint> observables;

        public VMWindowInfoAboutPredmet()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
        }

        public void GetInfoPredmet(int NomerPred)
        {
            _Connection.Open();
            CommandSql.Connection = _Connection;

            CommandSql.CommandText = $"select [Название_предмета] from [Предметы] where [Номер_Предмета] = {NomerPred}";
            NamePredmet = "Наименование предмета: " + (string)CommandSql.ExecuteScalar();
            string Name = (string)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [ФИО_Преподавателя] from [Предметы] where [Номер_Предмета] = {NomerPred}";
            FIOPrep = "ФИО преподавателя: " + (string)CommandSql.ExecuteScalar();


            CommandSql.CommandText = $"select [Вид_итоговой_Работы] from [Предметы] where [Номер_Предмета] = {NomerPred}";
            NameWork = "Вид итоговой работы: " + (string)CommandSql.ExecuteScalar();

            _Connection.Close();
        }

        public void AddGraph(int NomerPred, int NumberSt, int IndexMontch, out ObservableCollection<ISeries> SeriesOut)
        {
            if (Series == null || observables == null) // Проверка на null, поля должны быть пустые
            {

            }
            else
            {
                Series.Clear();
                observables.Clear();
            }

            _Connection.Open();
            CommandSql.Connection = _Connection;

            CommandSql.CommandText = $"select COUNT(Оценка) from [Оценки] where [FK_Номер_Предмета] = {NomerPred} and [FK_Номер_Студента] = {NumberSt} and DATEPART(MONTH,[Дата]) = {IndexMontch}";
            int Count = (int)CommandSql.ExecuteScalar();

            CommandSql.CommandText = $"select [Оценка] from [Оценки] where [FK_Номер_Предмета] = {NomerPred} and [FK_Номер_Студента] = {NumberSt} and DATEPART(MONTH,[Дата]) = {IndexMontch}";
            SqlDataReader sqlDataReader = CommandSql.ExecuteReader();
            listOchenok = new List<int>();

            while (sqlDataReader.Read())
            {
                listOchenok.Add((int)sqlDataReader.GetValue(0));
            }
            sqlDataReader.Close();

            CommandSql.CommandText = $"SELECT DATEPART(DAY,[Дата]) from [Оценки] WHERE [FK_Номер_Предмета] = {NomerPred} and [FK_Номер_Студента] = {NumberSt} and DATEPART(MONTH,[Дата]) = {IndexMontch}";
            SqlDataReader sqlDataReader1 = CommandSql.ExecuteReader();
            listDate = new List<int>();

            while (sqlDataReader1.Read())
            {
                listDate.Add((int)sqlDataReader1.GetValue(0));
            }
            sqlDataReader1.Close();

            observables = new ObservableCollection<ObservablePoint>
            {
                new ObservablePoint(0,0)
            };


            for (int i = 0; i < Count; i++)
            {
                Series = new ObservableCollection<ISeries>
                {
                    new LineSeries<ObservablePoint>
                    {
                        Values = observables,
                        Fill = null
                    }
                };

                observables.Add(new ObservablePoint(listDate[i], listOchenok[i]));
            }
            _Connection.Close();
            SeriesOut = Series;
        }
    }
}
