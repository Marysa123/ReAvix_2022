using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReAvix_2022.ViewModels
{
    internal class VMWIndowAddInfoAdministrator
    {
        SqlConnection _Connection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();

        public VMWIndowAddInfoAdministrator()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            sqlCommand.Connection = _Connection;
            _Connection.Open();
        }
        public DataTable GetInfoGroup()
        {
            sqlCommand.CommandText = $"select Номер_Группы as 'Номер Группы',[Полное_Название_группы] as 'Название Группы' from Группа";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable("Группы");
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable GetInfoKat()
        {
            sqlCommand.CommandText = $"select Номер_Категории as 'Номер Категории',[Название_Категории] as 'Название Категории' from Категории_Навыка";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable("Группы");
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public DataTable GetInfoMugs()
        {
            sqlCommand.CommandText = $"select Номер_Кружка as 'Номер Кружка',[Название_Кружка] as 'Название Кружка' from Кружки";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable("Группы");
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public void AddInfoGroup(string NomerGroup,string DescriptionGroup)
        {
            try
            {
                sqlCommand.CommandText = $"insert into Группа (Номер_Группы,Полное_Название_Группы) values ('{NomerGroup}','{DescriptionGroup}')";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные добавлены.", "Диалоговое окно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Диалоговое окно");
            }
        }
        public void AddInfoMugs(string NameMugs)
        {
            sqlCommand.CommandText = $"insert into Кружки (Название_Кружка) values ('{NameMugs}')";
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Данные добавлены.", "Диалоговое окно");
        }
        public void AddInfoKat(string NameKat)
        {
            sqlCommand.CommandText = $"insert into Категории_Навыка (Название_Категории) values ('{NameKat}')";
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Данные добавлены.", "Диалоговое окно");
        }
        public void UpdateInfoKat(string NomerKat,string NewNameKat)
        {
            sqlCommand.CommandText = $"update Категории_Навыка set Название_Категории = '{NewNameKat}' WHERE Номер_Категории = {NomerKat}";
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены.", "Диалоговое окно");
        }
        public void UpdateInfoMugs(string NomerMugs, string NewNameMugs)
        {
            sqlCommand.CommandText = $"update Кружки set Название_Кружка = '{NewNameMugs}' WHERE Номер_Кружка = {NomerMugs}";
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены.", "Диалоговое окно");
        }
        public void UpdateInfoGroup(string NameGroup,string NewDiscriptionGroup)
        {
            sqlCommand.CommandText = $"update Группа set [Полное_Название_группы] = '{NewDiscriptionGroup}' WHERE Номер_Группы = '{NameGroup}'";
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Данные обновлены.", "Диалоговое окно");
        }
        public void DeleteInfoDataGrid(string NameTable,string NameColumn,string Nomer)
        {
            MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel);
            switch (result)
            {
                case MessageBoxResult.OK:
                    sqlCommand.CommandText = $"delete from {NameTable} where [{NameColumn}] = '{Nomer}'";
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Данные удалены.", "Диалоговое окно");
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }
    }
}
