using ReAvix_2022.WindowUserControl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReAvix_2022.ViewModels
{
    internal class VMWindowAboutSkils
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand CommandSql = new SqlCommand();

        int NumberStudent;
        int NumberSkils;

        public string NameKat { get; set; }
        public string FullDate { get; set; }
        public byte LevelsMaster { get; set; }

        public VMWindowAboutSkils(int NomerSkils, int NumberSt)
        {
            NumberSkils = NomerSkils;
            NumberStudent = NumberSt;
           _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
          
            
            
            GetDataSkils();
        }
        public VMWindowAboutSkils()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
        }

        public int CheckSkils(int NomerSkils,out int NomerSkilsOut)
        {
            CommandSql.Connection = _Connection;
            _Connection.Open();
            CommandSql.CommandText = $"select Номер_Навыка from Навыки where Номер_Навыка = {NomerSkils}";
            var Nomer = CommandSql.ExecuteScalar();
            if (Nomer == null)
            {
                return NomerSkilsOut = 1;
            }
            else
            {
                return NomerSkilsOut = 0;
            }
        }
        public void GetDataSkils()
        {

                CommandSql.Connection = _Connection;
                _Connection.Open();
                CommandSql.CommandText = $"select [Категория_Навыка] from Навыки where Номер_Навыка = {NumberSkils} and FK_Номер_Студента = {NumberStudent}";
                NameKat = (string)CommandSql.ExecuteScalar();

                CommandSql.CommandText = $"select [Описание_Навыка] from Навыки where Номер_Навыка = {NumberSkils} and FK_Номер_Студента = {NumberStudent}";
                FullDate = (string)CommandSql.ExecuteScalar();

                CommandSql.CommandText = $"select [Мастерство_Навыка] from Навыки where Номер_Навыка = {NumberSkils} and FK_Номер_Студента = {NumberStudent}";
                LevelsMaster = (byte)CommandSql.ExecuteScalar();
                _Connection.Close();
        }
        
        public void UpdateSkils()
        {
            _Connection.Open();
            CommandSql.Connection = _Connection;


            CommandSql.CommandText = $"update Навыки set Описание_Навыка = '{FullDate}', Мастерство_Навыка = {LevelsMaster} where FK_Номер_Студента = {NumberStudent} and Номер_Навыка = {NumberSkils}";
            CommandSql.ExecuteNonQuery();
            _Connection.Close();
        }
        public void DeleteSkils()
        {
            _Connection.Open();
            CommandSql.Connection = _Connection;
            CommandSql.CommandText = $"delete [Навыки] where Номер_Навыка = {NumberSkils}";
            CommandSql.ExecuteNonQuery();
            _Connection.Close();
        }
    }
}
