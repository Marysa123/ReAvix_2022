//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReAvix_2022.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Преподаватели
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Преподаватели()
        {
            this.Заметки = new HashSet<Заметки>();
        }
    
        public int Номер_Преподавателя { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчество { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public string E_mail { get; set; }
        public string Номер_Телефона { get; set; }
        public string Пол { get; set; }
        public System.DateTime Дата_Рождения { get; set; }
        public string Адрес { get; set; }
        public string Специальность { get; set; }
        public string Краткая_Информация { get; set; }
        public string Ведущий_Кружок { get; set; }
        public string FK_Закреплённая_группа { get; set; }
        public byte[] Фотография { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заметки> Заметки { get; set; }
    }
}
