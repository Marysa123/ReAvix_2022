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
    
    public partial class Достижения
    {
        public int Номер_Достижения { get; set; }
        public byte[] Изображение { get; set; }
        public byte[] Дополнительное_Изображение { get; set; }
        public string Место_в_соревновании { get; set; }
        public string Место_Проведения { get; set; }
        public string Название_Соревнования { get; set; }
        public Nullable<int> FK_Номер_Студента { get; set; }
    
        public virtual Студенты Студенты { get; set; }
    }
}
