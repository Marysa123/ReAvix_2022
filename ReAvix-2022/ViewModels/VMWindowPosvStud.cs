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
    internal class VMWindowPosvStud
    {
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand sqlCommand = new SqlCommand();
         public System.Data.DataTable dataTableFour;
        UCPosvStud uCPosvStud = new UCPosvStud();

        public int NumberPrep { get; set; }
        public string NameGroup { get; set; }

        List<int> MassivNomerStudent = new List<int>();


        public void DeleteOmission()
        {
            _Connection.Open();

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите обнулить пропуски?", "Окно удаления данных", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    sqlCommand.CommandText = $"select COUNT(Номер_Студента) from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";
                    sqlCommand.Connection = _Connection;
                    int Count = (int)sqlCommand.ExecuteScalar();

                    sqlCommand.CommandText = $"select Номер_Студента from [Студенты] where [FK_Номер_Группы] = '{NameGroup}'";

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    MassivNomerStudent = new List<int>();
                    while (sqlDataReader.Read())
                    {
                        MassivNomerStudent.Add((int)sqlDataReader.GetValue(0));
                    }
                    sqlDataReader.Close();

                    for (int i = 0; i < Count; i++)
                    {
                        sqlCommand.CommandText = $"update Пропуски set [Уважительные_Пропуски] = 0,[Неуважительные_Пропуски] = 0, [Пропуски_по_болезни] = 0 where [FK_Номер_Студента] = {MassivNomerStudent[i]}";
                        sqlCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show("Пропуски успешно стёрты.", "Диалоговое окно");

                    UpdateOmissions();

                    _Connection.Close();
                    break;
                case MessageBoxResult.Cancel:
                    break;
                case MessageBoxResult.Yes:
                default:
                    break;
            }
        }
        public void UpdateOmissions()
        {
            _Connection.Close();
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта

            sqlCommand.CommandText = $"select FK_Номер_Студента as 'Номер Студента',[Фамилия] + ' ' + [Имя] AS ФИО, Уважительные_Пропуски as 'Уважительные пропуски',Неуважительные_пропуски as 'Неуважительные пропуски',Пропуски_по_болезни as 'Пропуски по болезни' from [Пропуски],[Студенты] where FK_Номер_Студента = [Номер_Студента] and [FK_Номер_Группы] = '{NameGroup}' order by Уважительные_Пропуски desc";
            SqlDataAdapter sqlDataAdapterFour = new SqlDataAdapter(sqlCommand);
            sqlCommand.Connection = _Connection;
            dataTableFour = new System.Data.DataTable("Студенты");
            sqlDataAdapterFour.Fill(dataTableFour);
        }
    }
}
