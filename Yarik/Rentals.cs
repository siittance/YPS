//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Yarik
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rentals
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rentals()
        {
            this.EquipmentRentals = new HashSet<EquipmentRentals>();
        }
    
        public int ID_Rentals { get; set; }
        public string RentalDate { get; set; }
        public string ReturnDate { get; set; }
        public string ReservationDate { get; set; }
        public decimal TotalCost { get; set; }
        public int Clients_ID { get; set; }
        public int Equipment_ID { get; set; }
        public int RentalsStatus_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentRentals> EquipmentRentals { get; set; }
        public virtual Clients Clients { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual RentalsStatus RentalsStatus { get; set; }
    }
}
