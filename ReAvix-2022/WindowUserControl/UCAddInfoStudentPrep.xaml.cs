using ReAvix_2022.ViewModels;
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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReAvix_2022.WindowUserControl
{
    /// <summary>
    /// Логика взаимодействия для UCAddInfoStudentPrep.xaml
    /// </summary>
    public partial class UCAddInfoStudentPrep : UserControl
    {
        int NumberPrep;
        VMWindowAddInfoStudentPrep vMWindowAddInfoStudent;
        public UCAddInfoStudentPrep(int NomerPrep)
        {
            NumberPrep = NomerPrep;
            InitializeComponent();

            vMWindowAddInfoStudent = new VMWindowAddInfoStudentPrep(NumberPrep);
            DataContext = vMWindowAddInfoStudent;

            GetInfoStudent();

        }
        public UCAddInfoStudentPrep()
        {
            InitializeComponent();

        }
        string NameGroup;
        SqlConnection _Connection = new SqlConnection(); //Создание экземпляров
        SqlCommand sqlCommand = new SqlCommand();
        System.Data.DataTable dataTableFour;
        public void GetInfoStudent()
        {
            _Connection.ConnectionString = ConfigurationManager.ConnectionStrings["ReAvix_2022.Properties.Settings.Параметр"].ConnectionString; // Строка подключения взятая из параметров проекта
            _Connection.Open();

            sqlCommand.Connection = _Connection;
            sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
            NameGroup = (string)sqlCommand.ExecuteScalar();

            sqlCommand.CommandText = $"select Номер_оценки as 'Номер',Convert(date, Дата,101) as 'Дата',FK_Номер_Студента as 'Номер Студента',[FK_Номер_Предмета] as 'Номер Предмета',[Оценка],[Вид_оценочной_работы] as 'Вид оценочной работы' from [Оценки],[Студенты] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Оценки");
            GridView.ItemsSource = dataTable.DefaultView;
            sqlDataAdapter.Fill(dataTable);

            sqlCommand.CommandText = $"select DISTINCT([FK_Номер_Предмета]) as 'Номер Предмета',[Название_Предмета] as 'Название Предмета' from [Оценки],[Студенты],[Предметы] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета group by FK_Номер_Предмета,Название_Предмета";
            SqlDataAdapter sqlDataAdapterThree = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTableThree = new System.Data.DataTable("Студенты");
            GridViewPredmet.ItemsSource = dataTableThree.DefaultView;
            GridViewPredmet.IsReadOnly = true;
            sqlDataAdapterThree.Fill(dataTableThree);

            sqlCommand.CommandText = $"select FK_Номер_Студента as 'Номер Студента',[Фамилия] + ' ' + [Имя] AS ФИО, Уважительные_Пропуски as 'Уважительные пропуски',Неуважительные_пропуски as 'Неуважительные пропуски',Пропуски_по_болезни as 'Пропуски по болезни' from [Пропуски],[Студенты] where FK_Номер_Студента = [Номер_Студента] and [FK_Номер_Группы] = '{NameGroup}' order by Уважительные_Пропуски desc";
            SqlDataAdapter sqlDataAdapterFour = new SqlDataAdapter(sqlCommand);
            dataTableFour = new System.Data.DataTable("Студенты");
            GridViewOmissions.ItemsSource = dataTableFour.DefaultView;
            sqlDataAdapterFour.Fill(dataTableFour);




            _Connection.Close();


        }

        List<int> MassivNomerStudent = new List<int>();
        List<int> MassivNomerOchenok = new List<int>();

        private void button_DeleteOmissions_Click(object sender, RoutedEventArgs e)
        {
            _Connection.Open();

            sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
            string NameGroup = (string)sqlCommand.ExecuteScalar();


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
            MessageBox.Show("Пропуски успешно стёрты.");

            UpdateTableOmissions();

            _Connection.Close();

        }
        private void UpdateTableOmissions()
        {
            sqlCommand.CommandText = $"select FK_Номер_Студента as 'Номер Студента',[Фамилия] + ' ' + [Имя] AS ФИО, Уважительные_Пропуски as 'Уважительные пропуски',Неуважительные_пропуски as 'Неуважительные пропуски',Пропуски_по_болезни as 'Пропуски по болезни' from [Пропуски],[Студенты] where FK_Номер_Студента = [Номер_Студента] and [FK_Номер_Группы] = '{NameGroup}' order by Уважительные_Пропуски desc";
            SqlDataAdapter sqlDataAdapterFour = new SqlDataAdapter(sqlCommand);
            dataTableFour = new System.Data.DataTable("Студенты");
            sqlDataAdapterFour.Fill(dataTableFour);

            GridViewOmissions.ItemsSource = null;
            GridViewOmissions.ItemsSource = dataTableFour.DefaultView;

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textbox_Bolezn.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно");
            }
            else
            {
                _Connection.Open();
                sqlCommand.CommandText = $"update Пропуски set [Уважительные_Пропуски] = {textbox_Yvash.Text},[Неуважительные_Пропуски] = {textbox_NoYvash.Text}, [Пропуски_по_болезни] = {textbox_Bolezn.Text} where [FK_Номер_Студента] = {label_NomerStud.Content.ToString()}";
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");

                GridViewOmissions.ItemsSource = null;
                sqlCommand.CommandText = $"select FK_Номер_Студента as 'Номер Студента',[Фамилия] + ' ' + [Имя] AS ФИО, Уважительные_Пропуски as 'Уважительные пропуски',Неуважительные_пропуски as 'Неуважительные пропуски',Пропуски_по_болезни as 'Пропуски по болезни' from [Пропуски],[Студенты] where FK_Номер_Студента = [Номер_Студента] and [FK_Номер_Группы] = '{NameGroup}' order by Уважительные_Пропуски desc";
                SqlDataAdapter sqlDataAdapterFour = new SqlDataAdapter(sqlCommand);
                dataTableFour = new System.Data.DataTable("Студенты");
                sqlDataAdapterFour.Fill(dataTableFour);
                GridViewOmissions.ItemsSource = dataTableFour.DefaultView;

                _Connection.Close();


            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (textbox_NomerPredmet.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно");
            }
            else
            {
                _Connection.Close();

                _Connection.Open();
                sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
                string NameGroup = (string)sqlCommand.ExecuteScalar();


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

                int Nomer = int.Parse(textbox_NomerStudent.Text);

                for (int i = 0; i < Count; i++)
                {
                    if (Nomer == MassivNomerStudent[i])
                    {
                        sqlCommand.CommandText = "set language english;";
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.CommandText = $"update Оценки set [Дата] = Convert(datetime,'{textbox_Data.Text}'),FK_Номер_Студента = {textbox_NomerStudent.Text},FK_Номер_Предмета = {textbox_NomerPredmet.Text}, Оценка = {textbox_OChenka.Text}, Вид_оценочной_работы ='{textbox_VidWork.Text}' where Номер_оценки = {label_Номер.Content.ToString()}";
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");

                        UpdateInfoStudent();

                        GetInfoPredmet($"select DISTINCT([FK_Номер_Предмета]) as 'Номер Предмета',[Название_Предмета] as 'Название Предмета' from [Оценки],[Студенты],[Предметы] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета group by FK_Номер_Предмета,Название_Предмета");

                        _Connection.Close();
                    }
                }
               
            }
        }

        private void UpdateInfoStudent()
        {
            GridViewPredmet.ItemsSource = null;
            sqlCommand.CommandText = $"select Номер_оценки as 'Номер',Convert(date, Дата,101) as 'Дата',FK_Номер_Студента as 'Номер Студента',[FK_Номер_Предмета] as 'Номер Предмета',[Оценка],[Вид_оценочной_работы] as 'Вид оценочной работы' from [Оценки],[Студенты] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable("Оценки");
            sqlDataAdapter.Fill(dataTable);
            GridView.ItemsSource = dataTable.DefaultView;

        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if (textbox_NomerPredmet.Text == "")
            {
                MessageBox.Show("Пустые поля.", "Диалоговое окно");
            }
            else
            {
                _Connection.Close();

                _Connection.Open();
                sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
                string NameGroup = (string)sqlCommand.ExecuteScalar();


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

                int Nomer = int.Parse(textbox_NomerStudent.Text);

                for (int i = 0; i < Count; i++)
                {
                    if (Nomer == MassivNomerStudent[i])
                    {
                        _Connection.Close();
                        _Connection.Open();
                        sqlCommand.CommandText = "set language english;";
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.CommandText = $"insert into Оценки values (Convert(date,'{textbox_Data.Text}'),{textbox_NomerStudent.Text},{textbox_NomerPredmet.Text},{textbox_OChenka.Text},'{textbox_VidWork.Text}')";
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Данные успешно обновлены.", "Диалоговое окно");

                        UpdateInfoStudent();
                        GetInfoPredmet($"select DISTINCT([FK_Номер_Предмета]) as 'Номер Предмета',[Название_Предмета] as 'Название Предмета' from [Оценки],[Студенты],[Предметы] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета group by FK_Номер_Предмета,Название_Предмета");
                        _Connection.Close();
                    }
                }
            }
        }

        private void button_SelectPredmetGroup_Click(object sender, RoutedEventArgs e)
        {
            GetInfoPredmet($"select DISTINCT([FK_Номер_Предмета]) as 'Номер Предмета',[Название_Предмета] as 'Название Предмета' from [Оценки],[Студенты],[Предметы] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета group by FK_Номер_Предмета,Название_Предмета");

        }

        private void button_SelectAllPredmet_Click(object sender, RoutedEventArgs e)
        {
            GetInfoPredmet("select Номер_Предмета as 'Номер Предмета', Название_Предмета as 'Название Предмета' from [Предметы]");

        }

        private void GetInfoPredmet(string Select)
        {
            GridViewPredmet.ItemsSource = null;
            sqlCommand.CommandText = $"{Select}";
            SqlDataAdapter sqlDataAdapterThree = new SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTableThree = new System.Data.DataTable("Студенты");
            sqlDataAdapterThree.Fill(dataTableThree);
            GridViewPredmet.ItemsSource = dataTableThree.DefaultView;
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {  
            if (GridView.CurrentCell.Column.DisplayIndex == 0)
            {
                _Connection.Open();
                MessageBoxResult result = MessageBox.Show("Вы хотите удалить поле?", "Окно удаления данных", MessageBoxButton.OKCancel);


                switch (result)
                {
                    case MessageBoxResult.OK:



                        _Connection.Close();

                            _Connection.Open();
                            sqlCommand.CommandText = $"select FK_Закреплённая_Группа from [Преподаватели] where [Номер_Преподавателя] = {NumberPrep}";
                            string NameGroup = (string)sqlCommand.ExecuteScalar();


                            sqlCommand.CommandText = $"select COUNT (Номер_Оценки) from [Студенты],[Оценки] where [FK_Номер_Студента] = [Номер_Студента]  and FK_Номер_Группы = '{NameGroup}'";
                            sqlCommand.Connection = _Connection;
                            int Count = (int)sqlCommand.ExecuteScalar();

                            sqlCommand.CommandText = $"select Номер_Оценки from [Студенты],[Оценки] where [FK_Номер_Студента] = [Номер_Студента]  and FK_Номер_Группы = '{NameGroup}'";

                            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                            MassivNomerOchenok = new List<int>();
                            while (sqlDataReader.Read())
                            {
                                MassivNomerOchenok.Add((int)sqlDataReader.GetValue(0));
                            }
                            sqlDataReader.Close();

                            var Name = ((DataRowView)GridView.SelectedItems[0]).Row["Номер"].ToString();


                            for (int i = 0; i < Count; i++)
                            {
                                if (Name == MassivNomerOchenok[i].ToString())
                                 {


                                    sqlCommand.CommandText = $"delete from Оценки where [Номер_оценки] = {Name}";
                                    sqlCommand.ExecuteNonQuery();
                                    MessageBox.Show("Запись удалена!");
                                    UpdateInfoStudent();
                                    GetInfoPredmet($"select DISTINCT([FK_Номер_Предмета]) as 'Номер Предмета',[Название_Предмета] as 'Название Предмета' from [Оценки],[Студенты],[Предметы] where [FK_Номер_Студента] = [Номер_Студента] and FK_Номер_Группы = '{NameGroup}' and FK_Номер_Предмета = Номер_Предмета group by FK_Номер_Предмета,Название_Предмета");
                                    _Connection.Close();
                                }

                            }



                        
                        break;
                    case MessageBoxResult.Cancel:
                        _Connection.Close();
                        break;
                }
                _Connection.Close();
            }
        }
    }
}
